using UnityEngine;
using Harmony;
using System.Reflection;

namespace InfiniteAmmoattempt3
{

    public class Main : VTOLMOD
    {
        static WeaponManager wm { get; set; }
        public override void ModLoaded()
        {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("Kave:InfiniteAmmo");
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            Debug.Log("InfiniteAmmo Loaded!");
            base.ModLoaded();
        }

        //public static void MissileFired()
        //{
        //    wm = VTOLAPI.GetPlayersVehicleGameObject().GetComponent<WeaponManager>();
        //    HPEquipMissileLauncher equip = wm.currentEquip as HPEquipMissileLauncher;

        //    if(equip.ml.openAndCloseBayOnLaunch == true || equip.ml.iwb == true)
        //    {
        //        return;
        //    }

        //    int maxLength = equip.ml.hardpoints.Length;
        //    Debug.Log(maxLength);
        //    for(int i = 0; i < maxLength; i++) {
        //        equip.ml.LoadMissile(i);
        //        Debug.Log(i);
        //    }

        //}


        public static void ShotFired()
        {
            wm = VTOLAPI.GetPlayersVehicleGameObject().GetComponent<WeaponManager>();
            HPEquipGun equip = wm.currentEquip as HPEquipGun;
            Gun gun = equip.gun;
            gun.currentAmmo = gun.maxAmmo;
        }

        public static void FireRocket()
        {
            wm = VTOLAPI.GetPlayersVehicleGameObject().GetComponent<WeaponManager>();
                RocketLauncher equip = wm.currentEquip as RocketLauncher;
            equip.LoadRocket();
        }

        public static void finallyFire()
        {
            //Debug.Log("FinallyFired!");
            wm = VTOLAPI.GetPlayersVehicleGameObject().GetComponent<WeaponManager>();
            HPEquipMissileLauncher equip = wm.currentEquip as HPEquipMissileLauncher;
            //Debug.Log("Test");
            var ml = equip.GetComponentsInChildren<MissileLauncher>();
            foreach (var m in ml) {
                Debug.Log(m.missiles.Length);
                m.LoadAllMissiles();
            }

        }
    }
}