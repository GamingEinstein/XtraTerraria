using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace XtraTerraria.Common.Systems
{
	// Acts as a container for "downed boss" flags.
	// Set a flag like this in your bosses OnKill hook:
	//    NPC.SetEventFlagCleared(ref downedBoss, -1);

	public class DownedBossSystem : ModSystem
	{
		public static bool downedZephyrus = false;

		public override void OnWorldLoad()
		{
			downedZephyrus = false;
		}

		public override void OnWorldUnload()
		{
			downedZephyrus = false;
		}

		public override void SaveWorldData(TagCompound tag)
		{
			if (downedZephyrus)
			{
				tag["downedMinionBoss"] = true;
			}
		}

		public override void LoadWorldData(TagCompound tag)
		{
			downedZephyrus = tag.ContainsKey("downedZephyrus");
		}

		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte(downedZephyrus);
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedZephyrus = flags[0];
		}
	}
}