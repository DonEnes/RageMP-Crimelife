using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RageMP_Gangwar.Utilities
{
    public class Helper : Script
    {
        public static Vehicle GetClosestVehicle(Client player, float distance)
        {
			try
			{
				if (player == null || !player.Exists) return null;
				Vehicle returned = null;
				returned = NAPI.Pools.GetAllVehicles().ToList().FirstOrDefault(x => x != null && x.Exists && player.Position.IsInRange(x.Position, distance));
				return returned;
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");
			}
			return null;
        }
    }
}
