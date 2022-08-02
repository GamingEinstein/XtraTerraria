using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 30;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Item.buyPrice(silver: 5);
            Item.UseSound = SoundID.BloodZombie;
            Item.rare = ItemRarityID.White;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
                player.AddBuff(BuffID.Venom, (60 * 15));

            return true;
        }
    }
}
