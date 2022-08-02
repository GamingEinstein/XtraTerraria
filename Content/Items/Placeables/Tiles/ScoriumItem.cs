using XtraTerraria.Content.Placeables.Tiles;
using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Placeables.Tiles
{
    public class ScoriumItem : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Placeables/Tiles/ScoriumItem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scorium");
            Tooltip.SetDefault("Hot Rocks (TM)");
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
            Item.createTile = TileType<ScoriumTile>();
            Item.value = Item.buyPrice(silver: 50);
        }
    }
}
