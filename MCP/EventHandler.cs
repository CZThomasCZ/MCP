using Smod2;
using Smod2.Attributes;
using Smod2.Events;
using Smod2.API;
using Smod2.EventHandlers;
using System;
using Smod2.Config;
using System.Collections.Generic;
using System.Timers;
using gmLCZEscape;
using gmDBoiz;
using gmNormal;
using gmMTF;

namespace MCP
{
    public class PluginHandler : IEventHandlerRoundStart, IEventHandlerPlayerDie
    {
        private readonly string broadcast_error = "Config error";
        private readonly string cassie_error = "CORRUPTED CODE PITCH_1,5 CORRUPTED CODE PITCH_2 CORRUPTED CODE PITCH_2,5 CORRUPTED CODE PITCH_3 CORRUPTED CODE";

        public void OnRoundStart(RoundStartEvent ev)
        {   //Broadcast current gamemode + announce it using C.A.S.S.I.E.
            string gamemode = GamemodeManager.GamemodeManager.GetCurrentName();
            string broadcast = "ERROR";
            string cassie = "ERROR";

            if (gamemode == "LCZ Escape")
            {
                broadcast = ConfigManager.Manager.Config.GetStringValue("mcp_lcz_broadcast", broadcast_error, false);
                cassie = ConfigManager.Manager.Config.GetStringValue("mcp_lcz_cassie", cassie_error, false);
            }
            else if (gamemode == "Normal gamemode")
            {
                broadcast = ConfigManager.Manager.Config.GetStringValue("mcp_normal_broadcast", broadcast_error, false);
                cassie = ConfigManager.Manager.Config.GetStringValue("mcp_normal_cassie", cassie_error, false);
            }
            else if (gamemode == "D-Boiz escape")
            {
                broadcast = ConfigManager.Manager.Config.GetStringValue("mcp_dboiz_broadcast", broadcast_error, false);
                cassie = ConfigManager.Manager.Config.GetStringValue("mcp_dboiz_cassie", cassie_error, false);
            }
            else if (gamemode == "MTF Recontainment")
            {
                broadcast = ConfigManager.Manager.Config.GetStringValue("mcp_mtf_broadcast", broadcast_error, false);
                cassie = ConfigManager.Manager.Config.GetStringValue("mcp_mtf_cassie", cassie_error, false);
                
                // Respawn guards as a MTF Unit
                int MTFs = 0;
                foreach (Player player in PluginManager.Manager.Server.GetPlayers(Role.FACILITY_GUARD))
                {
                    if (MTFs == 0) player.ChangeRole(Role.NTF_COMMANDER);
                    else if (MTFs < 3) player.ChangeRole(Role.NTF_LIEUTENANT);
                    else player.ChangeRole(Role.NTF_CADET);
                    MTFs++;
                }
            }
            else if (gamemode == "Facility Raid")
            {
                int spectators = 0;
                int players = 0;
                bool enable = false;
                bool SH = false;
                foreach (Player player in PluginManager.Manager.Server.GetPlayers())
                {
                    if (player.TeamRole.Role == Role.SPECTATOR) spectators++;
                    players++;
                }
                if (players > 5) enable = true;
                if (enable == true)
                {   //Some chance to enable Serpent's Hand? 
                    Random random;
                    random = new Random();
                    double Chance = random.NextDouble(); // Gets value between 0.0 and 1.0
                    if (Chance < 0.5) SH = true;

                }

                foreach (Player player in PluginManager.Manager.Server.GetPlayers(Role.SPECTATOR))
                {
                    if (SH == true) SerpentsHand.SHPlugin.SpawnPlayer(player);
                    else player.ChangeRole(Role.CHAOS_INSURGENCY);
                }
                if (SH == false)
                {
                    broadcast = ConfigManager.Manager.Config.GetStringValue("mcp_raid_broadcast_ci", broadcast_error, false);
                    cassie = ConfigManager.Manager.Config.GetStringValue("mcp_raid_cassie_ci", cassie_error, false);
                } else
                {
                    broadcast = ConfigManager.Manager.Config.GetStringValue("mcp_raid_broadcast_sh", broadcast_error, false);
                    cassie = ConfigManager.Manager.Config.GetStringValue("mcp_raid_cassie_sh", cassie_error, false);
                }

            }

            PluginManager.Manager.Server.Map.Broadcast(10, "Current gamemode: " + broadcast, false);
            PluginManager.Manager.Server.Map.AnnounceCustomMessage(cassie);
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {   //Revive player if killed by SCP-049-2
            if(ev.Killer.TeamRole.Role == Role.SCP_049_2)
            {
                var deathPos = ev.Player.GetPosition();

                var respawnTimer = new Timer
                {
                    AutoReset = false,
                    Enabled = true,
                    Interval = 2000
                };
                respawnTimer.Elapsed += delegate
                {
                    ev.Player.ChangeRole(Role.SCP_049_2);
                    var health = ev.Player.GetHealth()/2;
                    ev.Player.Damage(health, DamageType.NONE);
                    ev.Player.Teleport(deathPos);
                };
            }
        }
    }
}