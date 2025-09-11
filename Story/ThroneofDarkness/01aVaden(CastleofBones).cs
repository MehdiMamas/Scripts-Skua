/*
name: (Vaden) Castle of Bones Story
description: This will finish the Castle of Bones story.
tags: castle, bones, farm, story, vaden, throne, darkness
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
using Skua.Core.Interfaces;

public class CastleofBones
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreToD TOD { get => _TOD ??= new CoreToD(); set => _TOD = value; }    private static CoreToD _TOD;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        TOD.CastleofBones();

        Core.SetOptions(false);
    }
}
