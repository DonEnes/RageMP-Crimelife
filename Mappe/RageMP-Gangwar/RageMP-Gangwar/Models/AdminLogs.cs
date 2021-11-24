using GTANetworkAPI;
using RageMP_Gangwar.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageMP_Gangwar.Models
{
    public class AdminLogs
    {
        public static List<dbmodels.AdminLogs> AdminLogs_ = new List<dbmodels.AdminLogs>();

        public static void AddNewAdminLog(int accountId, int targetId, string action, string description)
        {
            try
            {
                using (var db = new gtaContext())
                {
                    db.AdminLogs.Add(new dbmodels.AdminLogs
                    {
                        accountId = accountId,
                        targetId = targetId,
                        action = action,
                        description = description,
                        timestamp = DateTime.Now
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
