using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Weapons.Ranger
{
    public class RottenCrossbow : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Weapons/Ranger/RottenCrossbow";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rotten Crossbow");
            Tooltip.SetDefault("Converts Wooden Arrows to Unholy Arrows");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 30;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 16;
            Item.knockBack = 2;
            Item.rare = ItemRarityID.White;
            Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 16f;
            Item.useAmmo = AmmoID.Arrow;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item39;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.RottenChunk, 12)
                .AddIngredient(ItemID.Ebonwood, 20)
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
                type = ProjectileID.UnholyArrow;
        }
    }
}