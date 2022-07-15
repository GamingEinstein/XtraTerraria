using static XtraTerraria.ModClasses.XtraTerrariaGeneration;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.ModClasses
{
    public class XtraTerrariaWorld : ModSystem
    {

		//Everything here is only a placeholder for testing the generation of the biome. It's recommended to not mess with it...
		public static bool JustPressed(Keys key)
		{
			return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
		}

		public override void PostUpdateEverything()
		{
			if (JustPressed(Keys.PageUp))
			{
				Main.NewText("Woah there. You have discovered a test feature! It is not recommended to continue beyond this point as it could break things." +
					"\nIf you're really curious, go ahead and press the Pause button on your Keyboard... I'm not responsible for what could happen...");
				if (JustPressed(Keys.Pause))
					TestMethod(200, 0);
			}
			/*if (JustPressed(Keys.PageDown))
				TestMethod(Main.maxTilesX - 200, 0);*/
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
						GenerateFloodedCaves(worldX, worldY, dungeonSide);

					break;
				}
				worldY++;
			}
		}
	}
}
