using XtraTerraria.Content.Items.Placeables.Walls;
using XtraTerraria.Content.Placeables.Tiles;
using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.GameContent.Creative;
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
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = TileType<BasaltTile>();
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient<BasaltWallItem>(4)
				.AddTile(TileID.WorkBenches)
				.Register();
        }
    }
}
