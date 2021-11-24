using GTANetworkAPI;
using System;
using RageMP_Gangwar.Utilities;
using System.Threading.Tasks;
using RageMP_Gangwar.Models;
using System.Linq;

namespace RageMP_Gangwar
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void ResourceStart()
        {
            Console.WriteLine("Server startet.");
            NAPI.Server.SetGlobalServerChat(false);
            NAPI.Server.SetAutoSpawnOnConnect(false);
            NAPI.Server.SetCommandErrorMessage("[Vace] Dieser Befehl wurde nicht gefunden.");
            NAPI.Server.SetAutoRespawnAfterDeath(false);

            Database.DatabaseHandler.LoadAllAccounts();
            Database.DatabaseHandler.LoadAllServerBlips();
            Database.DatabaseHandler.LoadAllServerFactions();
            Database.DatabaseHandler.LoadAllFFAZones();
            Database.DatabaseHandler.LoadAllServerPrestigeVehicles();
            Database.DatabaseHandler.LoadAllGangwarZones();

            Task.Run(() =>
            {
                while(true)
                {
                    Task.Delay(TimeSpan.FromMinutes(5.0)).Wait();
                    NAPI.Task.Run(() =>
                    {
                        Database.DatabaseHandler.SaveAllStuff();
                    });
                }
            });

            Task.Run(() =>
            {
                while(true)
                {
                    Task.Delay(1000 * 480 * 1).Wait();
                    NAPI.Task.Run(() =>
                    {
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

                    });
                }
            });

            Task.Run(() =>
            {
                while(true)
                {
                    Task.Delay(1000 * 900 * 1).Wait();
                    NAPI.Task.Run(() =>
                    {
                        foreach (var veh in NAPI.Pools.GetAllVehicles().ToList().Where(x => x != null && x.Exists))
                        {
                            if (veh.Occupants.Count == 0) veh.Delete();
                        }
                    });
                }
            });

            Task.Run(() =>
            {
                while(true)
                {
                    Task.Delay(TimeSpan.FromMinutes(2)).Wait();
                    NAPI.Task.Run(() =>
                    {
                        Handler.GangwarHandler.GangwarTimer();
                    });
                }
            });
        }


        [ServerEvent(Event.ResourceStop)]
        public void ResourceStop()
        {
            Console.WriteLine("Server gestoppt.");
        }

        [ServerEvent(Event.PlayerConnected)]
        public void PlayerConnected(Client player)
        {
            try
            {
                if (player == null || !player.Exists) return;


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
                player.TriggerEvent("Client:Login:createLoginCamera", true); //Loginkamera erstellen
                NAPI.Player.SpawnPlayer(player, new Vector3(1325.453, -530.5556, 89.85238));
                player.Position = new Vector3(1325.453, -530.5556, 89.85238);
                player.Dimension = 10;
                player.Health = 100;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
