using XtraTerraria.Content.Projectiles;
using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Weapons.Mage
{
    public class PebblePelter : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Weapons/Mage/PebblePelter";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pebble Pelter");
            Tooltip.SetDefault("Shoots 3 pebbles at different angles");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 4;
            Item.width = 28;
            Item.height = 32;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item25;
            Item.autoReuse = true;
            Item.shoot = ProjectileType<PebblePelterPebble>();
            Item.shootSpeed = 24f;
            Item.crit = 6;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Leather)
                .AddIngredient(ItemID.StoneBlock, 20)
                .AddIngredient(ItemID.FallenStar, 3)
                .AddTile(TileID.Bookcases)
                .Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(22.5f);
            position += Vector2.Normalize(velocity) * 22.5f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}
