/*
name: Vampiric Knight And Blood Guardian
description: Gets the Vampiric Knight And Blood Guardian Armors
tags: vampiric knight, blood guardian, armor
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/BloodMoon.cs
using Skua.Core.Interfaces;

public class VampiricKnightAndBloodGuardian
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static BloodMoon BloodMoon { get => _BloodMoon ??= new BloodMoon(); set => _BloodMoon = value; }    private static BloodMoon _BloodMoon;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetAll();

        Core.SetOptions(false);
    }

    public void GetAll()
    {
        string[] AllRewards = (Core.EnsureLoad(6068).Rewards.Select(i => i.Name)).Concat(Core.EnsureLoad(6069).Rewards.Select(i => i.Name)).Concat(Core.EnsureLoad(6070).Rewards.Select(i => i.Name)).ToArray();

        if (Core.CheckInventory(AllRewards, toInv: false))
            return;

        BloodMoon.BloodMoonSaga();
        Bot.Drops.Add(AllRewards);

        Core.EquipClass(ClassType.Farm);

        Core.RegisterQuests(6068, 6069, 6070);
        while (!Bot.ShouldExit && !Core.CheckInventory(AllRewards, toInv: false))
            //Lycan Medals 6068 //Mega Lycan Medals 6069 //Vampire Medals 6070
            Core.KillMonster("BloodWarVamp", "r5", "Left", "*", log: false);
        Core.JumpWait();
        Core.ToBank(AllRewards);
    }

    // while (!Bot.ShouldExit && !Core.CheckInventory(Quest2Rewards, toInv: false))
    //     //Mega Lycan Medals 6069
    //     Core.HuntMonster("BloodWarVamp", "Lunar Blazebinder", "Mega Lycan Medal", 3);
    // Core.JumpWait();
    // Core.ToBank(Quest2Rewards);

    // while (!Bot.ShouldExit && !Core.CheckInventory(Quest3Rewards, toInv: false))
    //     //Blackened Incense 6072
    //     Core.HuntMonster("BloodWarVamp", "Lunar Blazebinder", "Blackened Incense", 5);
    // Core.CancelRegisteredQuests();
    // Core.JumpWait();
    // Core.ToBank(Quest3Rewards);


    // }
}
