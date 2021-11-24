using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using RageMP_Gangwar.Utilities;
using RageMP_Gangwar.Models;

namespace RageMP_Gangwar.Functions
{
    public class ClothesFunctions
    {
        public static void setCorrectTeamClothes(Client player)
        {
			try
			{
				if (player == null || !player.Exists || !player.hasAccountId() || ServerAccounts.GetAccountSelectedTeam(player.getAccountId()) <= 0) return;
				int teamId = ServerAccounts.GetAccountSelectedTeam(player.getAccountId());
				if (teamId <= 0) return;
				var factionClothes = ServerFactions.GetFactionsClothes(teamId);
				if (factionClothes == null) return;
				player.SetAccessories(0, factionClothes.hat, factionClothes.hatTex);
				player.SetAccessories(1, factionClothes.glasses, factionClothes.glassesTex);
				player.SetClothes(1, factionClothes.mask, factionClothes.maskTex);
				player.SetClothes(3, factionClothes.torso, 0);
				player.SetClothes(4, factionClothes.leg, factionClothes.legTex);
				player.SetClothes(5, factionClothes.bag, factionClothes.bagTex);
				player.SetClothes(6, factionClothes.shoes, factionClothes.shoesTex);
				player.SetClothes(7, factionClothes.accessories, factionClothes.accessoriesTex);
				player.SetClothes(8, factionClothes.undershirt, factionClothes.undershirtTex);
				player.SetClothes(11, factionClothes.top, factionClothes.topTex);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e}");
			}
        }
    }
}
