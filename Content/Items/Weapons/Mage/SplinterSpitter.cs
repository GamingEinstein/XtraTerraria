using XtraTerraria.Content.Projectiles;
using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Weapons.Mage
{
    public class SplinterSpitter : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Weapons/Mage/SplinterSpitter";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Splinter Spitter");
            Tooltip.SetDefault("Fires splinters at your enemies");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 5;
            Item.width = 36;
            Item.height = 34;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item25;
            Item.autoReuse = true;
            Item.shoot = ProjectileType<SplinterSpitterSplinter>();
            Item.shootSpeed = 10f;
            Item.crit = 6;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BorealWood, 10)
                .AddIngredient(ItemID.FallenStar)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
