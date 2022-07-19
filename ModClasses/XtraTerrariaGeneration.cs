using Microsoft.Xna.Framework;
using XtraTerraria.Content.Placeables.Tiles;
using XtraTerraria.Content.Placeables.Walls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.ModClasses
{
    public class XtraTerrariaGeneration : ModSystem
    {
        public static void GenerateFloodedCaves(int worldX, int worldY, int dungeonSide)
        {
            int biomeWidth = 0;
            int biomeWidthMax = 250;
            int biomeHeight = 0;
            int biomeHeightMax = 250;
            int beachBottomCheck = worldY;
            int sideCaves = 0;

            //Checks until we find the next tile that isn't sand (basically, get the beach bottom)
            while (beachBottomCheck < Main.worldSurface + 250)
            {
                Tile foundTile = Framing.GetTileSafely(worldX, beachBottomCheck);
                if (foundTile.TileType == TileID.Dirt || foundTile.TileType == TileID.Stone || foundTile.TileType == TileID.ClayBlock || !foundTile.HasTile)
                    break;

                beachBottomCheck++;
            }

            //Generating the blocks for the biome...
            for (int i = 0; i <= biomeWidthMax; i++)
            {
                for (int j = 0; j <= biomeHeightMax; j++)
                {
                    int xPos = worldX - ((biomeWidthMax - 50) / 2) + i;
                    int yPos = beachBottomCheck + 25 + j;

                    //Check if it isn't sand from the beach essentially
                    Tile tileCheck = Framing.GetTileSafely(xPos, yPos);
                    if ((tileCheck.TileType != TileID.Sand &&
                        tileCheck.TileType != TileID.HardenedSand &&
                        tileCheck.TileType != TileID.Sandstone) ||
                        yPos >= Main.worldSurface + 25)
                    {
                        WorldGen.PlaceTile(xPos, yPos, TileType<BasaltTile>(), true, true, -1, 0);
                        WorldGen.KillWall(xPos, yPos);
                        WorldGen.PlaceWall(xPos, yPos, WallType<BasaltWall>(), true);
                        tileCheck = Framing.GetTileSafely(xPos, yPos);
                        if (tileCheck.Slope != SlopeType.Solid)
                            WorldGen.SlopeTile(xPos, yPos, 0);

                        //Since I'm dumb, I'm running a Tile Runner on the edges so that I can get some form of blending of blocks...
                        if ((i == 0 || i == biomeWidthMax) || (j == 0 || j == biomeHeightMax))
                            WorldGen.TileRunner(xPos, yPos, WorldGen.genRand.Next(32, 64), 3, TileType<BasaltTile>(), true);
                    }
                    biomeHeight++;
                }
                biomeWidth++;
            }

            for (int i = 0; i < 30; i++)
            {
                int xPos = WorldGen.genRand.Next(worldX - ((biomeWidthMax - 50) / 2), worldX + ((biomeWidthMax + 50) / 2));
                int yPos = WorldGen.genRand.Next(worldY + ((biomeHeightMax + 50) / 2), worldY + (biomeHeightMax + 50));

                WorldGen.TileRunner(xPos, yPos, 10, 5, TileID.Obsidian);
            }

            //Make the enterance
            WorldGen.digTunnel(worldX, worldY, 0, 5, 20, 10, true);
            WorldGen.EveryTileFrame();

            //Cave generation... yeah I actually need someone to teach me that, since no one wants to give that information publicly
            //Instead of having someone actually teach me that, I'm using blotches a lot to make it look somewhat like a cave... I guess... It does work tho...
            //Pain btw... much pain... massive pain... kill me rn please... help... im locked in a basement... this is mostly a joke...
            Point blotchOrigin = new Point(worldX + 5, worldY + 60);
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

                if (i < 10)
                {
                    if (i < 5)
                    {
                        blotchOrigin.X += 5;
                        blotchOrigin.Y += 10;
                        if (i < 2)
                        {
                            caveRadiusX -= 1;
                            caveRadiusY -= 1;
                        }
                        if (i == 2)
                        {
                            GenerateSideCave(blotchOrigin, sideCaves);
                            sideCaves++;
                        }
                    }
                    else
                    {
                        blotchOrigin.X += 15;
                        blotchOrigin.Y += WorldGen.genRand.Next(2, 5);
                    }
                }
                else if (i > 9 && i < 13)
                    blotchOrigin.Y += 17;
                else if (i < 20)
                {
                    if (i == 13)
                    {
                        GenerateSideCave(blotchOrigin, sideCaves);
                        sideCaves++;
                    }
                    blotchOrigin.X -= 15;
                    blotchOrigin.Y += WorldGen.genRand.Next(2, 5);
                }
                else if (i < 25)
                {
                    if (i == 20)
                    {
                        GenerateSideCave(blotchOrigin, sideCaves);
                        sideCaves++;
                    }
                    if (i < 22)
                    {
                        caveRadiusX -= 1;
                        caveRadiusY -= 1;
                    }
                    blotchOrigin.X += 2;
                    blotchOrigin.Y += 13;
                    if (i == 21)
                    {
                        GenerateSideCave(blotchOrigin, sideCaves);
                        sideCaves++;
                    }
                }
                else if (i < 30)
                {
                    blotchOrigin.X -= 8;
                    blotchOrigin.Y -= 8;
                }
                else if (i < 40)
                {
                    if (i < 32)
                    {
                        blotchOrigin.X -= 8;
                        blotchOrigin.Y += 5;
                    }
                    else
                    {
                        if (i < 28)
                        {
                            caveRadiusX -= 1;
                            caveRadiusY -= 1;
                        }
                        blotchOrigin.X += 3;
                        blotchOrigin.Y += 10;
                    }
                }
                else if (i < 45)
                {
                    blotchOrigin.X += 8;
                    blotchOrigin.Y += 1;
                }
            }
        }

        private static void GenerateSideCave(Point blotchOrigin, int sideCaves)
        {
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
                        blotchOrigin.X -= 6;
                        blotchOrigin.Y += 4;
                    }
                    else if (i < 6)
                        blotchOrigin.X -= 6;
                    else if (i == 6)
                    {
                        blotchOrigin.X -= 10;
                        blotchOrigin.Y -= 6;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }
                }
            }
            else if (sideCaves == 1)
            {
                blotchOrigin.X += 10;
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
                        blotchOrigin.X += 6;
                        blotchOrigin.Y += 4;
                    }
                    else if (i < 6)
                        blotchOrigin.X += 6;
                    else if (i == 6)
                    {
                        blotchOrigin.X += 10;
                        blotchOrigin.Y -= 10;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }
                }
            }
            else if (sideCaves == 2)
            {
                blotchOrigin.X -= 15;
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
                        blotchOrigin.X -= 6;
                        blotchOrigin.Y -= 4;
                    }
                    else if (i < 6)
                        blotchOrigin.X -= 6;
                    else if (i == 6)
                    {
                        blotchOrigin.X -= 10;
                        blotchOrigin.Y -= 6;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }
                }
            }
            else if (sideCaves == 3)
            {
                blotchOrigin.X += 15;

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
                        blotchOrigin.X += 6;
                        blotchOrigin.Y += 4;
                    }
                    else if (i < 6)
                        blotchOrigin.X += 6;
                    else if (i == 6)
                    {
                        blotchOrigin.X += 10;
                        blotchOrigin.Y -= 10;
                        caveRadiusX = 10;
                        caveRadiusY = 10;
                    }
                }
            }
        }
    }
}
