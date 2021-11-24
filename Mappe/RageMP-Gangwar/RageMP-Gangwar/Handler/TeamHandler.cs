using GTANetworkAPI;
using System;
using System.Collections.Generic;
using RageMP_Gangwar.Utilities;
using System.Text;
using RageMP_Gangwar.Models;
using RageMP_Gangwar.Functions;

namespace RageMP_Gangwar.Handler
{
    class TeamHandler : Script
    {
        public static void CreateTeamSelect(Client player)
        {
			try
			{
				if(player == null || !player.Exists || !player.hasAccountId()) return;
				int pID = player.getAccountId();
				int currentFFAArena = ServerAccounts.GetPlayerFFAArena(pID);
				ServerAccounts.SetAccountSelectedTeam(pID, 0);
				player.Position = new Vector3(1325.453, -530.5556, 89.85238);
				player.Dimension = 10;
				player.TriggerEvent("Client:Login:createLoginCamera", false);
				player.TriggerEvent("Client:TeamBrowser:clearInfo");
				ServerFactions.GetAllFactionInformations(player);
				player.TriggerEvent("Client:TeamBrowser:createBrowser");

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

		[RemoteEvent("Server:TeamBrowser:selectTeam")]
		public void selectTeam(Client player, int factionId)
		{
			try
			{
				if (player == null || !player.Exists || factionId <= 0 || !ServerFactions.ExistFaction(factionId) || !player.hasAccountId()) return;
				if (ServerFactions.IsFactionPrivate(factionId) && ServerAccounts.GetAccountFaction(player.getAccountId()) != factionId) return;
				player.TriggerEvent("Client:Login:destroyLoginCam");
				ServerAccounts.SetAccountSelectedTeam(player.getAccountId(), factionId);
				player.TriggerEvent("Client:TeamBrowser:destroyBrowser");
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
				ClothesFunctions.setCorrectTeamClothes(player);
				SpawnPlayer(player);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");	
			}
		} 

		public static void SpawnPlayer(Client player)
		{
			try
			{
				if (player == null || !player.Exists || !player.hasAccountId() || ServerAccounts.GetAccountSelectedTeam(player.getAccountId()) <= 0) return;
				int pID = player.getAccountId();
				if (pID <= 0 || !ServerFactions.ExistFaction(ServerAccounts.GetAccountSelectedTeam(pID))) return;
				Models.ServerAccounts.SetPlayerDuellPartner(pID, 0);
				AccountsFunctions.GiveWeapons(player);
				if (ServerAccounts.GetPlayerFFAArena(pID) == 0)
				{
					NAPI.Player.SpawnPlayer(player, ServerFactions.GetFactionSpawn(ServerAccounts.GetAccountSelectedTeam(pID)));
					player.Position = ServerFactions.GetFactionSpawn(ServerAccounts.GetAccountSelectedTeam(pID));
					player.Dimension = 0;
				} 
				else if(ServerAccounts.GetPlayerFFAArena(pID) > 0)
				{
					Vector3 arenaPos = ServerFFA.GetRandomFFAZonePosition(ServerAccounts.GetPlayerFFAArena(pID));
					NAPI.Player.SpawnPlayer(player, arenaPos);
					player.Position = arenaPos;
					player.Dimension = (uint)ServerFFA.GetFFAZoneDimension(ServerAccounts.GetPlayerFFAArena(pID));
				}
				player.Health = 100;
				player.Armor = 100;

				if (Models.ServerAccounts.IsPlayerInEvent(pID)) player.Dimension = 31;
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");
			}
		}
    }
}
