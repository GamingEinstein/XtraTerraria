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
			Main.wallHouse[Type] = true;

			DustType = DustID.Stone;
			ItemDrop = ItemType<BasaltWallItem>();

			AddMapEntry(new Color(125, 125, 125));
		}
	}
}
