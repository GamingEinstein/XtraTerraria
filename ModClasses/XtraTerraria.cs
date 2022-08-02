using XtraTerraria.Common.Systems;
using XtraTerraria.Content.Items.Consumables;
using XtraTerraria.Content.NPCs.Bosses;
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
            // We call Boss Checklist to add our bosses to that mod. It's quite cool...
            if (ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist))
            {
                bossChecklist.Call("AddBoss", // Yes
                    this, // ModInstance
                    "Zephyrus, Giver of Hydration", // Boss Name
                    NPCType<Zephyrus>(), // Boss ID
                    6.1f, // Slot in progression
                    () => DownedBossSystem.downedZephyrus, // Downed Boolean
                    () => true, // Always shown or nah
                    null, // Collection
                    null, // ItemType<CalamariBait>(), // Spawn Items
                    $"Use Cheat Sheet because ye..."); // Spawn Info
            }
        }
    }
}