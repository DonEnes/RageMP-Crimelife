using GTANetworkAPI;
using RageMP_Gangwar.Functions;
using RageMP_Gangwar.Models;
using RageMP_Gangwar.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RageMP_Gangwar.Handler
{
    class Commands : Script
    {
        [Command("veh")]
        public void CMD_Veh(Client client, string vehName)
        {
            try
            {
                if (client == null || !client.Exists || !client.hasAccountId() || client.getAdminLevel() < 5) return;
                uint hash = NAPI.Util.GetHashKey(vehName);
                Vehicle veh = NAPI.Vehicle.CreateVehicle(hash, client.Position.Around(0), 0, 0, 0, "FIB", 255, false, true, 0);

                client.SendChatMessage($"Model: {veh.Model}  ||| Hash: {hash}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("leaveevent")]
        public void LeaveEventCMD(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                if (!Models.ServerAccounts.IsPlayerInEvent(player.getAccountId())) return;
                player.SendChatMessage($"[~p~EVENT~w~] Event verlassen.");
                Handler.TeamHandler.SpawnPlayer(player);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("event")]
        public void EventCMD(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || !Constants.EventConfig.isEventActive) return;
                int ownTeam = Models.ServerAccounts.GetAccountSelectedTeam(player.getAccountId());
                if (ownTeam != Constants.EventConfig.team1 && ownTeam != Constants.EventConfig.team2) return;
                if (Models.ServerAccounts.IsPlayerInEvent(player.getAccountId())) return;
                Models.ServerAccounts.SetPlayerinEvent(player.getAccountId(), true);
                player.SendChatMessage($"[~p~EVENT~w~] Event beigetreten.");
                player.Dimension = 31;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("reset")]
        public void resetCMD(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0) return;
                ServerAccounts.ResetKilLDeaths(pID);
                player.SendChatMessage($"[~r~Gambo~w~] K/D zurückgesetzt.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("prestige")]
        public void CMD_Prestige(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || ServerAccounts.GetPlayerLevel(pID) < 100 || ServerAccounts.GetPrestigeLevel(pID) > 10) return;
                ServerAccounts.SetPlayerLevel(pID, 1);
                ServerAccounts.SetPlayerEXP(pID, 1);
                ServerAccounts.SetPrestigeLevel(pID, ServerAccounts.GetPrestigeLevel(pID) + 1);
                NAPI.Chat.SendChatMessageToPlayer(player, $"Prestige Level erhöht. Aktuell: {ServerAccounts.GetPrestigeLevel(pID)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("clearchat")]
        public void CMD_ClearChat(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || player.getAdminLevel() < 4) return;
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
                NAPI.Chat.SendChatMessageToAll($"");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("waffen")]
        public void Waffen_CMD(Client client)
        {
            try
            {
                if (client == null || !client.Exists || client.getAdminLevel() < 4 || !client.hasAccountId()) return;
                AccountsFunctions.GiveWeapons(client);
            }
            catch (Exception e)
            {
                Console.Write($"{e}");
            }
        }

        [Command("setpos")]
        public void setposcmd(Client client, float x, float y, float z)
        {
            if (client == null || !client.Exists || !client.hasAccountId() || client.getAdminLevel() < 4) return;
            client.Position = new Vector3(x, y, z);
        }

        [Command("pos")]
        public void Pos_CMD(Client client)
        {
            if (client == null || !client.Exists) return;
            client.SendChatMessage($"{client.Position.ToString()}");
        }
        
        [Command("faction")]
        public void CMD_Faction(Client player, Client target, int faction, int rank)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || player.getAdminLevel() < 5) return;
                if (target == null || !target.Exists || !target.hasAccountId()) return;
                ServerAccounts.SetAccountFaction(target.getAccountId(), faction, rank);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("clearcars")]
        public void CMD_ClearCars(Client player, bool all = false)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || player.getAdminLevel() < 4) return;
                foreach(var veh in NAPI.Pools.GetAllVehicles().ToList().Where(x => x != null && x.Exists))
                {
                    if (all) veh.Delete();
                    else
                    {
                        if (veh.Occupants.Count == 0) veh.Delete();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("report", GreedyArg = true)]
        public void CMD_Report(Client player, Client reportedTarget, string reason)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || reportedTarget == null || !reportedTarget.Exists || !reportedTarget.hasAccountId()) return;
                foreach(var admin in NAPI.Pools.GetAllPlayers().ToList().Where(x => x != null && x.Exists && x.hasAccountId() && x.getAdminLevel() >= 4))
                {
                    admin.SendChatMessage($"~p~[REPORT]~w~ ~y~{reportedTarget.Name}~w~ wurde von ~y~{player.Name}~w~ reportet. Grund: ~r~{reason}");
                }
                player.SendChatMessage($"~p~[REPORT]~w~ Du hast ~y~{reportedTarget.Name}~w~ gemeldet. Grund: ~r~{reason}.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("pcount")]
        public void CMD_PCount(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                NAPI.Chat.SendChatMessageToPlayer(player, $"Derzeit sind {NAPI.Pools.GetAllPlayers().ToList().Where(x => x != null && x.Exists).Count()} / {NAPI.Server.GetMaxPlayers()} Spieler online.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("team")]
        public void CMD_Team(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                TeamHandler.CreateTeamSelect(player);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("invite")]
        public void CMD_Invite(Client player, Client inviteTarget)
        {
            try
            {
                if (player == null || !player.Exists || inviteTarget == null || !inviteTarget.Exists) return;
                if (!player.hasAccountId() || !inviteTarget.hasAccountId()) return;
                int pID = player.getAccountId();
                int tID = inviteTarget.getAccountId();
                if (pID <= 0 || tID <= 0) return;
                int pFaction = ServerAccounts.GetAccountFaction(pID);
                if (pFaction <= 0 || ServerAccounts.GetFactionRank(pID) != 2)
                {
                    NAPI.Chat.SendChatMessageToPlayer(player, $"[~r~Gambo~w~] Du bist in keiner privaten Fraktion oder bist nicht der Leader.");
                    return;
                }

                if(ServerAccounts.GetAccountFaction(tID) != 0)
                {
                    NAPI.Chat.SendChatMessageToPlayer(player, $"[~r~Gambo~w~] Der Spieler {inviteTarget.Name} ist bereits in einer privaten Fraktion.");
                    return;
                }

                string factionName = ServerFactions.GetFactionName(pFaction);
                NAPI.Chat.SendChatMessageToPlayer(inviteTarget, $"[~y~Private Fraktionen~w~] Du wurdest von {player.Name} in die Fraktion {factionName} eingeladen.");
                NAPI.Chat.SendChatMessageToPlayer(inviteTarget, $"[~y~Private Fraktionen~w~] Nutze ~y~/acceptinvite {player.Name} ~w~um die Einladung in die Fraktion anzunehmen.");
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~y~Private Fraktionen~w~] Du hast {inviteTarget.Name} in deine Fraktion eingeladen.");
                player.SetData("inviteFrak", inviteTarget.Name);
                inviteTarget.SetData("inviteFrak", player.Name);
                inviteTarget.SetData("inviteFrakId", pFaction);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("acceptinvite")]
        public void CMD_acceptInvite(Client player, Client inviter)
        {
            try
            {
                if (player == null || !player.Exists || inviter == null || !inviter.Exists) return;
                if (!player.hasAccountId() || !inviter.hasAccountId()) return;
                if (!player.HasData("inviteFrak") || !inviter.HasData("inviteFrak")) return;
                int pID = player.getAccountId();
                int iID = inviter.getAccountId();
                if (pID <= 0 || iID <= 0) return;
                if(ServerAccounts.GetAccountFaction(pID) != 0)
                {
                    NAPI.Chat.SendChatMessageToPlayer(player, $"[~r~Gambo~w~] Du bist bereits in einer privaten Fraktion.");
                    return;
                }

                if (player.GetData("inviteFrak") != inviter.Name || inviter.GetData("inviteFrak") != player.Name) return;
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~y~Private Fraktionen~w~] Du hast die Einladung der privaten Fraktion angenommen.");
                NAPI.Chat.SendChatMessageToPlayer(inviter, $"[~y~Private Fraktionen~w~] {player.Name} ist der privaten Fraktion beigetreten.");
                ServerAccounts.SetAccountFaction(pID, player.GetData("inviteFrakId"), 1);
                player.ResetData("inviteFrakId");
                player.ResetData("inviteFrak");
                inviter.ResetData("inviteFrak");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("uninvite")]
        public void CMD_Uninvite(Client player, Client target)
        {
            try
            {
                if (player == null || !player.Exists || target == null || !target.Exists) return;
                if (!player.hasAccountId() || !target.hasAccountId()) return;
                int pID = player.getAccountId();
                int tID = target.getAccountId();
                if (pID <= 0 || tID <= 0) return;
                int pFaction = ServerAccounts.GetAccountFaction(pID);
                if (pFaction <= 0 || ServerAccounts.GetFactionRank(pID) != 2)
                {
                    NAPI.Chat.SendChatMessageToPlayer(player, $"[~r~Gambo~w~] Du bist in keiner privaten Fraktion oder bist nicht der Leader.");
                    return;
                }

                if (ServerAccounts.GetAccountFaction(tID) != pFaction)
                {
                    NAPI.Chat.SendChatMessageToPlayer(player, $"[~r~Gambo~w~] Der Spieler {target.Name} ist nicht in deiner Fraktion.");
                    return;
                }
                string factionName = ServerFactions.GetFactionName(pFaction);

                NAPI.Chat.SendChatMessageToPlayer(player, $"[~y~Private Fraktionen~w~] Du hast den Spieler {target.Name} aus deiner Fraktion geworfen.");
                NAPI.Chat.SendChatMessageToPlayer(target, $"[~y~Private Fraktionen~w~] Du wurdest aus der privaten Fraktion '{factionName}' geworfen.");
                ServerAccounts.SetAccountFaction(tID, 0, 0);
                target.ResetData("inviteFrakId");
                TeamHandler.CreateTeamSelect(target);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("a", GreedyArg = true)]
        public void A_CMD(Client player, string message)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || player.getAdminLevel() < 4) return;
                int adminLevel = player.getAdminLevel();
                string prefix = ServerAccounts.GetAdminPrefix(adminLevel);
                string color = ServerAccounts.GetChatRankColor(adminLevel);
                foreach (var admin in NAPI.Pools.GetAllPlayers().ToList().Where(x => x != null && x.Exists && x.hasAccountId() && x.getAdminLevel() >= 4)) {
                    admin.SendChatMessage($"~p~[ADMIN-CHAT]~w~ {color}{prefix} {player.Name}: ~w~{message}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [Command("t", GreedyArg = true)]
        public void T_CMD(Client player, string message)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                int pID = player.getAccountId();
                if (pID <= 0 || ServerAccounts.GetAccountSelectedTeam(pID) <= 0) return;
                int team = ServerAccounts.GetAccountSelectedTeam(pID);
                if (team <= 0) return;
                int adminLevel = player.getAdminLevel();
                int pLevel = ServerAccounts.GetPlayerLevel(player.getAccountId());
                string prefix = ServerAccounts.GetAdminPrefix(adminLevel);
                string color = ServerAccounts.GetChatRankColor(adminLevel);
                string prestigeRank = ServerAccounts.GetPrestigeRankName(ServerAccounts.GetPrestigeLevel(player.getAccountId()));

                foreach (var teamMember in NAPI.Pools.GetAllPlayers().ToList().Where(x => x != null && x.Exists && x.hasAccountId() && ServerAccounts.GetAccountSelectedTeam(x.getAccountId()) == team)) {
                    teamMember.SendChatMessage($"[~y~TEAM-CHAT~w~] {prestigeRank} [lvl. {pLevel}] {player.Name}: {message}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

    }
}
