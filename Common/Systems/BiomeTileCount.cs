using XtraTerraria.Content.Placeables.Tiles;
using System;
using Terraria.ModLoader;

namespace XtraTerraria.Common.Systems
{
    public class BiomeTileCount : ModSystem
    {
        public int floodedCavesTileCount;
        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            floodedCavesTileCount = tileCounts[ModContent.TileType<BasaltTile>()];
        }
    }
}
