using XtraTerraria.Content.Items.Placeables.Walls;
using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Placeables.Walls
{
    public class BasaltWall : ModWall
    {
		public override string Texture => AssetPathTextures + "Placeables/Walls/BasaltWall";

		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			Main.updateRate = 999;
			
			DustType = DustID.Stone;
			ItemDrop = ItemType<BasaltWallItem>();

			AddMapEntry(new Color(24, 24, 24));
		}

        public override void RandomUpdate(int i, int j)
        {
			Tile tile = Main.tile[i, j];
			tile.LiquidType = LiquidID.Water;
			tile.LiquidAmount = 255;
			WorldGen.TileFrame(i, j);
		}
    }
}
