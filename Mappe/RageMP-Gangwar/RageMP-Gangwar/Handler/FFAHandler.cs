using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using RageMP_Gangwar.Utilities;
using RageMP_Gangwar.Models;

namespace RageMP_Gangwar.Handler
{
    public class FFAHandler : Script
    {
        public static void openFFABrowser(Client player, dbmodels.ServerFFA ffaData)
        {
			try
			{
				if (player == null || !player.Exists || !player.hasAccountId() || ffaData == null || ServerAccounts.GetPlayerFFAArena(player.getAccountId()) != 0) return;
				player.TriggerEvent("Client:ffamenu_c:openBrowser", ffaData.name);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");
			}
        }
		
		[Command("ffa")]
        public void Event_FFA(Client player, string arenaName)
		{
			try
			{
				if (player == null || !player.Exists || !player.hasAccountId() || ServerAccounts.GetPlayerFFAArena(player.getAccountId()) != 0) return;
				var pID = player.getAccountId();
				var arenaData = ServerFFA.GetFullFFAEntry(arenaName);
				if (arenaData == null || pID <= 0) return;
				if(arenaData.currentPlayers >= 15)
				{
					player.SendChatMessage($"[~p~Vace System~w~] Die FFA Arena ist ~p~voll.~w~ Wähle eine andere.");
					return;
				}
				ServerAccounts.SetPlayerFFAArena(pID, arenaData.id);
				ServerFFA.IncreaseFFAPlayer(arenaData.id);
				TeamHandler.SpawnPlayer(player);
				player.SendChatMessage($"[~p~Vace System~w~] Willkommen in der FFA Arena. Benutze ~p~/quitffa~w~ um die FFA-Arena zu verlassen.");
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");
			}
		}
		
		[RemoteEvent("Server:FFA:setFFA")]
		public void Event_setFFA(Client player, string arenaName)
		{
			try
			{
				if (player == null || !player.Exists || !player.hasAccountId() || ServerAccounts.GetPlayerFFAArena(player.getAccountId()) != 0) return;
				var pID = player.getAccountId();
				var arenaData = ServerFFA.GetFullFFAEntry(arenaName);
				if (arenaData == null || pID <= 0) return;
				if(arenaData.currentPlayers >= 15)
				{
					player.SendChatMessage($"[~p~Vace System~w~] Die FFA Arena ist ~p~voll.~w~ Wähle eine andere.");
					return;
				}
				ServerAccounts.SetPlayerFFAArena(pID, arenaData.id);
				ServerFFA.IncreaseFFAPlayer(arenaData.id);
				TeamHandler.SpawnPlayer(player);
				player.SendChatMessage($"[~p~Vace System~w~] Willkommen in der FFA Arena. Benutze ~p~/quitffa~w~ um die FFA-Arena zu verlassen.");
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");
			}
		}
		
		[ServerEvent(Event.PlayerDisconnected)]
		public void OnPlayerDisconnected(Client player, DisconnectionType type, string reason)
		{
			try
			{
				if (!player.hasAccountId()) return;
				var pID = player.getAccountId();
				if (pID <= 0) return;
				Models.ServerAccounts.SetPlayerDuellPartner(pID, 0);
				var currentFFAArena = ServerAccounts.GetPlayerFFAArena(pID);
				if(currentFFAArena != 0)
				{
					ServerAccounts.SetPlayerFFAArena(pID, 0);
					ServerFFA.DecreaseFFAPlayer(currentFFAArena);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");
			}
		}

		[Command("quitffa")]
		public void CMD_QuitFFA(Client player)
		{
			try
			{
				if (player == null || !player.Exists || !player.hasAccountId() || ServerAccounts.GetPlayerFFAArena(player.getAccountId()) <= 0) return;
				var pID = player.getAccountId();
				if (pID <= 0 || ServerAccounts.GetAccountSelectedTeam(pID) <= 0) return;
				ServerFFA.DecreaseFFAPlayer(ServerAccounts.GetPlayerFFAArena(pID));
				ServerAccounts.SetPlayerFFAArena(pID, 0);
				TeamHandler.SpawnPlayer(player);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");
			}
		}
	}
}
