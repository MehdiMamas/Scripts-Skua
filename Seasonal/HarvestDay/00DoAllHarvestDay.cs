/*
name: Harvest Day All Stories
description: This will finish the entire Harvest Day storylines.
tags: harvest-day-stories, seasonal, harvest-day
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/HarvestDay/CoreHarvestDay.cs

using Skua.Core.Interfaces;

public class DoAllHarvestDay
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

        HarvestDay.DoAll();

        Core.SetOptions(false);
    }

}
