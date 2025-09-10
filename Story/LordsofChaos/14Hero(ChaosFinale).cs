/*
name: (Chaos Finale) Hero
description: This will finish the Hero quest.
tags: story, quest, chaos-saga, 13-lords-of-chaos, chaos-finale, hero
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;

public class SagaChaosFinale
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

    public Core13LoC LOC => new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        LOC.Hero();

        Core.SetOptions(false);
    }
}
