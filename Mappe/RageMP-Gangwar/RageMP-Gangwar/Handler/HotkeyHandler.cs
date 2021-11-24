using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using RageMP_Gangwar.Utilities;

namespace RageMP_Gangwar.Handler
{
    public class HotkeyHandler : Script
    {
        [RemoteEvent("Server:User:useFirstAidKit")]
        public void useFirstAidKit(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                NAPI.Player.PlayPlayerAnimation(player, (int)(Constants.AnimationFlags.Loop | Constants.AnimationFlags.AllowPlayerControl), "anim@heists@narcotics@funding@gang_idle", "gang_chatting_idle01");
                NAPI.Task.Run(() =>
                {
                    player.Health = 100;
                    NAPI.Player.StopPlayerAnimation(player);
                }, delayTime: 4000);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [RemoteEvent("Server:User:useVest")]
        public void useVest(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId()) return;
                NAPI.Player.PlayPlayerAnimation(player, (int)(Constants.AnimationFlags.Loop | Constants.AnimationFlags.AllowPlayerControl), "anim@heists@narcotics@funding@gang_idle", "gang_chatting_idle01");
                NAPI.Task.Run(() =>
                {
                    NAPI.Player.StopPlayerAnimation(player);
                    player.Armor = 100;
                    player.SetClothes(9, 15, 2);
                }, delayTime: 4000);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        [RemoteEvent("Server:User:repairVehicle")]
        public void repairVehicle(Client player)
        {
            try
            {
                if (player == null || !player.Exists || !player.hasAccountId() || player.IsInVehicle) return;
                var Vehicle = Helper.GetClosestVehicle(player, 5f);
                if (Vehicle == null) return; 
                NAPI.Player.PlayPlayerAnimation(player, (int)(Constants.AnimationFlags.Loop | Constants.AnimationFlags.AllowPlayerControl), "anim@heists@narcotics@funding@gang_idle", "gang_chatting_idle01");
                Vehicle.Repair();
                NAPI.Task.Run(() =>
                {
                    player.StopAnimation();
                    player.SendChatMessage($"Fahrzeug erfolgreich repartiert.");
                }, delayTime: 4000);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                throw;
            }
        }
    }
}
