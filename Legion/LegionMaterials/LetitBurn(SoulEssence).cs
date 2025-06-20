/*
name: LetitBurn(SoulEssence)
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/LegionMaterials/SoulSand.cs
//cs_include Scripts/Legion/Various/LegionBonfire.cs
//cs_include Scripts/Story/Legion/SeraphicWar.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class LetItBurn
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreLegion Legion = new();
    public CoreAdvanced Adv = new();
    public AnotherOneBitesTheDust SSand = new();
    public LegionBonfire Bon = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        SoulEssence();

        Core.SetOptions(false);
    }

    private readonly string[] rewards =
    {
        "Legion Undead Spawn",
        "Legion Undead Visor",
        "Legion Forge Banisher",
        "Legion Spawn Bonker"
    };

    public void SoulEssence(int quant = 50, int ChooseItem = 0)
    {
        if (Core.CheckInventory("Soul Essence", quant))
            return;

        if (ChooseItem > 0 && Core.CheckInventory(ChooseItem))
            return;

        Core.AddDrop("Soul Essence");
        if (ChooseItem > 0)
            Core.AddDrop(ChooseItem);
        else Core.AddDrop(rewards);
        Core.FarmingLogger("Soul Essence", quant);

        Farm.Experience(65);
        Bon.GetLegionBonfire();

        Core.EquipClass(ClassType.Solo);

        while (!Bot.ShouldExit && !Core.CheckInventory("Soul Essence", quant) && (ChooseItem <= 0 || !Core.CheckInventory(ChooseItem)))
        {
            Core.EnsureAccept(7992);
            Core.HuntMonster("dagefortress", "Grrrberus", "Grrberus' Flame");
            SSand.SoulSand(3);

            if (ChooseItem > 0)
            {
                if (!rewards.All(x => Core.CheckInventory(x, toInv: false)))
                    Core.EnsureCompleteChoose(7992, rewards.Where(x => !Core.CheckInventory(x)).ToArray());
                else
                    Core.EnsureComplete(7992);
            }
            else
            {
                Core.EnsureComplete(7992);
            }

            Bot.Wait.ForPickup("Soul Essence");
        }
    }
}
