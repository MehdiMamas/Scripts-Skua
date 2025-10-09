/*
name: [Script Name Here]
description: [Brief description of what this script does]
tags: [comma-separated tags relevant to this script]
*/

//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;

public class FreeAcs
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }
    private static CoreFarms _Farm;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        GetYourAcsHere();

        Core.SetOptions(false);
    }

    public void GetYourAcsHere()
    {
        // if (Core.isCompletedBefore(0000))
        // {
        //     Core.Logger("Quest Already Complete");
        //     return;
        // }

        Core.Logger("Quest has been Removed, blame AE");

        // Core.OneTimeMessage("WARNING", "This Quest is a ONE-TIME quest (per account).", true, true);

        // if (!Bot.Flash.CallGameFunction<bool>("world.myAvatar.isEmailVerified") || Bot.Player.Level < 20)
        // {
        //     Core.Logger("You need to be level 20 and have a verified email!");
        //     return;
        // }

        // if (!Core.isCompletedBefore(0000))
        // {
        //     Core.EnsureAccept(0000);
        //     Bot.Quests.UpdateQuest(0000);
        //     Core.EquipClass(ClassType.Solo);
        //     Core.HuntMonster("map", "mob", "item");
        //     Core.EnsureComplete(0000);
        // }
    }
}
