using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace XtraTerraria.Common.Configs
{
    public class XtraTerrariaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.XtraTerraria.Config.ItemHeader")]
        [Label("$Mods.XtraTerraria.Config.DevSwordToggle.Label")]
        [Tooltip("$Mods.XtraTerraria.Config.DevSwordToggle.Tooltip")]
        [DefaultValue(true)]
        [ReloadRequired]

        public bool DevSwordToggle;
    }
}
