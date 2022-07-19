using XtraTerraria.Content.Biomes;
using XtraTerraria.Content.Items.Consumables;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;

namespace XtraTerraria.Content.NPCs
{
    public class XtraTerrariaGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.BlackRecluse || npc.type == NPCID.BlackRecluseWall)
                npcLoot.Add(ItemDropRule.Common(ItemType<PureVenom>(), 3, 1, 4));
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(GetInstance<FloodedCavesBiome>()))
                pool.Add(NPCID.PinkJellyfish, SpawnCondition.CaveJellyfish.Chance);
        }
    }
}
