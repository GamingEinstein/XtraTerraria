using XtraTerraria.Content.Biomes;
using XtraTerraria.Content.Items.Consumables;
using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.NPCs.Biomes.FloodedCaves
{
    public class YetiCrab : ModNPC
    {
        public override string Texture => AssetPathTextures + "NPCs/Biomes/FloodedCaves/YetiCrab";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yeti Crab");
            Main.npcFrameCount[Type] = 8;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Crab);
            NPC.width = 44;
            NPC.height = 32;

            AIType = NPCID.Crab;
            AnimationType = NPCID.Crab;
            Banner = Item.NPCtoBanner(NPCID.Crab);
            BannerItem = Item.BannerToItem(Banner);
            SpawnModBiomes = new int[1] { GetInstance<FloodedCavesBiome>().Type };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(GetInstance<FloodedCavesBiome>()))
                return SpawnCondition.Underground.Chance * 2f;

            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new FlavorTextBestiaryInfoElement("A crab found in the deep parts of the ocean. It gets its name from its pigmentation being similar to that of the Yeti"),
                new BestiaryPortraitBackgroundProviderPreferenceInfoElement(GetInstance<FloodedCavesBiome>().ModBiomeBestiaryInfoElement),
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemType<BubblyShell>(), 5, 1));
        }
    }
}
