/*
name: Harvest Story
description: This will finish the Harvest storyline.
tags: harvest-story, seasonal, harvest-day
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/HarvestDay/CoreHarvestDay.cs

using Skua.Core.Interfaces;

public class HarvestStory
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
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

        HarvestDay.Harvest();

        Core.SetOptions(false);
    }

}
