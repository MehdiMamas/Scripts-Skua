/*
name: Legion Exercise Number 2
description: This script will complete "Legion Exercise Number 2" quest.
tags: legion exercise, 2, executioner, executioner's judgement, legion, undead champion
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/JoinLegion[UndeadWarrior].cs
using Skua.Core.Interfaces;

public class LegionExercise2
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;
    private static CoreLegion Legion { get => _Legion ??= new CoreLegion(); set => _Legion = value; }    private static CoreLegion _Legion;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }    private static CoreStory _Story;

    private string[] Rewards = { "Executioner's Judgement", "legion Token" };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Exercise(Rewards);

        Core.SetOptions(false);
    }

    public void Exercise(string[] item)
    {
        if (Core.CheckInventory(item))
            return;
        Core.AddDrop(item);

        Legion.JoinLegion();
        Core.BuyItem("underworld", 216, "Undead Champion");

        Core.Logger("Disclaimer: Percentages are randomized, just made purely for fun. i cba making it an actualy %age");

        int Dice = Bot.Random.Next(1, 101);
        //-------------------------------------------------------------------------------------------------------

        int i = 1;
        var displayPercentage = $"{(decimal)Dice / 100:P}";

        Core.Logger($"Potato Prediction Inc. Decided: {displayPercentage} is The Chance for Desired Rewards.");

        while (!Bot.ShouldExit && !Core.CheckInventory(new[] { "Executioner's Judgement" }))
        {
            Core.EnsureAccept(822);
            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("darkoviagrave", "Skeletal Fire Mage", "Charred Skull", 20, isTemp: false, publicRoom: false);
            Core.HuntMonster("mudluk", "Tiger Leech", "Intact Tiger Leech Hide", publicRoom: false);
            Core.Sleep(2500);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("sewer", "Grumble", "Grumble's Curse", isTemp: false, publicRoom: false);
            Core.EnsureComplete(822);
            Core.Logger($"Finished Quest {i++} Times");
        }

        Core.Logger($"Farming {item} Took {i++} Times");

        if (i++ > Dice)
            Core.Logger($"Perdiction: {displayPercentage} May have been a bit Low");
        if (i++ < Dice)
            Core.Logger($"Perdiction: {displayPercentage} Was waaaay to high... Congratulations!");

        Core.ToBank(Rewards);
    }

}
