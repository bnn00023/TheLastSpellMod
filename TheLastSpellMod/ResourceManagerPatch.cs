using HarmonyLib;
using System.Reflection;
using TheLastStand.Manager;
using TPLib;
using UnityEngine;

namespace TheLastSpellMod
{
    public class ResourceManagerPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ResourceManager), nameof(ResourceManager.SetGold))]
        public static bool ResourceManager_SetGold_Prefix(ref int newValue, bool updateGoldMetaConditions)
        {
            var name = MethodBase.GetCurrentMethod().Name;
            Debug.Log($"{name} 執行中");
            if (newValue > TPSingleton<ResourceManager>.Instance.Gold)
            {
                var diffValue = newValue - TPSingleton<ResourceManager>.Instance.Gold;
                newValue = TPSingleton<ResourceManager>.Instance.Gold + diffValue * 2;
            }
            return true;
        }
    }
}
