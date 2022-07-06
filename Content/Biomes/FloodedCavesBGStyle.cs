using static XtraTerraria.ModClasses.XtraTerraria;
using Terraria.ModLoader;

namespace XtraTerraria.Backgrounds
{
    public class FloodedCavesBGStyle : ModUndergroundBackgroundStyle
    {
		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot(Mod, AssetPathTextures + "Backgrounds/FloodedCavesBG0");
			textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot(Mod, AssetPathTextures + "Backgrounds/FloodedCavesBG1");
			textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot(Mod, AssetPathTextures + "Backgrounds/FloodedCavesBG2");
			textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot(Mod, AssetPathTextures + "Backgrounds/FloodedCavesBG3");
		}
	}
}
