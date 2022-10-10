using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheLastStand.Manager;
using TPLib;
using UnityEngine;

namespace TheLastSpellMod
{
    [BepInPlugin("8f52bf59-c6c4-4e0a-855b-87475094a37e", "TheLastSpellMod", "1.0.0.0")]
    public class Main : BaseUnityPlugin
    {
        void Awake()
        {
            // 使用Debug.Log()方法来将文本输出到控制台
            Debug.Log("Hello, world!");
        }

        void Start()
        {
            Logger.LogInfo("Start!!!!!!!!!!!!!!!!!!!!!!");
            var harmony = new Harmony("8f52bf59-c6c4-4e0a-855b-87475094a37e");
            harmony.PatchAll(typeof(UnitLevelUpDefinitionPatch));
            harmony.PatchAll(typeof(UnitLevelUpStatDefinitionPatch));
            harmony.PatchAll(typeof(ResourceManagerPatch));
            Logger.LogInfo($"harmony.GetPatchedMethods():{harmony.GetPatchedMethods().Count()}");
            foreach (var method in harmony.GetPatchedMethods())
            {
                Debug.Log($"{method.Name} was patch.");
            }
        }

        void Update()
        {
            var key = new BepInEx.Configuration.KeyboardShortcut(KeyCode.F9);
            if (key.IsDown())
            {
                Debug.Log("这里是Updatet()方法中的内容，你看到这条消息是因为你按下了F9");
                TPSingleton<ResourceManager>.Instance.RefillWorkers();
            }
        }

        void OnDestroy()
        {
            Debug.Log("当你看到这条消息时，就表示我已经被关闭一次了!");
        }
    }
}
