
using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XtraTerraria.Content.Items.Consumables
{
    public class PureVenom : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Consumables/PureVenom";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pure Venom");
            Tooltip.SetDefault("Not recommended to be eaten");
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(12, 30, BuffID.Venom, (60 * 15), true);
            Item.rare = ItemRarityID.White;
        }
    }
}
