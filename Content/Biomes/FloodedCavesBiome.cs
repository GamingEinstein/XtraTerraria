using static XtraTerraria.ModClasses.XtraTerraria;
using XtraTerraria.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Biomes
{
    public class FloodedCavesBiome : ModBiome
    {
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => Find<ModUndergroundBackgroundStyle>("XtraTerraria/FloodedCavesBGStyle");

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/Biomes/FloodedCaves");

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => base.BackgroundPath;
        public override Color? BackgroundColor => base.BackgroundColor;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flooded Caves");
        }

        public override bool IsBiomeActive(Player player)
        {
            return (player.ZoneDirtLayerHeight &&
                player.ZoneBeach) &&
                GetInstance<BiomeTileCount>().floodedCavesTileCount >= 150;
        }
    }
}
