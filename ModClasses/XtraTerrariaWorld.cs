using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.ModClasses
{
    public class XtraTerrariaWorld : ModSystem
    {
		public static bool JustPressed(Keys key)
		{
			return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
		}

		public override void PostUpdateEverything()
		{
			if (JustPressed(Keys.PageUp))
				TestMethod(200, 0);
			if (JustPressed(Keys.PageDown))
				TestMethod(Main.maxTilesX - 200, 0);
		}

		private static void TestMethod(int worldX, int worldY)
		{
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
						XtraTerrariaGeneration.GenerateFloodedCaves(worldX, worldY, dungeonSide);

					break;
				}
				worldY++;
			}
		}
	}
}
