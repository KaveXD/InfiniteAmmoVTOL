global using static InfiniteAmmo.Logger;
using ModLoader.Framework;
using ModLoader.Framework.Attributes;
using System.Reflection;
using VTOLAPI;

namespace InfiniteAmmo
{
    [ItemId("kave.infiniteammo")] // Harmony ID for your mod, make sure this is unique
    public class Main : VtolMod
    {
        public string ModFolder;

        private void Awake()
        {
            ModFolder = Assembly.GetExecutingAssembly().Location;
            Log($"Awake at {ModFolder}");
        }

        public override void UnLoad()
        {
            // Destroy any objects
        }
    }
}