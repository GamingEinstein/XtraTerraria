using XtraTerraria.Content.Placeables.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XtraTerraria.Content.Items.Placeables.Tiles
{
    public class Basalt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Basalt");
			//Tooltip.SetDefault("From the depths of the ocean");

			/*Possibly at some point we could get community translations?
			 *DisplayName.AddTranslation(LangID."Name", "String");
			 *Tooltip.AddTranslation(LangId."Name", "String");
			 */
        }

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<BasaltTile>();
		}
		/* If we need to get the Extractinator thing
		 * public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{
			if (Main.rand.NextBool(30))
			{
				resultType = ModContent.ItemType<FoulOrb>();
				if (Main.rand.NextBool(5))
				{
					resultStack += Main.rand.Next(2);
				}
			}
		}*/

	}
}
