using XtraTerraria.Content.Items.Placeables.Tiles;
using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			ItemDrop = ItemType<BasaltItem>();
			AddMapEntry(new Color(41, 40, 38));
		}
	}
}