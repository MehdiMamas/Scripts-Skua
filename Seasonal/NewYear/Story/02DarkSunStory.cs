/*
name: Dark Sun Story
description: This will complete the Dark Sun story.
tags: story, quest, seasonal, new-year, dark-sun
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/NewYear/CoreNewYear.cs
using Skua.Core.Interfaces;

public class DarkSun
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreNewYear NY
{
    get => _NY ??= new CoreNewYear();
    set => _NY = value;
}
public CoreNewYear _NY;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        NY.DarkSun();

        Core.SetOptions(false);
    }

}
