/*
name: MaxDageApprovalAndFavor
description: farms DageApprovalAndFavor till max quantity
tags: legion, dage, DageApprovalAndFavor, 🖕, you
*/

//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs

using Skua.Core.Interfaces;

public class DageApprovalAndFavor
{
    public CoreBots Core => CoreBots.Instance;
    public CoreLegion CL = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetDageApprovalAndFavor();

        Core.SetOptions(false);
    }

    public void GetDageApprovalAndFavor()
    {
        CL.ApprovalAndFavor();
    }
}
