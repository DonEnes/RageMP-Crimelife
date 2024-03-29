﻿using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using RageMP_Gangwar.Utilities;
using RageMP_Gangwar.Models;
using System.Linq;

namespace RageMP_Gangwar.Handler
{
    class ChatHandler : Script
    {
        [ServerEvent(Event.ChatMessage)]
        public void EventChatMessage(Client player, string msg)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                if (msg.Contains("~")) msg = msg.Replace("~", "");
                int adminLevel = player.getAdminLevel();
                int pLevel = ServerAccounts.GetPlayerLevel(player.getAccountId());
                string prefix = ServerAccounts.GetAdminPrefix(adminLevel);
                string color = ServerAccounts.GetChatRankColor(adminLevel);
                string prestigeRank = ServerAccounts.GetPrestigeRankName(ServerAccounts.GetPrestigeLevel(player.getAccountId()));

                if(player.isChatMuted()) { player.SendChatMessage("Du bist gemutet."); return; }

                if (adminLevel == 0)
                    NAPI.Chat.SendChatMessageToAll($"[~r~Vace~w~] {prestigeRank} [lvl. {pLevel}] {player.Name}: {msg}");
                else if (adminLevel > 0)
                    NAPI.Chat.SendChatMessageToAll($"[~r~Vace~w~] {prefix} {prestigeRank} [lvl. {pLevel}] {player.Name}: {color} {msg}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        public static void SendFactionMessage(int factionId, string msg)
        {
            try
            {
                foreach (var p in NAPI.Pools.GetAllPlayers().ToList().Where(x => x != null && x.Exists && x.hasAccountId() && Models.ServerAccounts.GetAccountSelectedTeam(x.getAccountId()) == factionId)) {
                    p.SendChatMessage($"{msg}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
