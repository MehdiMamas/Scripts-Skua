/*
name: Nightmare War Story
description: This will finish the Nightmare War storyline.
tags: nightmare-war-story, seasonal, harvest-day
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/HarvestDay/CoreHarvestDay.cs

using Skua.Core.Interfaces;

public class NightmareWarStory
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }    private static CoreStory _Story;
    private static CoreHarvestDay HarvestDay { get => _HarvestDay ??= new CoreHarvestDay(); set => _HarvestDay = value; }    private static CoreHarvestDay _HarvestDay;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        HarvestDay.NightmareWar();

        Core.SetOptions(false);
    }

}
