using XtraTerraria.Content.Items.Placeables.Tiles;
using XtraTerraria.Content.Placeables.Walls;
using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Placeables.Walls
{
	public class BasaltWallItem : ModItem
	{
		public override string Texture => AssetPathTextures + "Items/Placeables/Walls/BasaltWallItem";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Basalt Wall");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 7;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createWall = WallType<BasaltWall>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(4)
				.AddIngredient<BasaltItem>()
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}