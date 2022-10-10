using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheLastStand.Definition.Unit;
using TheLastStand.Manager;
using TheLastStand.Model.Unit;
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
            newValue *= 2;
            return true;
        }
    }
}
