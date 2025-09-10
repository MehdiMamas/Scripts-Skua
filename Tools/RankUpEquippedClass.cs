/*
name: RankUpEquippedClass
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class RankUpEquippedClass
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions(disableClassSwap: true);

        DoRankUpEquippedClass();

        Core.SetOptions(false);
    }

    public void DoRankUpEquippedClass()
    {
        if (Bot.Player.CurrentClass != null)
        {
            if (Bot.Player.CurrentClassRank < 10)
            {
                Adv.RankUpClass(Bot.Player.CurrentClass.Name);
            }
            else
            {
                Core.Logger($"{Bot.Player.CurrentClass.Name} is already at max rank.");
            }
        }
        else
        {
            Core.Logger("No class is currently equipped.");
        }
    }
}
