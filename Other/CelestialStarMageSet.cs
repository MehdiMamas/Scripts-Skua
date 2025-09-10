/*
name: celestial starmage set
description: farms the starmage set from "Star Light, Star Bright"
tags: starmage, set, star light, star bright
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/SepulchureSaga/CoreSepulchure.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class CelestialStarMageSet
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
public CoreSepulchure CoreSS
{
    get => _CoreSS ??= new CoreSepulchure();
    set => _CoreSS = value;
}
public CoreSepulchure _CoreSS;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetSet();

        Core.SetOptions(false);
    }

    public void GetSet()
    {
        CoreSS.ShadowfallRise();
        List<ItemBase> RewardOptions = Core.EnsureLoad(6592).Rewards;

        foreach (ItemBase item in RewardOptions)
            Core.AddDrop(item.Name);

        Core.EquipClass(ClassType.Solo);

        foreach (ItemBase Reward in RewardOptions)
        {
            if (Core.CheckInventory(Reward.Name, toInv: false))
                return;
            Core.FarmingLogger(Reward.Name, 1);

            Core.EnsureAccept(6592);
            Core.HuntMonster("lumafortress", "Light Elemental", "Light Particles", 5, log: false);
            Core.EnsureComplete(6592, Reward.ID);
            Core.JumpWait();
            Core.ToBank(Reward.Name);
        }
    }
}
