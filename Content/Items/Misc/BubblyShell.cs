using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Misc
{
    public class BubblyShell : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Misc/BubblyShell";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bubbly Shell");
            Tooltip.SetDefault("Somehow it can keep producing bubbles... Probably best not to ask");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(copper: 20);
        }
    }
}
