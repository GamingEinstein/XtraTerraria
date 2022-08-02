using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace XtraTerraria.Common.Configs
{
    public class XtraTerrariaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.XtraTerraria.Config.TestFeaturesHeader")]

        [Label("$Mods.XtraTerraria.Config.ToggleTest.Label")]
        [Tooltip("$Mods.XtraTerraria.Config.ToggleTest.Tooltip")]
        [DefaultValue(false)]
        public bool ToggleTest;

    }
}
