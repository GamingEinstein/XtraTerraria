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
    public class Endoflare : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Weapons/Mage/Endoflare";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endoflare");
            Tooltip.SetDefault("Shoots a spread of Ice Bolts");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 7;
            Item.width = 48;
            Item.height = 52;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item25;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.IceBolt;
            Item.shootSpeed = 24f;
            Item.crit = 6;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BorealWood, 20)
                .AddIngredient(ItemID.IceBlock, 15)
                .AddIngredient(ItemID.Shiverthorn, 5)
                .AddIngredient(ItemID.FallenStar, 3)
                .AddIngredient(ItemID.CyanHusk, 1)
                //.AddIngredient<FrigidEssence>()
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(20f);
            position += Vector2.Normalize(velocity) * 20f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        // TODO: Make the projectiles shoot from the top corner of the staff
        /*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 topOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + topOffset, 0, 0))
                position += topOffset;
        }*/

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3f, -3f);
        }
    }
}
