using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using RageMP_Gangwar.Utilities;
using RageMP_Gangwar.Models;

namespace RageMP_Gangwar.Functions
{
    public static class AccountsFunctions
    {
        public static void GiveWeapons(Client player)
        {
			try
			{
				if (player == null || !player.Exists || !player.hasAccountId() || ServerAccounts.GetAccountSelectedTeam(player.getAccountId()) <= 0) return;
                player.GiveWeapon(WeaponHash.HeavyPistol, 9999);
                player.GiveWeapon(WeaponHash.BullpupRifle, 9999);
                player.GiveWeapon(WeaponHash.AdvancedRifle, 9999);
                player.GiveWeapon((WeaponHash)1649403952, 9999);
                player.GiveWeapon(WeaponHash.Gusenberg, 9999);
             
            }
			catch (Exception e)
			{
				Console.WriteLine($"{e}");		
			}
        }

        [RemoteEvent("Server:Kick:Kick")]
        public static void Kick_Event(Client player, string msg)
        {
            if (player == null || !player.Exists) return;
            player.Kick(msg);
        }
    }
}
