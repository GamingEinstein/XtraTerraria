using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace XtraTerraria.Content
{
    public class XtraTerrariaRecipes : ModSystem
    {
        //public static RecipeGroup

        public override void Unload()
        {
            
        }


        // Oh boy... here's a list of things...
        public override void AddRecipes()
        {
            // Converting world evil drops
            Recipe.Create(ItemID.DemoniteOre)
                .AddIngredient(ItemID.CrimtaneOre)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.RottenChunk)
                .AddIngredient(ItemID.Vertebrae)
                .AddTile(TileID.WorkBenches)
                .Register();
            Recipe.Create(ItemID.VileMushroom)
                .AddIngredient(ItemID.ViciousMushroom)
                .AddTile(TileID.WorkBenches)
                .Register();
            Recipe.Create(ItemID.BallOHurt)
                .AddIngredient(ItemID.TheRottedFork)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.Musket)
                .AddIngredient(ItemID.TheUndertaker)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.Vilethorn)
                .AddIngredient(ItemID.CrimsonRod)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.BandofStarpower)
                .AddIngredient(ItemID.PanicNecklace)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.ShadowOrb)
                .AddIngredient(ItemID.CrimsonHeart)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.ShadowScale)
                .AddIngredient(ItemID.TissueSample)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.CrimtaneOre)
                .AddIngredient(ItemID.DemoniteOre)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.Vertebrae)
                .AddIngredient(ItemID.RottenChunk)
                .AddTile(TileID.WorkBenches)
                .Register();
            Recipe.Create(ItemID.ViciousMushroom)
                .AddIngredient(ItemID.VileMushroom)
                .AddTile(TileID.WorkBenches)
                .Register();
            Recipe.Create(ItemID.TheRottedFork)
                .AddIngredient(ItemID.BallOHurt)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.TheUndertaker)
                .AddIngredient(ItemID.Musket)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.CrimsonRod)
                .AddIngredient(ItemID.Vilethorn)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.PanicNecklace)
                .AddIngredient(ItemID.BandofStarpower)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.CrimsonHeart)
                .AddIngredient(ItemID.ShadowOrb)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.TissueSample)
                .AddIngredient(ItemID.ShadowScale)
                .AddTile(TileID.Anvils)
                .Register();

            // Vanilla Emblems
            Recipe.Create(ItemID.WarriorEmblem)
                .AddIngredient(ItemID.RangerEmblem)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.WarriorEmblem)
                .AddIngredient(ItemID.SorcererEmblem)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.WarriorEmblem)
                .AddIngredient(ItemID.SummonerEmblem)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.RangerEmblem)
                .AddIngredient(ItemID.WarriorEmblem)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.RangerEmblem)
                .AddIngredient(ItemID.SorcererEmblem)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.RangerEmblem)
                .AddIngredient(ItemID.SummonerEmblem)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.SorcererEmblem)
                .AddIngredient(ItemID.WarriorEmblem)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.SorcererEmblem)
                .AddIngredient(ItemID.RangerEmblem)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.SorcererEmblem)
                .AddIngredient(ItemID.SummonerEmblem)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.SummonerEmblem)
                .AddIngredient(ItemID.RangerEmblem)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.SummonerEmblem)
                .AddIngredient(ItemID.RangerEmblem)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.SummonerEmblem)
                .AddIngredient(ItemID.SorcererEmblem)
                .AddTile(TileID.Anvils)
                .Register();

            /*// Modded Emblems
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod))
            {
                Recipe.Create(ItemID.WarriorEmblem)
                    .AddIngredient(calamityMod.);
            }*/

            // Wall of Flesh Drops
            Recipe.Create(ItemID.BreakerBlade)
                .AddIngredient(ItemID.ClockworkAssaultRifle)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.BreakerBlade)
                .AddIngredient(ItemID.LaserRifle)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.BreakerBlade)
                .AddIngredient(ItemID.FireWhip)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.ClockworkAssaultRifle)
                .AddIngredient(ItemID.BreakerBlade)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.ClockworkAssaultRifle)
                .AddIngredient(ItemID.LaserRifle)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.ClockworkAssaultRifle)
                .AddIngredient(ItemID.FireWhip)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.LaserRifle)
                .AddIngredient(ItemID.BreakerBlade)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.LaserRifle)
                .AddIngredient(ItemID.ClockworkAssaultRifle)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.LaserRifle)
                .AddIngredient(ItemID.FireWhip)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.FireWhip)
                .AddIngredient(ItemID.BreakerBlade)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.FireWhip)
                .AddIngredient(ItemID.ClockworkAssaultRifle)
                .AddTile(TileID.Anvils)
                .Register();
            Recipe.Create(ItemID.FireWhip)
                .AddIngredient(ItemID.LaserRifle)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}

// So many recipes... pain be like...