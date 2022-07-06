using XtraTerraria.Content.Items.Placeables.Tiles;
using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace XtraTerraria.Content.Placeables.Tiles
{
	public class BasaltTile : ModTile
	{
		public override string Texture => AssetPathTextures + "Placeables/Tiles/BasaltTile";

        public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			DustType = DustID.Stone;
			HitSound = SoundID.Tink;
			ItemDrop = ModContent.ItemType<Basalt>();
			AddMapEntry(new Color(200, 200, 200));
			//SetModTree(new Trees.ExampleTree());
		}

		/*public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}

		public override void ChangeWaterfallStyle(ref int style)
		{
			style = mod.GetWaterfallStyleSlot("ExampleWaterfallStyle");
		}
		 

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return ModContent.TileType<ExampleSapling>();
		}*/
	}
}