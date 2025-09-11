/*
name: AssistingOblivionBlade
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class AssistingOblivionBlade
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static CoreNation Nation { get => _Nation ??= new CoreNation(); set => _Nation = value; }    private static CoreNation _Nation;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        doit();

        Core.SetOptions(false);
    }

    public void doit()
    {
        if (!Core.IsMember)
            return;

        if (!Core.CheckInventory("The Secret 2"))
            return;

        if (!Core.CheckInventory("Tendurrr The Assistant"))
            Core.KillMonster("tercessuinotlim", "m2", "Left", "*", "Tendurrr The Assistant", isTemp: false);

        List<ItemBase> RewardOptions = Core.EnsureLoad(5818).Rewards;
        List<string> RewardsList = new();
        foreach (ItemBase Item in RewardOptions)
            RewardsList.Add(Item.Name);
        string[] Rewards = RewardsList.ToArray();
        Core.AddDrop(Rewards);

        Core.RegisterQuests(5818);
        foreach (ItemBase item in RewardOptions)
        {
            while (!Bot.ShouldExit && !Core.CheckInventory(item.ID, item.MaxStack))
            {
                Farm.TheSecret4();
                Nation.EssenceofNulgath(20);
                Nation.ApprovalAndFavor(50, 50);
                Core.KillMonster("boxes", "Fort2", "Left", "*", "Cubes", 50, false);
                Core.KillMonster("shadowblast", "r13", "Left", "*", "Fiend Seal", 10, false);
                Farm.BattleUnderB(quant: 200);
                Core.Sleep();
            }
        }
        Core.CancelRegisteredQuests();
    }
}
