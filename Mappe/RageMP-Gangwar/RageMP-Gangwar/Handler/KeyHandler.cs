using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using RageMP_Gangwar.Utilities;
using System.Linq;

namespace RageMP_Gangwar.Handler
{
    public class KeyHandler : Script
    {
        [RemoteEvent("Server:Keyhandler:E")]
        public void KeyHandler_E(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                var factionGarage = Models.ServerFactions.ServerFactionsGarage_.FirstOrDefault(x => player.Position.IsInRange(new Vector3(x.pedX, x.pedY, x.pedZ), 2f) && x.factionId == Models.ServerAccounts.GetAccountSelectedTeam(player.getAccountId()));
                if(factionGarage != null && !player.IsInVehicle)
                {
                    GarageHandler.openBrowser(player, factionGarage);
                    return;
                }

                var ffaZone = Models.ServerFFA.ServerFFA_.FirstOrDefault(x => player.Position.IsInRange(new Vector3(x.posX, x.posY, x.posZ), 1.5f));
                if(ffaZone != null && !player.IsInVehicle)
                {
                    FFAHandler.openFFABrowser(player, ffaZone);
                    return;
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
