using XtraTerraria.Content.Placeables.Tiles;
using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Placeables.Tiles
{
    public class BasaltItem : ModItem
    {
		public override string Texture => AssetPathTextures + "Items/Placeables/Tiles/BasaltItem";
        
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Basalt");
        }

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = TileType<BasaltTile>();
		}
	}
}
