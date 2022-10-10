using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using TheLastStand.Definition.Unit;
using TheLastStand.Model.Unit;
using UnityEngine;
using static TheLastStand.Model.Unit.UnitLevelUp;

namespace TheLastSpellMod
{
    public class UnitLevelUpStatDefinitionPatch
    {
        private static Dictionary<UnitStatDefinition.E_Stat, bool> dic = new Dictionary<UnitStatDefinition.E_Stat, bool>();
        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnitLevelUpStatDefinition), nameof(UnitLevelUpStatDefinition.Bonuses), MethodType.Getter)]
        public static void UnitLevelUpStatDefinition_Bonuses_Postfix(Dictionary<E_StatLevelUpRarity, int> __result, UnitLevelUpStatDefinition __instance)
        {
            var name = MethodBase.GetCurrentMethod().Name;
            Debug.Log($"{name} 執行中");
            if (!dic.ContainsKey(__instance.Stat))
            {
                if (__result.ContainsKey(E_StatLevelUpRarity.BigRarity)) 
                    __result[E_StatLevelUpRarity.BigRarity] = __result[E_StatLevelUpRarity.BigRarity] * 2;
                if (__result.ContainsKey(E_StatLevelUpRarity.MediumRarity))
                    __result[E_StatLevelUpRarity.MediumRarity] = __result[E_StatLevelUpRarity.MediumRarity] * 2;
                if (__result.ContainsKey(E_StatLevelUpRarity.SmallRarity))
                    __result[E_StatLevelUpRarity.SmallRarity] = __result[E_StatLevelUpRarity.SmallRarity] * 2;
                dic[__instance.Stat] = true;
            }
        }
    }
}
