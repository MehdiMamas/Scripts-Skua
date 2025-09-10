/*
name: Legion Exercise Number 4
description: This script will complete "Legion Exercise Number 4" quest.
tags: legion, exercise, legion exercise, 4, corrupted, corrupted dragon, corrupted dragon slayer, judgement, judgement scythe, painsaw, painsaw of eidolon, soul eater, soul eater advanced
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class LegionExercise4
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public CoreLegion Legion
{
    get => _Legion ??= new CoreLegion();
    set => _Legion = value;
}
public CoreLegion _Legion;

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;


    private string[] Rewards = { "Corrupted Dragon Slayer", "Judgement Scythe", "PainSaw of Eidolon", "Soul Eater Advanced", "Legion Token" };

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

        while (!Bot.ShouldExit && !Core.CheckInventory(new[] { "Corrupted Dragon Slayer", "Judgement Scythe", "PainSaw of Eidolon", "Soul Eater Advanced" }))
        {
            Core.EnsureAccept(824);
            Core.EquipClass(ClassType.Farm);
            Core.KillMonster("doomhaven", "r4", "Down", "Skeletal Ice Mage", "Frostbit Skull", 15);
            Core.HuntMonster("Marsh2", "Lesser Shadow Serpent", "Potent Viper's Blood");
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("Marsh2", "Soulseeker", "Soul Scythe", isTemp: false);
            Core.EnsureComplete(824);
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
