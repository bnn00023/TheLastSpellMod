using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using TheLastStand.Definition.Unit;
using TheLastStand.Model.Unit;
using UnityEngine;
using static TheLastStand.Model.Unit.UnitLevelUp;

namespace TheLastSpellMod
{
    public static class UnitLevelUpDefinitionPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnitLevelUpDefinition), nameof(UnitLevelUpDefinition.BonusWeights), MethodType.Getter)]
        public static void UnitLevelUpDefinition_BonusWeights_Postfix(Dictionary<UnitLevelUp.E_StatLevelUpRarity, int> __result)
        {
            var name = MethodBase.GetCurrentMethod().Name;
            Debug.Log($"{name} 執行中");
            __result[E_StatLevelUpRarity.BigRarity] = 100;
            __result[E_StatLevelUpRarity.SmallRarity] = 0;
            __result[E_StatLevelUpRarity.MediumRarity] = 0;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnitLevelUpDefinition), nameof(UnitLevelUpDefinition.MaxAmountOfReroll), MethodType.Getter)]
        public static void UnitLevelUpDefinition_MaxAmountOfReroll_Postfix(ref int __result)
        {
            var name = MethodBase.GetCurrentMethod().Name;
            Debug.Log($"{name} 執行中");
            __result = 10;
        }
    }
}
