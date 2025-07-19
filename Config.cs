﻿using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Need_for_Sleep_BZ
{
    internal class Config
    {
        public static ConfigEntry<int> hoursNeedToSleep;
        public static ConfigEntry<float> calorieBurnMultSleep;
        public static ConfigEntry<bool> sleepAnytime;
        public static ConfigEntry<bool> showTimeTillTired;
        public static ConfigEntry<bool> showTimeTillTireSleepButton;
        public static ConfigEntry<bool> delayButtons;
        public static ConfigEntry<bool> turnSensivity;
        public static ConfigEntry<bool> blurryVision;
        public static ConfigEntry<bool> slowerMovement;
        public static ConfigEntry<SleepButton> sleepButton;
        public enum SleepButton { Left_hand, Right_hand, Jump, Deconstruct, Tool_alt_use, Reload, Sprint };


        public static void Bind()
        {
            hoursNeedToSleep = Main.config.Bind("", "Hours you need to sleep", 6, "Number of hours you need to sleep every 24 hours.");
            calorieBurnMultSleep = Main.config.Bind("", "Calorie burn rate multiplier when sleeping", 0f, "");
            sleepAnytime = Main.config.Bind("", "Can go to sleep anytime", false, "By default you can fall sleep only when you are tired. If this is on, you can fall sleep anytime.");
            sleepButton = Main.config.Bind("", "Sleep button", SleepButton.Left_hand, "");
            showTimeTillTired = Main.config.Bind("", "Show time you will get tired when looking at bed", true, "");
            showTimeTillTireSleepButton = Main.config.Bind("", "Show time you will get tired when pressing sleep button", false, "");
            delayButtons = Main.config.Bind("", "Actions are less responsive when sleep deprived", true, "");
            turnSensivity = Main.config.Bind("", "Turning around is less responsive when sleep deprived", true, "");
            blurryVision = Main.config.Bind("", "Blurry vision when sleep deprived", true, "");
            slowerMovement = Main.config.Bind("", "Slower movement when sleep deprived", true, "");



        }

    }
}
