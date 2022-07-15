using XtraTerraria.Common.Configs;
using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Weapons.Melee
{
    public class DevSword : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Weapons/Melee/DevSword";

        public override bool IsLoadingEnabled(Mod mod)
        {
            return GetInstance<XtraTerrariaConfig>().DevSwordToggle;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dev Sword");
            Tooltip.SetDefault("Basic Modded Sword and such");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(copper: 1);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
    }
}