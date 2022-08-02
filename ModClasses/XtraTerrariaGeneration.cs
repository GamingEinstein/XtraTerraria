using XtraTerraria.Content.Placeables.Tiles;
using XtraTerraria.Content.Placeables.Walls;
using static XtraTerraria.ModClasses.XtraTerraria;
using static XtraTerraria.ModClasses.XtraTerrariaGenerationHelpers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.ModClasses
{
    public class XtraTerrariaGeneration : ModSystem
    {
        public static void GenerateFloodedCaves(int worldX, int worldY, bool dungeonLeftSide)
        {
            int worldSizeX = (int)(Main.maxTilesX / 4200f);
            int worldSizeY = Main.maxTilesY;
            int biomeWidth = 0;
            int biomeWidthMax = 250;
            int biomeHeight = 0;
            int biomeHeightMax = 250;
            int beachBottomCheck = worldY;
            int sideCaves = 0;

            // Checks until we find the next tile that isn't sand (basically, get the beach bottom)
            while (beachBottomCheck < Main.worldSurface + 250)
            {
                Tile foundTile = Framing.GetTileSafely(worldX, beachBottomCheck);
                if (foundTile.TileType == TileID.Dirt || foundTile.TileType == TileID.Stone || foundTile.TileType == TileID.ClayBlock || !foundTile.HasTile)
                    break;

                beachBottomCheck++;
            }

            // Generating the blocks for the biome...
            for (int i = 0; i <= biomeWidthMax; i++)
            {
                for (int j = 0; j <= biomeHeightMax; j++)
                {
                    int xPos = worldX - ((biomeWidthMax - (50 * (dungeonLeftSide ? -1 : 1))) / 2) + i;
                    int yPos = beachBottomCheck + 25 + j;

                    // Check if it isn't sand from the beach essentially
                    Tile tileCheck = Framing.GetTileSafely(xPos, yPos);
                    if ((tileCheck.TileType != TileID.Sand && tileCheck.TileType != TileID.HardenedSand && tileCheck.TileType != TileID.Sandstone) || yPos >= Main.worldSurface + 25)
                    {
                        // Place the Water, Tiles, Walls, and such
                        WorldGen.PlaceLiquid(xPos, yPos, LiquidID.Water, 255);
                        WorldGen.PlaceTile(xPos, yPos, TileType<BasaltTile>(), true, true, -1, 0);
                        WorldGen.KillWall(xPos, yPos);
                        WorldGen.PlaceWall(xPos, yPos, WallType<BasaltWall>(), true);

                        tileCheck = Framing.GetTileSafely(xPos, yPos);
                        if (tileCheck.Slope != SlopeType.Solid)
                            WorldGen.SlopeTile(xPos, yPos, 0);

                        // Since I'm dumb, I'm running a Tile Runner on the edges so that I can get some form of blending of blocks... Thanks tModLoader community
                        if ((i == 0 || i == biomeWidthMax) || (j == 0 || j == biomeHeightMax))
                            WorldGen.TileRunner(xPos, yPos, WorldGen.genRand.Next(32, 64), 3, TileType<BasaltTile>(), true);
                    }

                    biomeHeight++;
                }
                biomeWidth++;
            }

            // Places Obsidian Patches in the lower half of the biome
            for (int i = 0; i < 25; i++)
            {
                int xPos = WorldGen.genRand.Next(worldX - ((biomeWidthMax - (50 * (dungeonLeftSide ? -1 : 1))) / 2), worldX + ((biomeWidthMax + (50 * (dungeonLeftSide ? -1 : 1))) / 2));
                int yPos = WorldGen.genRand.Next(worldY + (biomeHeightMax / 2), worldY + (biomeHeightMax + 50));

                WorldGen.TileRunner(xPos, yPos, WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(3, 6), TileID.Obsidian);
            }

            // Place Scorium in increasing amounts as you go deeper... if I can figure it out
            for (int i = 0; i < 35; i++)
            {
                int xPos = WorldGen.genRand.Next(worldX - ((biomeWidthMax - (50 * (dungeonLeftSide ? -1 : 1))) / 2), worldX + ((biomeWidthMax + (50 * (dungeonLeftSide ? -1 : 1))) / 2));
                int yPos = WorldGen.genRand.Next(worldY + ((biomeHeightMax + 50) / 2), worldY + (biomeHeightMax + 50));

                WorldGen.TileRunner(xPos, yPos, WorldGen.genRand.Next(8, 13), WorldGen.genRand.Next(3, 6), TileType<ScoriumTile>());
            }

            // Make the enterance
            if (worldSizeX == 1)
                WorldGen.digTunnel(worldX, worldY, 0, 5, 20, 10, true);
            else if (worldSizeX == 1.5)
                WorldGen.digTunnel(worldX, worldY, 0, 5, 25, 10, true);
            else if (worldSizeX == 2)
                WorldGen.digTunnel(worldX, worldY, 0, 5, 30, 10, true);

            // Cave generation... yeah I actually need someone to teach me that, since no one wants to give that information publicly...
            // Instead of having someone actually teach me that, I'm using blotches a lot to make it look somewhat like a cave... I guess... It does work tho...
            // Pain btw... much pain... massive pain... kill me rn please... help... im locked in a basement... this is mostly a joke...
            // Thanks tModLoader community for the massive help...
            Point blotchOrigin = new(worldX + 5, worldY + 60);
            int caveRadiusX = 15;
            int caveRadiusY = 15;

            for (int i = 0; i < 45; i++)
            {
                WorldUtils.Gen(blotchOrigin, new Shapes.Circle(caveRadiusX, caveRadiusY), Actions.Chain(new GenAction[]
                {
                    new Modifiers.Blotches(),
                    new Actions.ClearTile(true),
                    new Actions.PlaceWall((ushort)WallType<BasaltWall>(), true),
                    new Actions.SetLiquid(LiquidID.Water),
                    new Actions.Smooth(true)
                }));

                // Initial descent
                if (i < 10)
                {
                    if (i < 5)
                    {
                        blotchOrigin.X += 5 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 10;

                        if (i < 2)
                        {
                            caveRadiusX -= 1;
                            caveRadiusY -= 1;
                        }

                        if (i == 2)
                        {
                            GenerateSideCave(blotchOrigin, sideCaves, dungeonLeftSide);
                            sideCaves++;
                        }

                    }

                    else
                    {
                        blotchOrigin.X += 15 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += WorldGen.genRand.Next(2, 5);
                    }
                }

                // Turn 1
                else if (i > 9 && i < 13)
                    blotchOrigin.Y += 17;

                // Descent 2
                else if (i < 20)
                {
                    if (i == 13)
                    {
                        GenerateSideCave(blotchOrigin, sideCaves, dungeonLeftSide);
                        sideCaves++;
                    }

                    blotchOrigin.X -= 15 * (dungeonLeftSide ? -1 : 1);
                    blotchOrigin.Y += WorldGen.genRand.Next(2, 5);
                }

                // Slight back-turn
                else if (i < 25)
                {
                    if (i == 20)
                    {
                        GenerateSideCave(blotchOrigin, sideCaves, dungeonLeftSide);
                        sideCaves++;
                    }

                    if (i < 22)
                    {
                        caveRadiusX -= 1;
                        caveRadiusY -= 1;
                    }

                    blotchOrigin.X += 2 * (dungeonLeftSide ? -1 : 1);
                    blotchOrigin.Y += 13;

                    if (i == 21)
                    {
                        GenerateSideCave(blotchOrigin, sideCaves, dungeonLeftSide);
                        sideCaves++;
                    }
                }

                // Slight Up
                else if (i < 30)
                {
                    if (i == 25)
                    {
                        GenerateSideCave(blotchOrigin, sideCaves, dungeonLeftSide);
                        sideCaves++;
                    }

                    blotchOrigin.X -= 8 * (dungeonLeftSide ? -1 : 1);
                    blotchOrigin.Y -= 8;
                }

                // Back Down
                else if (i < 40)
                {
                    if (i < 32)
                    {
                        blotchOrigin.X -= 8 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 5;
                    }

                    else
                    {
                        if (i == 32)
                        {
                            GenerateSideCave(blotchOrigin, sideCaves, dungeonLeftSide);
                            sideCaves++;
                        }

                        if (i < 35)
                        {
                            caveRadiusX -= 1;
                            caveRadiusY -= 1;
                        }

                        blotchOrigin.X += 3 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 10;
                    }
                }

                // Final Turn
                else if (i < 45)
                {
                    blotchOrigin.X += 8 * (dungeonLeftSide ? -1 : 1);
                    blotchOrigin.Y += 1;
                }

                // Record information so we can use this later
                else if (i == 45)
                    floodedCavesEnd_1 = blotchOrigin;
            }
        }

        private static void GenerateSideCave(Point blotchOrigin, int sideCaves, bool dungeonLeftSide)
        {
            // This method makes the little caves around the biome. Each one has a chest that contains loot
            int caveRadiusX = 5;
            int caveRadiusY = 5;

            if (sideCaves == 0)
            {
                blotchOrigin.Y += 35;

                for (int i = 0; i < 8; i++)
                {
                    WorldUtils.Gen(blotchOrigin, new Shapes.Circle(caveRadiusX, caveRadiusY), Actions.Chain(new GenAction[]
                    {
                        new Modifiers.Blotches(),
                        new Actions.ClearTile(true),
                        new Actions.PlaceWall((ushort)WallType<BasaltWall>(), true),
                        new Actions.SetLiquid(LiquidID.Water),
                        new Actions.Smooth(true)
                    }));

                    if (i < 2)
                    {
                        blotchOrigin.X -= 6 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 4;
                    }

                    else if (i < 6)
                        blotchOrigin.X -= 6 * (dungeonLeftSide ? -1 : 1);

                    else if (i == 6)
                    {
                        blotchOrigin.X -= 10 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y -= 6;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }

                    else if (i == 7)
                        PlaceCaveChest(blotchOrigin.X, blotchOrigin.Y, sideCaves);
                }
            }
            else if (sideCaves == 1)
            {
                blotchOrigin.X += 10 * (dungeonLeftSide ? -1 : 1);
                blotchOrigin.Y += 15;

                for (int i = 0; i < 8; i++)
                {
                    WorldUtils.Gen(blotchOrigin, new Shapes.Circle(caveRadiusX, caveRadiusY), Actions.Chain(new GenAction[]
                    {
                        new Modifiers.Blotches(),
                        new Actions.ClearTile(true),
                        new Actions.PlaceWall((ushort)WallType<BasaltWall>(), true),
                        new Actions.SetLiquid(LiquidID.Water),
                        new Actions.Smooth(true)
                    }));

                    if (i < 2)
                    {
                        blotchOrigin.X += 6 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 4;
                    }

                    else if (i < 6)
                        blotchOrigin.X += 6 * (dungeonLeftSide ? -1 : 1);

                    else if (i == 6)
                    {
                        blotchOrigin.X += 10 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y -= 10;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }

                    else if (i == 7)
                        PlaceCaveChest(blotchOrigin.X, blotchOrigin.Y, sideCaves);
                }
            }

            else if (sideCaves == 2)
            {
                blotchOrigin.X -= 15 * (dungeonLeftSide ? -1 : 1);
                blotchOrigin.Y -= 10;

                for (int i = 0; i < 8; i++)
                {
                    WorldUtils.Gen(blotchOrigin, new Shapes.Circle(caveRadiusX, caveRadiusY), Actions.Chain(new GenAction[]
                    {
                        new Modifiers.Blotches(),
                        new Actions.ClearTile(true),
                        new Actions.PlaceWall((ushort)WallType<BasaltWall>(), true),
                        new Actions.SetLiquid(LiquidID.Water),
                        new Actions.Smooth(true)
                    }));

                    if (i < 2)
                    {
                        blotchOrigin.X -= 6 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y -= 4;
                    }

                    else if (i < 6)
                        blotchOrigin.X -= 6 * (dungeonLeftSide ? -1 : 1);

                    else if (i == 6)
                    {
                        blotchOrigin.X -= 10 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y -= 6;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }

                    else if (i == 7)
                        PlaceCaveChest(blotchOrigin.X, blotchOrigin.Y, sideCaves);
                }
            }
            else if (sideCaves == 3)
            {
                blotchOrigin.X += 15 * (dungeonLeftSide ? -1 : 1);

                for (int i = 0; i < 8; i++)
                {
                    WorldUtils.Gen(blotchOrigin, new Shapes.Circle(caveRadiusX, caveRadiusY), Actions.Chain(new GenAction[]
                    {
                        new Modifiers.Blotches(),
                        new Actions.ClearTile(true),
                        new Actions.PlaceWall((ushort)WallType<BasaltWall>(), true),
                        new Actions.SetLiquid(LiquidID.Water),
                        new Actions.Smooth(true)
                    }));

                    if (i < 2)
                    {
                        blotchOrigin.X += 6 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 4;
                    }

                    else if (i < 6)
                        blotchOrigin.X += 6 * (dungeonLeftSide ? -1 : 1);

                    else if (i == 6)
                    {
                        blotchOrigin.X += 10 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y -= 10;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }

                    else if (i == 7)
                        PlaceCaveChest(blotchOrigin.X, blotchOrigin.Y, sideCaves);
                }
            }

            else if (sideCaves == 4)
            {
                caveRadiusX = 10;
                caveRadiusY = 10;
                blotchOrigin.X -= 20 * (dungeonLeftSide ? -1 : 1);
                blotchOrigin.Y -= 15;

                for (int i = 0; i < 10; i++)
                {
                    WorldUtils.Gen(blotchOrigin, new Shapes.Circle(caveRadiusX, caveRadiusY), Actions.Chain(new GenAction[]
                    {
                        new Modifiers.Blotches(),
                        new Actions.ClearTile(true),
                        new Actions.PlaceWall((ushort)WallType<BasaltWall>(), true),
                        new Actions.SetLiquid(LiquidID.Water),
                        new Actions.Smooth(true)
                    }));

                    if (i < 5)
                    {
                        blotchOrigin.X += 15 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 5;
                    }

                    else if (i < 7)
                    {
                        blotchOrigin.X += 10 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 10;
                    }

                    else if (i < 10)
                    {
                        blotchOrigin.X += 5 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y += 15;
                    }
                }

                floodedCavesEnd_2 = blotchOrigin;
            }

            else if (sideCaves == 5)
            {
                blotchOrigin.X -= 10 * (dungeonLeftSide ? -1 : 1);
                blotchOrigin.Y -= 5;

                for (int i = 0; i < 8; i++)
                {
                    WorldUtils.Gen(blotchOrigin, new Shapes.Circle(caveRadiusX, caveRadiusY), Actions.Chain(new GenAction[]
                    {
                        new Modifiers.Blotches(),
                        new Actions.ClearTile(true),
                        new Actions.PlaceWall((ushort)WallType<BasaltWall>(), true),
                        new Actions.SetLiquid(LiquidID.Water),
                        new Actions.Smooth(true)
                    }));

                    if (i < 2)
                    {
                        blotchOrigin.X -= 6 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y -= 4;
                    }

                    else if (i < 6)
                        blotchOrigin.X -= 6 * (dungeonLeftSide ? -1 : 1);

                    else if (i == 6)
                    {
                        blotchOrigin.X -= 10 * (dungeonLeftSide ? -1 : 1);
                        blotchOrigin.Y -= 6;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }

                    else if (i == 7)
                        PlaceCaveChest(blotchOrigin.X, blotchOrigin.Y, sideCaves);
                }
            }
        }

        private static void PlaceCaveChest(int xPos, int yPos, int sideCave)
        {
            // The actual making of the Chests. Initially it was going to be put on the floor, but the thing I was doing before wasn't working, causing it to be floating
            // I decided "Fuck it. It's a feature now." And yeah, that's chests being placed...
            // Also thanks tModLoader community for giving me a list of chest styles... yeah no that's a lie, so was everything else
            WorldGen.PlaceTile(xPos, yPos, TileType<BasaltTile>(), true, true);
            WorldGen.PlaceTile(xPos + 1, yPos, TileType<BasaltTile>(), true, true);

            int chestIndex = WorldGen.PlaceChest(xPos, yPos - 1, style: 17); // This one line took too long... now I know and it hurts...
            if (chestIndex != -1)
            {
                // How we place things in that chest we just made...
                Chest chest = Main.chest[chestIndex];
                var itemsToAdd = new List<(int type, int stack)>();

                switch (sideCave)
                {
                    case 0:
                        itemsToAdd.Add((ItemID.WaterWalkingBoots, 1));
                        break;
                    case 1:
                        itemsToAdd.Add((ItemID.DivingHelmet, 1));
                        break;
                    case 2:
                        itemsToAdd.Add((ItemID.JellyfishNecklace, 1));
                        break;
                    case 3:
                        itemsToAdd.Add((ItemID.Flipper, 1));
                        break;
                    case 5:
                        itemsToAdd.Add((ItemID.GillsPotion, 1));
                        break;
                }

                itemsToAdd.Add((ItemID.Glowstick, Main.rand.Next(9, 15)));

                switch (Main.rand.Next(4))
                {
                    case 0:
                        itemsToAdd.Add((ItemID.Grenade, Main.rand.Next(3, 6)));
                        break;
                    case 1:
                        itemsToAdd.Add((ItemID.LesserHealingPotion, Main.rand.Next(3, 6)));
                        break;
                    case 2:
                        itemsToAdd.Add((ItemID.SilverCoin, Main.rand.Next(10, 20)));
                        break;
                    case 3:
                        itemsToAdd.Add((ItemID.Dynamite, Main.rand.Next(1, 3)));
                        itemsToAdd.Add((ItemID.Bomb, Main.rand.Next(3, 7)));
                        break;
                }

                int chestItemIndex = 0;
                foreach (var (type, stack) in itemsToAdd)
                {
                    Item item = new();
                    item.SetDefaults(type);
                    item.stack = stack;
                    chest.item[chestItemIndex] = item;
                    chestItemIndex++;
                    if (chestItemIndex >= 40)
                        break;
                }
            }
        }

        public static void GenerateCorruptedAbyss(Point blotchOriginA, Point blotchOriginB, bool dungeonLeftSide)
        {

        }
    }
}

// Welcome to the bottom... Yeah this is long... Hours of my life gone because of this, but hey, it's fun to do this and hone my skills as a programmer
// Now I go to bed...