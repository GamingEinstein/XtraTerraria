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
            Tooltip.SetDefault("It's literally venom... You probably shouldn't eat it...");
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(18, 32, BuffID.Venom, (60 * 15), true);
            Item.rare = ItemRarityID.White;
        }
    }
}
