using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria
{
    public class XtraTerrariaWorld : ModSystem
    {
		public static bool JustPressed(Keys key)
		{
			return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
		}

		public override void PostUpdateEverything()
		{
			if (JustPressed(Keys.Pause))
			{
				if (Main.dungeonX > Main.maxTilesX / 2)
					TestMethod(200, 0);
				else
					TestMethod(Main.maxTilesX - 200, 0);
				
			}
		}

		private void TestMethod(int worldX, int worldY)
		{
			bool foundBeach = false;
			int dungeonSide;
			if (Main.dungeonX > Main.maxTilesX / 2)
				dungeonSide = 0;
			else
				dungeonSide = 1;

				while (worldY < Main.worldSurface)
				{
					if (WorldGen.SolidTile(worldX, worldY))
					{
						Tile foundTile = Framing.GetTileSafely(worldX, worldY);
						if (foundTile.TileType == TileID.Sand || foundTile.TileType == TileID.HardenedSand || foundTile.TileType == TileID.ShellPile)
						{
							foundBeach = true;
							WorldGen.PlaceTile(worldX, worldY, TileID.LunarOre, true, true);
							if (foundBeach)
								Main.NewText($"Location Found: {worldX},{worldY}");
							else
								Main.NewText($"Location Not Found");

							XtraTerrariaGeneration.GenerateFloodedCaves(worldX, worldY, dungeonSide);
						}
						break;
					}
					worldY++;
				}
		}
	}
}
