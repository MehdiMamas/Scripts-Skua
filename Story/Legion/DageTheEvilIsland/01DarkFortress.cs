/*
name: Dark Fortress
description: This will finish the Dark Fortress quest.
tags: story, quest, legion, dage-the-evil-island, dark-fortress
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Legion/DageTheEvilIsland/CoreDageTheEvilIsland.cs

using Skua.Core.Interfaces;

public class DarkFortress
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreDageTheEvilIsland CoreDageTheEvilIsland
{
    get => _CoreDageTheEvilIsland ??= new CoreDageTheEvilIsland();
    set => _CoreDageTheEvilIsland = value;
}
public CoreDageTheEvilIsland _CoreDageTheEvilIsland;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        CoreDageTheEvilIsland.DarkFortress();

        Core.SetOptions(false);
    }

}
