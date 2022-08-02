using XtraTerraria.Content.Items.Placeables.Tiles;
using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Placeables.Tiles
{
    public class ScoriumTile : ModTile
	{
		public override string Texture => AssetPathTextures + "Placeables/Tiles/ScoriumTile";

        public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileMerge[Type][Mod.Find<ModTile>("BasaltTile").Type] = true;
			DustType = DustID.Stone;
			HitSound = SoundID.Tink;
			ItemDrop = ItemType<ScoriumItem>();
			AddMapEntry(new Color(255, 193, 51));
		}

        public override void FloorVisuals(Player player)
        {
			player.AddBuff(BuffID.OnFire, 60);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = .5f;
			b = 0f;
        }
    }
}
