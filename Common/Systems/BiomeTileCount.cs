using System;
using XtraTerraria.Content.Placeables.Tiles;
using Terraria.ModLoader;

namespace XtraTerraria.Common.Systems
{
    public class BiomeTileCount : ModSystem
    {
        public int basaltTileCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            basaltTileCount = tileCounts[ModContent.TileType<BasaltTile>()];
        }
    }
}
