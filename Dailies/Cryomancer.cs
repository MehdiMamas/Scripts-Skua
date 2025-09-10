/*
name: Cryomancer Daily
description: Cryomancer
tags: daily, cryomancer, class, seasonal
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;

public class Cryomancer
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
public CoreDailies _Daily;

public GlaceraStory Glac
{
    get => _Glac ??= new GlaceraStory();
    set => _Glac = value;
}
public GlaceraStory _Glac;

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

private CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
private CoreAdvanced _Adv;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoCryomancer();

        Core.SetOptions(false);
    }

    public void DoCryomancer(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Cryomancer"))
        {
            if (rankUpClass)
                Adv.RankUpClass("Cryomancer");
            return;
        }

        // Enable Cryomancer bool to return early 
        if (!Core.isCompletedBefore(3937))
            Glac.DoAll(true);
            
        Daily.Cryomancer();

        if (rankUpClass)
            Adv.RankUpClass("Cryomancer");
    }

}
