using static XtraTerraria.ModClasses.XtraTerraria;
using static XtraTerraria.ModClasses.XtraTerrariaGeneration;
using static XtraTerraria.ModClasses.XtraTerrariaGenerationHelpers;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.ModClasses
{
    public class XtraTerrariaWorld : ModSystem
    {
        // Everything here is only a placeholder for testing the generation of the biome. It's recommended to not mess with it...

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
			int MicroBiomesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));

			if (MicroBiomesIndex != -1)
				tasks.Insert(MicroBiomesIndex + 1, new PassLegacy("Expanding the Ocean", OceanExpanding));
        }

		private void OceanExpanding(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Expanding the Ocean";

			int worldX = 175;
			int worldY = 0;

			// Gets the side the Dungeon is on...
			bool dungeonLeftSide;

			if (Main.dungeonX > Main.maxTilesX / 2)
				dungeonLeftSide = false;
			else
				dungeonLeftSide = true;

			// Change worldX to be on right side if Dungeon is on the left side
			if (dungeonLeftSide)
				worldX = Main.maxTilesX - worldX;

			// Checks until we reach the Beach surface... or the world surface, I guess...
			while (worldY < Main.worldSurface)
			{
				if (WorldGen.SolidTile(worldX, worldY))
				{
					Tile foundTile = Framing.GetTileSafely(worldX, worldY);
					if (foundTile.TileType == TileID.Sand || foundTile.TileType == TileID.HardenedSand || foundTile.TileType == TileID.ShellPile)
					{
						// Generate our Biome... yay
						GenerateFloodedCaves(worldX, worldY, dungeonLeftSide);
						//GenerateCorruptedAbyss(floodedCavesEnd_1, floodedCavesEnd_2);
					}

					break;
				}
				worldY++;
			}
		}
	}
}
