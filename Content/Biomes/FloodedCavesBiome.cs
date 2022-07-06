using XtraTerraria.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XtraTerraria.Content.Biomes
{
    public class FloodedCavesBiome : ModBiome
    {
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("XtraTerraria/Content/Biomes/FloodedCavesBGStyle");

        //public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/FloodedCaves");
        public override int Music => MusicID.OtherworldlyOcean;

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
                ModContent.GetInstance<BiomeTileCount>().floodedCavesTileCount >= 150;
        }
    }
}
