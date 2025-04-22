﻿using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using FMOD;
using HarmonyLib;
using Nautilus.Handlers;
using Nautilus.Options;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Need_for_Sleep_BZ
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class Main : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "qqqbbb.subnauticaBZ.NeedForSleep";
        public const string PLUGIN_NAME = "Need for Sleep";
        public const string PLUGIN_VERSION = "1.0.0";
        public static ManualLogSource logger { get; private set; }
        static string configPath = Paths.ConfigPath + Path.DirectorySeparatorChar + PLUGIN_NAME + Path.DirectorySeparatorChar + "Config.cfg";
        public static ConfigFile config;
        internal static OptionsMenu options;
        public static bool gameLoaded;
        public static bool enhancedSleepLoaded;
        public static bool tweaksFixesLoaded;

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            logger = base.Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), $"{PLUGIN_GUID}");
            SaveUtils.RegisterOnQuitEvent(OnQuit);
            LanguageHandler.RegisterLocalizationFolder();
            config = new ConfigFile(configPath, false);
            Need_for_Sleep_BZ.Config.Bind();
            options = new OptionsMenu();
            OptionsPanelHandler.RegisterModOptions(options);
            GetLoadedMods();
            Logger.LogInfo($"Plugin {PLUGIN_GUID} {PLUGIN_VERSION} is loaded ");
        }

        [HarmonyPatch(typeof(WaitScreen), "Hide")]
        internal class WaitScreen_Hide_Patch
        {
            public static void Postfix(WaitScreen __instance)
            {
                LoadedGameSetup();
            }
        }

        static void LoadedGameSetup()
        {
            gameLoaded = true;
            Patches.Setup();
        }

        private void OnQuit()
        {
            //Logger.LogDebug("Need for Sleep OnQuit");
            Patches.ResetVars();
            gameLoaded = false;
        }

        public static void GetLoadedMods()
        {
            enhancedSleepLoaded = Chainloader.PluginInfos.ContainsKey("Cookay_EnhancedSleep");
            tweaksFixesLoaded = Chainloader.PluginInfos.ContainsKey("qqqbbb.subnauticaBZ.tweaksAndFixes");
        }



    }
}