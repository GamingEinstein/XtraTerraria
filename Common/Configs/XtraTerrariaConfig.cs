using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace XtraTerraria.Common.Configs
{
    public class XtraTerrariaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.XtraTerraria.Config.TestFeaturesHeader")]

        [Label("$Mods.XtraTerraria.Config.ToggleTestGeneration.Label")]
        [Tooltip("$Mods.XtraTerraria.Config.ToggleTestGeneration.Tooltip")]
        [DefaultValue(false)]
        public bool ToggleTestGeneration;

    }
}
