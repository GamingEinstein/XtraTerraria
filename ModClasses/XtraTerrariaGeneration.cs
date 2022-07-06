using XtraTerraria.Content.Placeables.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

//I'm keeping most of this until I know for that I don't need them...

namespace XtraTerraria.ModClasses
{
    public class XtraTerrariaGeneration : ModSystem
    {
        //I would just like to note I coded most of this stuff in the middle of the night, the night before I have to work the next day... Genius I am...

        //Currently only works on the right side of the world. Need to make another version of the for-loop for the left side... yay...
        //Also no testing has been done on non-small worlds. That also needs something done...
        public static void GenerateFloodedCaves(int worldX, int worldY, int dungeonSide)
        {
            int biomeWidth = 0;
            int biomeWidthMax = 200;
            int biomeHeight = 0;
            int biomeHeightMax = 200;
            int beachBottomCheck = worldY;

            //Checks until we find the next tile that isn't sand (basically, get the beach bottom)
            while (beachBottomCheck < Main.worldSurface + 250)
            {
                Tile foundTile = Framing.GetTileSafely(worldX, beachBottomCheck);
                if (foundTile.TileType == TileID.Dirt || foundTile.TileType == TileID.Stone || foundTile.TileType == TileID.ClayBlock)
                    break;

                beachBottomCheck++;
            }

            //Generating the blocks for the biome...
            for (int i = 0; i <= biomeWidthMax; i++)
            {
                for (int j = 0; j <= biomeHeightMax; j++)
                {
                    int xPos = worldX - (biomeWidthMax / 2) + i;
                    int yPos = beachBottomCheck + j;

                    //Check if it isn't sand from the beach essentially
                    Tile tileCheck = Framing.GetTileSafely(xPos, yPos);
                    if ((tileCheck.TileType != TileID.Sand &&
                        tileCheck.TileType != TileID.HardenedSand &&
                        tileCheck.TileType != TileID.ShellPile) ||
                        yPos > beachBottomCheck + 25)
                    {
                        WorldGen.PlaceTile(xPos, yPos, TileType<BasaltTile>(), true, true, -1, 0);
                        tileCheck = Framing.GetTileSafely(xPos, yPos);
                        if(tileCheck.Slope != 0)
                            WorldGen.SlopeTile(xPos, yPos, 0);

                        //Since I'm dumb, I'm running a Tile Runner on the edges so that I can get some form of blending of blocks...
                        if ((i == 0 || i == biomeWidthMax) || (j == 0 || j == biomeHeightMax))
                            WorldGen.TileRunner(xPos, yPos, WorldGen.genRand.Next(32, 64), 3, TileType<BasaltTile>(), true, 0, 0, false, true);
                    }
                    biomeHeight++;
                }
                biomeWidth++;
            }

            //Make the enterance
            WorldGen.digTunnel(worldX, worldY, 0, 5, 15, 10, true);

            //Cave generation... yeah I actually need someone to teach me that, since no one wants to give that information publicly
        }
    }
}
