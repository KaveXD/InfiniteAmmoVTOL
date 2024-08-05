using UnityEngine;

namespace InfiniteAmmo
{
    public class Logger
    {
        private static readonly string ModName = "InfiniteAmmo";

        public static void Log(string text)
        {
            Debug.Log($"[{ModName}]: {text}");
        }

        public static void LogError(string text)
        {
            Debug.LogError($"[{ModName}]: {text}");
        }
    }
}