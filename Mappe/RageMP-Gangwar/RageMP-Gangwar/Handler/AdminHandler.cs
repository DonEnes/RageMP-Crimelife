using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using RageMP_Gangwar.Utilities;
using RageMP_Gangwar.Functions;
using RageMP_Gangwar.Models;
using System.Linq;

namespace RageMP_Gangwar.Handler
{
    public class AdminHandler : Script
    {       
        [Command("createffazone", GreedyArg = true)]
        public void CMD_CreateFFAZone(Client player, int dimension, string name)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 9) return;
                ServerFFA.CreateFFAZone(player, name, dimension);
                var ffaZone = ServerFFA.GetFullFFAEntry(name);
                if (ffaZone == null) return;
                player.SendChatMessage($"~p~[ADMIN]~w~ FFA-Zone erstellt (ID: {ffaZone.id})");
                Blip blip = NAPI.Blip.CreateBlip(432, new Vector3(ffaZone.posX, ffaZone.posY, ffaZone.posZ), 1.0f, 0, $"FFA - {ffaZone.name}", 255, 0, true);
                NAPI.Marker.CreateMarker(MarkerType.VerticalCylinder, new Vector3(ffaZone.posX, ffaZone.posY, ffaZone.posZ), new Vector3(ffaZone.posX, ffaZone.posY, ffaZone.posZ), new Vector3(0, 0, 0), 1f, new Color(255, 162, 0, 200));
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("createffaspawn")]
        public void CMD_CreateFFAZoneSpawn(Client player, int ffaId)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 9) return;
                ServerFFA.CreateFFASpawn(player, ffaId);
                player.SendChatMessage($"~p~[ADMIN]~w~ Spawn für FFA-Arena {ffaId} erstellt.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("unwarn")]
        public void CMD_Unwarn(Client player, Client target)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || target == null || !target.Exists || !target.hasAccountId()) return;
                int pID = player.getAccountId();
                int tID = target.getAccountId();
                if (pID <= 0 || tID <= 0 || player.getAdminLevel() < 5 || Models.ServerAccounts.GetPlayerWarns(tID) <= 0) return;
                Models.ServerAccounts.SetPlayerWarns(tID, Models.ServerAccounts.GetPlayerWarns(tID) - 1);
                player.SendChatMessage($"[~p~ADMIN~w~] Du hast {target.Name} einen Warn entfernt ({Models.ServerAccounts.GetPlayerWarns(tID)}/3 Warns).");
                target.SendChatMessage($"[~p~ADMIN~w~] {player.Name} hat dir einen Warn entfernt ({Models.ServerAccounts.GetPlayerWarns(tID)}/3 Warns).");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("warn")]
        public void CMD_Warn(Client player, Client target)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || target == null || !target.Exists || !target.hasAccountId()) return;
                int pID = player.getAccountId();
                int tID = target.getAccountId();
                if (pID <= 0 || tID <= 0 || player.getAdminLevel() < 5) return;
                Models.ServerAccounts.SetPlayerWarns(tID, Models.ServerAccounts.GetPlayerWarns(tID) + 1);
                Models.AdminLogs.AddNewAdminLog(pID, tID, "warn", $"{player.Name} hat {target.Name} verwarnt.");
                if(Models.ServerAccounts.GetPlayerWarns(tID) >= 3)
                {
                    target.Kick($"3/3 Warns, Ban!");
                    Models.ServerAccounts.SetPlayerBanned(tID, true, false);
                    player.SendChatMessage($"[~p~ADMIN~w~] Du hast {target.Name} verwarnt (3/3 Warns) - er wurde gebannt.");
                    return;
                }
                player.SendChatMessage($"[~p~ADMIN~w~] Du hast {target.Name} verwarnt ({Models.ServerAccounts.GetPlayerWarns(tID)}/3 Warns).");
                target.SendChatMessage($"[~p~ADMIN~w~] {player.Name} hat dich verwarnt ({Models.ServerAccounts.GetPlayerWarns(tID)}/3 Warns).");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("setlockstates")]
        public void CMD_SetLockState(Client player, int accId, int lockState)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 9) return;
                Models.ServerAccounts.SetPlayerLockState(accId, lockState);
                player.SendChatMessage($"Lockstate zu {lockState} geändert.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("mcustom", GreedyArg = true)]
        public void CMD_MCustom(Client player, string title, string msg)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 ||  player.getAdminLevel() < 4) return;
                NAPI.ClientEvent.TriggerClientEventForAll("Client:HUD:ModMessage", title, msg, 6000);
            }
            catch (Exception e)
            {
                Console.Write($"{e}");
            }
        }
        [ServerEvent(Event.PlayerWeaponSwitch)]
        public void PlayerWeaponSwitch(Client c, WeaponHash oldWeapon, WeaponHash newWeapon)
        {
            try
            {
                if (oldWeapon == null) return;
                if (newWeapon == null) return;
                if (c == null) return;

                c.TriggerEvent("client:weaponSwap");
                NAPI.Player.SetPlayerCurrentWeapon(c, newWeapon);
                //NAPI.Player.SetPlayerCurrentWeaponAmmo(c, 9999);
                c.Eval($"mp.game.invoke('0xDCD2A934D65CB497', mp.game.player.getPed(), {NAPI.Util.GetHashKey(newWeapon.ToString())}, 9999);");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION PlayerWeaponSwitch] " + ex.Message);
                Console.WriteLine("[EXCEPTION PlayerWeaponSwitch] " + ex.StackTrace);
            }
        }
        [Command("krieg", GreedyArg = true)]
        public void CMD_Krieg(Client player, string attacker, string defender)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 4) return;
                NAPI.ClientEvent.TriggerClientEventForAll("Client:HUD:SystemMessage", "Kriegsvertrag", $"Wer erklärt wem den Krieg: {attacker} vs {defender}. Grund des Krieges: Schädigung des Geschäfts, Respektlosigkeit gegenüber der {attacker} ,Beschuss der {attacker} Leaderschaft", 15000);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("givecar", GreedyArg = true)]
        public void CMD_GiveCar(Client player, int accId, uint hash, string displayName)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 9) return;
                if (Models.ServerVehicles.ExistPrivateVehicleByHash(accId, hash)) return;
                Models.ServerVehicles.CreatePrivateVehicle(accId, hash, displayName);
                player.SendChatMessage($"[~p~ADMIN~w~] Fahrzeug {displayName} gegeben.");
                AdminLogs.AddNewAdminLog(pID, accId, "givecar", $"Fahrzeug {displayName} gegeben (Hash: {hash})");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("delprivatecar")]
        public void CMD_DelPrivateCar(Client player, int accId, uint hash)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 9) return;
                if (!Models.ServerVehicles.ExistPrivateVehicleByHash(accId, hash)) return;
                Models.ServerVehicles.RemovePrivateVehicle(accId, hash);
                player.SendChatMessage($"[~p~ADMIN~w~] Fahrzeug entfernt (Account: {accId} - Hash: {hash}).");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("makeadmin")]
        public void CMD_MakeAdmin(Client player, Client target, int rank)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 8) return;
                if (target.getAdminLevel() > player.getAdminLevel()) return;
                Models.ServerAccounts.SetAccountAdminLevel(target.getAccountId(), rank);
                NAPI.Chat.SendChatMessageToPlayer(player, $"{target.Name} hat den Rang {rank} ({Models.ServerAccounts.GetAdminPrefix(rank)}) gesetzt bekommen.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");               
            }
        }


        [Command("goto")]
        public void CMD_Goto(Client player, Client target)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || target == null || !target.Exists || !target.hasAccountId()) return;
                int pID = player.getAccountId();
                int tID = target.getAccountId();
                if (pID <= 0 || tID <= 0|| Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || player.getAdminLevel() < 4) return;
                player.Position = target.Position;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("gethere")]
        public void CMD_Gethere(Client player, Client target)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || target == null || !target.Exists || !target.hasAccountId()) return;
                int pID = player.getAccountId();
                int tID = target.getAccountId();
                if (pID <= 0 || tID <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(tID) <= 0 || player.getAdminLevel() < 4) return;
                target.Position = player.Position;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("aduty")]
        public void Command_Aduty(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || player.getAdminLevel() < 4) return;
                bool isAduty = Models.ServerAccounts.IsPlayerADuty(pID);
                Models.ServerAccounts.SetPlayerADuty(pID, !isAduty);
                player.TriggerEvent("Client:Admin:setAdutyState", !isAduty);
                player.TriggerEvent("Client:Admin:toggleAdminMode");
                player.Transparency = 255;

                if (!isAduty)
                {
                    //Aduty
                    player.SetSkin(PedHash.Pogo01);
                    player.Transparency = 0;
                    NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~ADMIN~w~] Mit ~r~F6 ~w~wirst du wieder sichtbar.");
                }
                else
                {
                    player.SetSkin(PedHash.FreemodeMale01);
                    ClothesFunctions.setCorrectTeamClothes(player);
                    AccountsFunctions.GiveWeapons(player);
                    player.Transparency = 255;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("getusername")]
        public void CMD_getusername(Client player, int accId)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 4 || !Models.ServerAccounts.ExistPlayerByid(accId)) return;
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~ADMIN~w~] Der Name des Spielers mit der ID ({accId}) lautet: {Models.ServerAccounts.GetAccountNameById(accId)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("getaccountid")]
        public void CMD_getaccountid(Client player, string name)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 4 || !Models.ServerAccounts.ExistPlayerByUserName(name)) return;
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~ADMIN~w~] Die ID des Spielers mit dem Namen {name} lautet: {Models.ServerAccounts.GetAccountIdByName(name)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("teleportevent")]
        public void CMD_TPEvent(Client player, int team)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 4) return;
                if (team != Constants.EventConfig.team1 && team != Constants.EventConfig.team2) return;
                foreach(var p in NAPI.Pools.GetAllPlayers().ToList().Where(x => x != null && x.Exists)) {
                    if (p == null || !p.Exists || !p.hasAccountId() || Models.ServerAccounts.GetAccountSelectedTeam(p.getAccountId()) != team) continue;
                    p.Position = player.Position;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("createevent")]
        public void CMD_CreateEvent(Client player, int team1, int team2)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || team1 <= 0 || team2 <= 0) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 4) return;
                if(Constants.EventConfig.isEventActive)
                {
                    player.SendChatMessage($"[~p~EVENT~w~] Es läuft bereits ein Event.");
                    return;
                }

                Constants.EventConfig.team1 = team1;
                Constants.EventConfig.team2 = team2;
                Constants.EventConfig.isEventActive = true;
                player.SendChatMessage($"Event erstellt - Team 1: {team1} | Team 2: {team2}");
                NAPI.Chat.SendChatMessageToAll($"[~p~EVENT~w~] Ein Event wurde gestartet. Teilt euch in die Teams {Models.ServerFactions.GetFactionName(team1)} und {Models.ServerFactions.GetFactionName(team2)} auf und tretet per /event bei.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("getaccountname")]
        public void CMD_GetAccName(Client player, string sc)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 4) return;
                player.SendChatMessage($"[~p~ADMIN~w~] Der Name des Spielers lautet {Models.ServerAccounts.GetAccNameBySC(sc)} (SocialClub: {sc}).");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("resethwid")]
        public void CMD_resetHwId(Client player, int accId)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 9 || !Models.ServerAccounts.ExistPlayerByid(accId)) return;
                Models.ServerAccounts.SetPlayerHwId(accId, "unset");
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~ADMIN~w~] Hardware-ID erfolgreich zurück gesetzt (Spieler: {accId}).");
                AdminLogs.AddNewAdminLog(pID, accId, "resethwid", $"Hardware-ID von {accId} zurückgesetzt.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("kick", GreedyArg = true)]
        public void CMD_Kick(Client player, Client target, string reason)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || target == null || !target.Exists) return;
                int pID = player.getAccountId();
                if (pID <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || player.getAdminLevel() < 4) return;
                if (target.hasAccountId() && target.getAdminLevel() > player.getAdminLevel()) return;
                NAPI.Chat.SendChatMessageToAll($"[~r~Vace System~w~] {player.Name} hat {target.Name} vom Server gekickt. Grund: {reason}");
                target.Kick($"{reason}");
                Models.AdminLogs.AddNewAdminLog(pID, target.getAccountId(), "kick", $"{player.Name} hat {target.Name} gekickt. Grund: {reason}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("ban", GreedyArg = true)]
        public void CMD_Ban(Client player, Client target, string reason)
        {
            if (player == null || !player.Exists || !player.hasAccountId() || target == null || !target.Exists || !target.hasAccountId()) return;
            int pID = player.getAccountId();
            int tID = target.getAccountId();
            if (pID <= 0 || tID <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || player.getAdminLevel() < 9 || target.getAdminLevel() > player.getAdminLevel() || Models.ServerAccounts.IsAccountPermBanned(tID)) return;
            NAPI.Chat.SendChatMessageToAll($"[~r~Vace System~w~] {player.Name} hat {target.Name} gebannt. Grund: {reason}");
            Models.ServerAccounts.SetPlayerBanned(tID, true, false);
            target.Kick($"{reason}");
            Models.AdminLogs.AddNewAdminLog(pID, tID, "ban", $"{player.Name} hat {target.Name} gebannt. Grund: {reason}");
        }

        [Command("togglent")]
        public void ToggleNT_CMD(Client player)
        {
            if (player == null || !player.Exists || !player.hasAccountId()) return;
            int pID = player.getAccountId();
            if (pID <= 0 || player.getAdminLevel() < 6) return;
            player.TriggerEvent("Client:Admin:toggleNametag");
        }

        [Command("timeban", GreedyArg = true)]
        public void CMD_Timeban(Client player, Client target, int hours, string reason)
        {
            if (player == null || !player.Exists || !player.hasAccountId() || target == null || !target.Exists || !target.hasAccountId()) return;
            int pID = player.getAccountId();
            int tID = target.getAccountId();
            if (pID <= 0 || tID <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || player.getAdminLevel() < 5 || target.getAdminLevel() > player.getAdminLevel() || Models.ServerAccounts.IsAccountTimeBanned(tID)) return;
            NAPI.Chat.SendChatMessageToAll($"[~r~Vace System~w~] {player.Name} hat {target.Name} temporär gebannt. Grund: {reason}");
            Models.ServerAccounts.SetPlayerBanned(tID, false, true);
            Models.ServerAccounts.SetTimebanHours(tID, hours);
            target.Kick($"{reason} ({hours} Stunden)");
            Models.AdminLogs.AddNewAdminLog(pID, tID, "timeban", $"{player.Name} hat {target.Name} temporär gebannt. Grund: {reason}");
        }

        [Command("setxp")]
        public void CMD_SetXP(Client player, int multiplikator)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || multiplikator <= 0) return;
                int pID = player.getAccountId();
                if (pID <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || player.getAdminLevel() < 8) return;
                Constants.ServerConfig.XPMultiplikator = multiplikator;
                NAPI.Chat.SendChatMessageToAll($"[~r~Vace System~w~] Der XP-Multiplikator wurde von {player.Name} auf {multiplikator}x gesetzt.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("unban")]
        public void CMD_Unban(Client player, int accId)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || player.getAdminLevel() < 6) return;
                Models.ServerAccounts.SetPlayerBanned(accId, false, false);
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~r~Vace System~w~] Spieler wurde erfolgreich entbannt (ID: {accId}).");
                Models.AdminLogs.AddNewAdminLog(pID, accId, "unban", $"{player.Name} hat die Spieler-ID ({accId}) entbannt.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [RemoteEvent("Server:Admin:toggleVanish")]
        public void AdminEvent_toggleVanish(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || Models.ServerAccounts.GetAccountSelectedTeam(pID) <= 0 || player.getAdminLevel() < 4 || !Models.ServerAccounts.IsPlayerADuty(pID)) return;
                if (player.Transparency == 0) player.Transparency = 255;
                else if (player.Transparency == 255) player.Transparency = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
