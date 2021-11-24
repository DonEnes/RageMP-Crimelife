using GTANetworkAPI;
using Newtonsoft.Json;
using RageMP_Gangwar.dbmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RageMP_Gangwar.Utilities;

namespace RageMP_Gangwar.Models
{
    public class ServerVehicles
    {
        public static List<dbmodels.ServerPrestigeVehicles> ServerPrestigeVehicles_ = new List<dbmodels.ServerPrestigeVehicles>();
        public static List<dbmodels.ServerPrivateVehicles> ServerPrivateVehicles_ = new List<dbmodels.ServerPrivateVehicles>();

        public static void CreatePrivateVehicle(int accId, uint hash, string displayName)
        {
            try
            {
                var vehData = new dbmodels.ServerPrivateVehicles
                {
                    accountId = accId,
                    hash = hash,
                    displayName = displayName
                };

                ServerPrivateVehicles_.Add(vehData);
                using (gtaContext db = new gtaContext())
                {
                    db.ServerPrivateVehicles.Add(vehData);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        public static void RemovePrivateVehicle(int accId, uint hash)
        {
            try
            {
                var vehData = ServerPrivateVehicles_.FirstOrDefault(x => x.accountId == accId && x.hash == hash);
                if(vehData != null)
                {
                    ServerPrivateVehicles_.Remove(vehData);
                    using (var db = new gtaContext())
                    {
                        db.ServerPrivateVehicles.Remove(vehData);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        public static void GetPrestigeVehicles(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                var items = ServerPrestigeVehicles_.Where(x => x.neededLevel <= Models.ServerAccounts.GetPrestigeLevel(player.getAccountId())).Select(x => new
                {
                    x.displayName,
                    x.neededLevel,
                }).OrderBy(x => x.neededLevel).ToList();

                var itemCount = (int)items.Count;
                var iterations = Math.Floor((decimal)(itemCount / 5));
                var rest = itemCount % 5;
                for(var i = 0; i < iterations; i++)
                {
                    var skip = i * 5;
                    player.TriggerEvent("Client:Garage:setPrestigeCars", JsonConvert.SerializeObject(items.Skip(skip).Take(5).ToList()));
                }

                if (rest != 0) player.TriggerEvent("Client:Garage:setPrestigeCars", JsonConvert.SerializeObject(items.Skip((int)iterations * 5).ToList()));
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        public static void GetPrivateVehicles(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                var items = ServerPrivateVehicles_.Where(x => x.accountId == player.getAccountId()).Select(x => new
                {
                    x.displayName,
                }).ToList();

                var itemCount = (int)items.Count;
                var iterations = Math.Floor((decimal)(itemCount / 5));
                var rest = itemCount % 5;
                for(var i = 0; i < iterations; i++)
                {
                    var skip = i * 5;
                    player.TriggerEvent("Client:Garage:setPrivateCars", JsonConvert.SerializeObject(items.Skip(skip).Take(5).ToList()));
                }

                if (rest != 0) player.TriggerEvent("Client:Garage:setPrivateCars", JsonConvert.SerializeObject(items.Skip((int)iterations * 5).ToList()));
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        public static bool ExistPrivateVehicleByDisplayName(int accId, string displayName)
        {
            try
            {
                var vehData = ServerPrivateVehicles_.FirstOrDefault(x => x.accountId == accId && x.displayName == displayName);
                if (vehData != null) return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            return false;
        }

        public static bool ExistPrivateVehicleByHash(int accId, uint hash)
        {
            try
            {
                var vehData = ServerPrivateVehicles_.FirstOrDefault(x => x.accountId == accId && x.hash == hash);
                if (vehData != null) return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            return false;
        }

        public static uint GetPrivateVehicleHashByName(int accId, string displayName)
        {
            try
            {
                var vehData = ServerPrivateVehicles_.FirstOrDefault(x => x.accountId == accId && x.displayName == displayName);
                if (vehData != null) return vehData.hash;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            return 0;
        }

        public static uint GetPrestigeVehicleHashByName(string displayName)
        {
            try
            {
                var vehData = ServerPrestigeVehicles_.FirstOrDefault(x => x.displayName == displayName);
                if (vehData != null) return vehData.hash;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            return 0;
        }

        public static int GetPrestigeVehicleLevel(uint hash)
        {
            try
            {
                var vehData = ServerPrestigeVehicles_.FirstOrDefault(x => x.hash == hash);
                if (vehData != null) return vehData.neededLevel;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            return 0;
        }

        public static bool HasPlayerAccessToPrestigeCar(int prestigeLevel, string displayName)
        {
            try
            {
                var vehData = ServerPrestigeVehicles_.FirstOrDefault(x => x.neededLevel <= prestigeLevel && x.displayName == displayName);
                if (vehData != null) return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            return false;
        }
    }
}
