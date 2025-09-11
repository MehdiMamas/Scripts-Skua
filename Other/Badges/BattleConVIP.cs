/*
name: (Badge) BattleCon VIP
description: This will get the BattleCon VIP badge.
tags: badge, underground, lab, battle, con, vip
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/UnderGroundLab.cs
using Skua.Core.Interfaces;

public class BattleConVIP
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static UnderGroundLab UGL { get => _UGL ??= new UnderGroundLab(); set => _UGL = value; }    private static UnderGroundLab _UGL;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Badge();

        Core.SetOptions(false);
    }

    public void Badge()
    {
        if (Core.HasWebBadge(badge))
        {
            Core.Logger($"Already have the {badge} badge");
            return;
        }

        Core.Logger($"Doing UnderGroundLab story for {badge} badge");
        UGL.partofundergroundlabb();

    }

    private string badge = "BattleCon VIP";
}
