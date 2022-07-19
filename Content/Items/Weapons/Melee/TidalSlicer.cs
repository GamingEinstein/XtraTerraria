using XtraTerraria.Content.Items.Misc;
using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Weapons.Melee
{
    public class TidalSlicer : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Weapons/Melee/TidalSlicer";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tidal Slicer");
            Tooltip.SetDefault("Shoots a stream of water");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.crit = 2;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WaterStream;
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Coral, 3)
                .AddIngredient(ItemID.Seashell, 5)
                .AddIngredient<BubblyShell>(7)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(5))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Water);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Wet, 10);
        }
    }
}
