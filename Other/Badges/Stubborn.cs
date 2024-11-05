/*
name: Stubborn
description: null
tags: badge, Stubborn
*/
//cs_include Scripts/CoreBots.cs
using Skua.Core.Interfaces;

public class Stubborn
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Badge();

        Core.SetOptions(false);
    }

    public void Badge()
    {

        if (Core.HasAchievement(56) || !Bot.Player.IsMember)
        {
            Core.Logger($"Already have the \"Stubborn\" badge");
            return;
        }

        //ensure private...because yes
        Core.Join("twig-100000");
        int i = 0;
        while (!Bot.ShouldExit && i < 100)
        {
            //leave autocorrect enabled as it double jumps and gest it done quicker.
            Bot.Map.Jump("r2", "left");
            i++;
            if (i >= 100)
                break;
        }
    }
}
