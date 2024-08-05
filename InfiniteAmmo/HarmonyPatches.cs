using HarmonyLib;
using UnityEngine;
using VTOLAPI;

namespace InfiniteAmmoattempt3
{

    [HarmonyPatch(typeof(Gun), nameof(Gun.FireBullet))]
    public class gunPatch
    {
        public static void Postfix()
        {
            var wm = VTAPI.GetPlayersVehicleGameObject().GetComponent<WeaponManager>();
            HPEquipGun equip = wm.currentEquip as HPEquipGun;
            Gun gun = equip.gun;
            gun.currentAmmo = gun.maxAmmo;
        }
    }

    [HarmonyPatch(typeof(RocketLauncher), nameof(RocketLauncher.FireRocket))]
    public class rocketPatch
    {
        public static void Postfix()
        {
            var wm = VTAPI.GetPlayersVehicleGameObject().GetComponent<WeaponManager>();
            RocketLauncher equip = wm.currentEquip as RocketLauncher;
            equip.LoadRocket();
        }
    }

    [HarmonyPatch(typeof(MissileLauncher), nameof(MissileLauncher.FinallyFire))]
    public class IWBPatch
    {
        public static void Postfix()
        {
            //Debug.Log("FinallyFired!");
            var wm = VTAPI.GetPlayersVehicleGameObject().GetComponent<WeaponManager>();
            HPEquipMissileLauncher equip = wm.currentEquip as HPEquipMissileLauncher;
            //Debug.Log("Test");
            var ml = equip.GetComponentsInChildren<MissileLauncher>();
            foreach (var m in ml)
            {
                Debug.Log(m.missiles.Length);
                m.LoadAllMissiles();
            }

        }
    }

}