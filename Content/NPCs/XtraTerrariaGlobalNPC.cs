using XtraTerraria.Content.Items.Misc;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.NPCs
{
    public class XtraTerrariaGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.BlackRecluse || npc.type == NPCID.BlackRecluseWall)
                npcLoot.Add(ItemDropRule.Common(ItemType<PureVenom>(), 3, 1, 4));
        }
    }
}
