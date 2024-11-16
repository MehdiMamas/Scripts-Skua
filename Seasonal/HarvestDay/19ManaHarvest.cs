/*
name: Mana Harvest Story
description: This will finish the Mana Harvest storyline.
tags: manaharvest,mana harvest, seasonal, harvest-day,mana,harvest
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/HarvestDay/CoreHarvestDay.cs
using Skua.Core.Interfaces;

public class ManaHarvest
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new();
    public CoreHarvestDay HarvestDay = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        HarvestDay.ManaHarvest();

        Core.SetOptions(false);
    }
}
