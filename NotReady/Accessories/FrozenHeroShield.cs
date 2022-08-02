/*using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class FrozenHeroShield : ModItem
    {
        public override string Texture => AssetPathTextures + "Items/Accessories/FrozenHeroShield";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Hero Shield");
            Tooltip.SetDefault("Grant Immunity to knockback" +
                "\nPuts a shell around the owner when below 50% life that reduces damage by 25%" +
                "\nAbsorbs 25% of damage done to players on your team when above 25% life" +
                "\nEnemies are more likely to target you");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 40;
            Item.value = Item.buyPrice(silver: 5);
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }
    }
}
*/