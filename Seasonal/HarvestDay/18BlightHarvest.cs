/*
name: Blight Harvest Story
description: This will finish the Blight Harvest storyline.
tags: blightharvest,blight harvest, seasonal, harvest-day,blight,harvest
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/HarvestDay/CoreHarvestDay.cs
using Skua.Core.Interfaces;

public class BlightHarvest
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreHarvestDay HarvestDay
{
    get => _HarvestDay ??= new CoreHarvestDay();
    set => _HarvestDay = value;
}
public CoreHarvestDay _HarvestDay;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        HarvestDay.BlightHarvest();

        Core.SetOptions(false);
    }
}
