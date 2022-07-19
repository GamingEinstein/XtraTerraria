using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Weapons.Melee
{
    public class ArachnidsFang : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Weapons/Melee/ArachnidsFang";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arachnid's Fang");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 2, 75, 0);
            Item.autoReuse = true;
            SacrificeTotal = 1;
            Item.damage = 55;
            Item.knockBack = 6;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpiderFang, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            target.AddBuff(BuffID.Venom, (60 * 10));
        }
    }
}
