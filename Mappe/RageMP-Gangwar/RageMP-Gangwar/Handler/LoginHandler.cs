using GTANetworkAPI;
using RageMP_Gangwar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RageMP_Gangwar.Utilities;
using System.Text;

namespace RageMP_Gangwar.Handler
{
    class LoginHandler : Script
    {
        [RemoteEvent("Server:tryLogin")]
        public void tryLogin(Client player, string username, string password)
        {
            if (player == null || !player.Exists) return;
            if(string.IsNullOrWhiteSpace(username))
            {
                player.TriggerEvent("Client:showLoginError", "Der Benutzername darf nicht leer sein.");
                return;
            }
        }

        [RemoteEvent("Server:Login:tryLogin")]
        public void tryLogin(Client player, string username)
        {
            try
            {
                if (player == null || !player.Exists || string.IsNullOrWhiteSpace(username)) return;
                if(ServerAccounts.ExistPlayerByUserName(username))
                {
                    //Spieler existiert
                    if(ServerAccounts.GetAccountHardwareId(username) == "unset")
                    {
                        int pID = ServerAccounts.GetAccountIdByName(username);
                        ServerAccounts.SetPlayerHwId(pID, player.Serial);
                    }

                    if(ServerAccounts.GetAccountHardwareId(username) != player.Serial || ServerAccounts.GetAccountSocialClub(username) != player.SocialClubName)
                    {
                        player.TriggerEvent("Client:Login:LoginResult", 2, "Dieser Account gehört nicht dir.");
                        return;
                    }

                    player.setAccountId(ServerAccounts.GetAccountIdByName(username));

                    if (ServerAccounts.IsAccountPermBanned(player.getAccountId()))
                    {
                        player.TriggerEvent("Client:Login:LoginResult", 2, "Dieser Account wurde permanent gesperrt.");
                        return;
                    }
                    else
                    {
                        
                        if(ServerAccounts.IsAccountTimeBanned(player.getAccountId()) && ServerAccounts.GetAccountBanTimestamp(player.getAccountId()) != null && DateTime.Now.Subtract((DateTime)ServerAccounts.GetAccountBanTimestamp(player.getAccountId())).TotalHours < ServerAccounts.GetTimebanHours(player.getAccountId()))
                        {
                            player.TriggerEvent("Client:Login:LoginResult", 2, "Dieser Account wurde temporär gesperrt.");
                            return;
                        }
                        else if(ServerAccounts.IsAccountTimeBanned(player.getAccountId()) && ServerAccounts.GetAccountBanTimestamp(player.getAccountId()) != null && DateTime.Now.Subtract((DateTime)ServerAccounts.GetAccountBanTimestamp(player.getAccountId())).TotalHours >= ServerAccounts.GetTimebanHours(player.getAccountId())) {
                            ServerAccounts.SetPlayerBanned(player.getAccountId(), ServerAccounts.IsAccountPermBanned(player.getAccountId()), false);
                            ServerAccounts.SetTimebanHours(player.getAccountId(), 0);
                        } 
                    }

                    player.TriggerEvent("Client:Login:LoginResult", 0, "Erfolgreich eingeloggt.");
                    FinishLogin(player);
                } 
                else
                {
                    //Spieler existiert nicht
                    if(ServerAccounts.ExistAccountBySC(player.SocialClubName))
                    {
                        player.TriggerEvent("Client:Login:LoginResult", 2, "Es existiert bereits ein Account mit deinem Social-Club Namen.");
                        return;
                    }

                    ServerAccounts.CreateAccount(player, username);
                    player.TriggerEvent("Client:Login:LoginResult", 0, "Erfolgreich registriert. Logge dich nun ein!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
        public static void FinishLogin(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                var pInfo = ServerAccounts.GetFullAccount(player.getAccountId());
                if (pInfo == null || pInfo.playerId <= 0) return;
                NAPI.Player.SetPlayerName(player, pInfo.playerName);
                player.Position = new Vector3(-2044.288, -1031.322, 11.98072);
                player.TriggerEvent("Client:Login:destroyLogin");
                player.TriggerEvent("Client:HUD:showHUD", pInfo.level, pInfo.kills, pInfo.deaths, pInfo.exp, pInfo.level * 15); //ToDo: letzte Variable durch Max EXP ersetzen
                TeamHandler.CreateTeamSelect(player);
                player.TriggerEvent("Client:Ped:createGaragePeds", ServerFactions.GetAllFactionGarageInfo());
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
    }
}
