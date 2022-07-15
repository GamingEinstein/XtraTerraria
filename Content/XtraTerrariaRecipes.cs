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

        public override void AddRecipes()
        {
            //Vanilla Emblems
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
            //Plans for Modded Emblems

            //Wall of Flesh Drops
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
