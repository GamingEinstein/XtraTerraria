using XtraTerraria.Common.Systems;
using XtraTerraria.Content.Items.Consumables;
//using XtraTerraria.Content.NPCs.Bosses;
using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.ModClasses
{
	public class XtraTerraria : Mod
	{
		public const string AssetPath = $"{nameof(XtraTerraria)}/Assets/";
		public const string AssetPathTextures = AssetPath + "Textures/";

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                /*bossChecklist.Call("AddBoss", //Yes
                    this, //ModInstance
                    "Zephyrus, Giver of Hydration", //Boss Name
                    NPCType<Zephyrus>(), //Boss ID
                    6.1f, //Slot in progression
                    (Func<bool>)(() => DownedBossSystem.downedZephyrus), //Downed Boolean
                    () => true, //Always shown or nah
                    petsHere, //Collection
                    ItemType<CalamariBait>(), //Spawn Items
                    $"Use [i:ItemType<CalamariBait>()] in the Flooded Caves");*/ //Spawn Info
            }
        }
    }
}