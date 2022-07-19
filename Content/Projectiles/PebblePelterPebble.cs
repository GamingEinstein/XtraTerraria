using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.Projectiles
{
    public class PebblePelterPebble : ModProjectile
    {
        public override string Texture => AssetPathTextures + "Projectiles/PebblePelterPebble";
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.penetrate = 2;
            Projectile.alpha = 0;
            Projectile.aiStyle = -1;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return null;
        }

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            Projectile.netUpdate = true;

            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
            }
            if (Projectile.velocity.Y > 16f)
                Projectile.velocity.Y = 16f;

            Projectile.rotation += 0.4f * (float)Projectile.direction;
        }
    }
}
