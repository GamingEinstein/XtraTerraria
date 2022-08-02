using XtraTerraria.Common.Systems;
using XtraTerraria.Content.BossBars;
using static XtraTerraria.ModClasses.XtraTerraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace XtraTerraria.Content.NPCs.Bosses
{
    [AutoloadBossHead]
    public class Zephyrus : ModNPC
    {
        public override string Texture => AssetPathTextures + "NPCs/Bosses/Zephyrus";
        public override string BossHeadTexture => AssetPathTextures + "NPCs/Bosses/Zephyrus_Head_Boss";

        public static int secondStageHeadSlot = -1;
        public bool SecondStage
        {
            get => NPC.ai[0] == 1f;
            set => NPC.ai[0] = value ? 1f : 0f;
        }
        public Vector2 FirstStageDestination
        {
            get => new Vector2(NPC.ai[1], NPC.ai[2]);
            set
            {
                NPC.ai[1] = value.X;
                NPC.ai[2] = value.Y;
            }
        }
        public Vector2 LastFirstStageDestination { get; set; } = Vector2.Zero;
        private const int FirstStageTimerMax = 90;
        public ref float FirstStageTimer => ref NPC.localAI[1];

        /*public override void Load()
        {
            string texture = BossHeadTexture + "_SecondStage";
            secondStageHeadSlot = Mod.AddBossHeadTexture(texture, -1);
        }*/

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zephyrus, Giver of Hyrdration");
            Main.npcFrameCount[Type] = 6;

            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.OnFire,
                    BuffID.OnFire3,
                    BuffID.Wet,
                    BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                CustomTexturePath = AssetPathTextures + "Bestiary/Zephyrus_Preview",
                PortraitScale = 0.6f,
                PortraitPositionYOverride = 0f,
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetDefaults()
        {
            NPC.width = 110;
            NPC.height = 110;
            NPC.damage = 12;
            NPC.defense = 10;
            NPC.lifeMax = 2000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(gold: 5);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f;
            NPC.aiStyle = -1;
            NPC.BossBar = GetInstance<ZephyrusBossBar>();

            if (!Main.dedServ)
                Music = MusicID.DukeFishron;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("The cause of all aquatic life, this creature makes the rivers run and the sky rain. It would be advised to not invoke its anger")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //npcLoot.Add(ItemDropRule.BossBag(ItemType<MinionBossBag>()));
            //npcLoot.Add(ItemDropRule.Common(ItemType<MinionBossTrophy>(), 10));
            //npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ItemType<MinionBossRelic>()));
            //npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ItemType<MinionBossPetItem>(), 4));
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            //notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<MinionBossMask>(), 7));
            npcLoot.Add(notExpertRule);
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedZephyrus, -1);
        }

        public override void FindFrame(int frameHeight)
        {
            int startFrame = 0;
            int finalFrame = 2;

            if (SecondStage)
            {
                startFrame = 3;
                finalFrame = Main.npcFrameCount[NPC.type] - 1;

                if (NPC.frame.Y < startFrame * frameHeight)
                    NPC.frame.Y = startFrame * frameHeight;
            }

            int frameSpeed = 5;
            NPC.frameCounter += 0.5f;
            NPC.frameCounter += NPC.velocity.Length() / 10f;
            if (NPC.frameCounter > frameSpeed)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;

                if (NPC.frame.Y > finalFrame * frameHeight)
                    NPC.frame.Y = startFrame * frameHeight;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.netMode == NetmodeID.Server)
                return;

            if (NPC.life <= 0)
            {
                /*// These gores work by simply existing as a texture inside any folder which path contains "Gores/"
                int backGoreType = Mod.Find<ModGore>("MinionBossBody_Back").Type;
                int frontGoreType = Mod.Find<ModGore>("MinionBossBody_Front").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }*/

                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
        }

        public override void AI()
        {
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
                NPC.TargetClosest();

            Player player = Main.player[NPC.target];

            if (player.dead)
            {
                NPC.velocity.Y -= 0.04f;
                NPC.EncourageDespawn(10);
                return;
            }

            DoFirstStage(player);
        }

        private void DoFirstStage(Player player)
        {
            // Each time the timer is 0, pick a random position a fixed distance away from the player but towards the opposite side
            // The NPC moves directly towards it with fixed speed, while displaying its trajectory as a telegraph

            FirstStageTimer++;
            if (FirstStageTimer > FirstStageTimerMax)
                FirstStageTimer = 0;

            float distance = 200; // Distance in pixels behind the player

            if (FirstStageTimer == 0)
            {
                Vector2 fromPlayer = NPC.Center - player.Center;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // Important multiplayer concideration: drastic change in behavior (that is also decided by randomness) like this requires
                    // to be executed on the server (or singleplayer) to keep the boss in sync

                    float angle = fromPlayer.ToRotation();
                    float twelfth = MathHelper.Pi / 6;

                    angle += MathHelper.Pi + Main.rand.NextFloat(-twelfth, twelfth);
                    if (angle > MathHelper.TwoPi)
                        angle -= MathHelper.TwoPi;
                    else if (angle < 0)
                        angle += MathHelper.TwoPi;

                    Vector2 relativeDestination = angle.ToRotationVector2() * distance;

                    FirstStageDestination = player.Center + relativeDestination;
                    NPC.netUpdate = true;
                }
            }

            // Move along the vector
            Vector2 toDestination = FirstStageDestination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float speed = Math.Min(distance, toDestination.Length());
            NPC.velocity = toDestinationNormalized * speed / 30;

            if (FirstStageDestination != LastFirstStageDestination)
            {
                // If destination changed
                NPC.TargetClosest(); // Pick the closest player target again

                // "Why is this not in the same code that sets FirstStageDestination?" Because in multiplayer it's ran by the server.
                // The client has to know when the destination changes a different way. Keeping track of the previous ticks' destination is one way
                if (Main.netMode != NetmodeID.Server)
                {
                    // For visuals regarding NPC position, netOffset has to be concidered to make visuals align properly
                    NPC.position += NPC.netOffset;
                    NPC.position -= NPC.netOffset;
                }
            }
            LastFirstStageDestination = FirstStageDestination;

            NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;
        }
    }
}