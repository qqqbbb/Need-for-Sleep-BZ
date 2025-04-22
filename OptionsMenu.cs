using HarmonyLib;
using Nautilus.Options;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Need_for_Sleep_BZ
{
    public class OptionsMenu : ModOptions
    {
        public OptionsMenu() : base("Need for Sleep")
        {
            ModSliderOption hoursNeedToSleepSlider = Config.hoursNeedToSleep.ToModSliderOption(3, 12, 1);
            ModSliderOption calorieBurnMultSleepSlider = Config.calorieBurnMultSleep.ToModSliderOption(0, 1f, .01f, "{0:0.0.#}");


            AddItem(hoursNeedToSleepSlider);
            AddItem(calorieBurnMultSleepSlider);
            AddItem(Config.sleepAnytime.ToModToggleOption());
            AddItem(Config.showTimeTillTired.ToModToggleOption());
            AddItem(Config.sleepButton.ToModChoiceOption());

        }
    }
}
