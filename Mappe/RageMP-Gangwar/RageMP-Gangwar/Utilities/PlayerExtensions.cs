using GTANetworkAPI;
using RageMP_Gangwar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RageMP_Gangwar.Utilities
{
    public static partial class PlayerExtensions
    {
        public static bool IsInRange(this Vector3 currentPosition, Vector3 otherPosition, float distance)
            => currentPosition.DistanceTo(otherPosition) <= distance;

        public static void setAccountId(this Client player, int id)
        {
            if (player == null || !player.Exists) return;
            player.SetData("accountId", id);
        }

        public static int getAccountId(this Client player)
        {
            if (player == null || !player.Exists) return 0;
            return player.GetData("accountId");
        }

        public static bool hasAccountId(this Client player)
        {
            if (player == null || !player.Exists) return false;
            return player.HasData("accountId");
        }

        public static int getAdminLevel(this Client player)
        {
            if (player == null || !player.Exists) return 0;
            var playerDb = ServerAccounts.Accounts_.FirstOrDefault(x => x.socialClub == player.SocialClubName && player.getAccountId() == x.playerId);
            return playerDb == null ? 0 : Convert.ToInt32(playerDb.adminRank);
        }

        public static int getcurrentDuellPartner(this Client player)
        {
            if (player == null || !player.Exists) return 0;
            var playerDb = ServerAccounts.Accounts_.FirstOrDefault(x => x.socialClub == player.SocialClubName && player.getAccountId() == x.playerId);
            return playerDb == null ? 0 : Convert.ToInt32(playerDb.currentDuellPartner);
        }

        public static bool isChatMuted(this Client player)
        {
            if (player == null || !player.Exists) return false;
            var playerDb = ServerAccounts.Accounts_.FirstOrDefault(x => x.socialClub == player.SocialClubName && player.getAccountId() == x.playerId);
            return playerDb == null ? false : Convert.ToBoolean(playerDb.isMuted);
        }
    }
}
