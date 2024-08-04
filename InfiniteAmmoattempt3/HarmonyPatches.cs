using Harmony;
using UnityEngine;

namespace InfiniteAmmoattempt3
{
    //[HarmonyPatch(typeof(MissileLauncher), nameof(MissileLauncher.FireMissile))]
    //public class ammoPatch
    //{
    //    public static void Postfix()
    //    {
    //        Main.MissileFired();
    //    }
    //}

    //[HarmonyPatch(typeof(MissileLauncher), nameof(MissileLauncher.IWBFireRoutine))]
    //public class internalMissilePatch
    //{
    //    public static void Postfix()
    //    {
    //        Main.internalMissileFired();
    //    }
    //}




    [HarmonyPatch(typeof(Gun), nameof(Gun.FireBullet))]
    public class gunPatch
    {
        public static void Postfix()
        {
            Main.ShotFired();
        }
    }

    [HarmonyPatch(typeof(RocketLauncher), nameof(RocketLauncher.FireRocket))]
    public class rocketPatch
    {
        public static void Postfix()
        {
            Main.FireRocket();
        }
    }

    [HarmonyPatch(typeof(MissileLauncher), nameof(MissileLauncher.FinallyFire))]
    public class IWBPatch
    {
        public static void Postfix()
        {
            Main.finallyFire();


        }
    }

}