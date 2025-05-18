/*
name: WillpowerExtraction
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class WillpowerExtraction
{
    public IScriptInterface Bot = IScriptInterface.Instance;
    public static CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreAdvanced Adv = new();
    public CoreNation Nation = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops.Concat(Nation.tercessBags).Concat(new[] {"Unidentified 34", "Unidentified 19", "Necrot", "Chaoroot", "Doomatter",
            "Mortality Cape of Revontheus", "Facebreakers of Nulgath", "SightBlinder Axes of Nulgath", "Mystic Tribal Sword",
            "King Klunk's Crown", "Golden Shadow Breaker", "Shadow Terror Axe"}));

        Core.SetOptions();

        Unidentified34();

        Core.SetOptions(false);
    }

    public void Unidentified34(int quant = 300)
    {
        if (Core.CheckInventory("Unidentified 34", quant))
            return;

        Core.FarmingLogger("Unidentified 34", quant);

        Core.AddDrop(Nation.bagDrops
            .Concat(Nation.tercessBags)
            .Concat(new[]
            {
                "Unidentified 34", "Unidentified 19", "Necrot", "Chaoroot", "Doomatter",
                "Mortality Cape of Revontheus", "Facebreakers of Nulgath", "SightBlinder Axes of Nulgath",
                "Mystic Tribal Sword", "King Klunk's Crown", "Golden Shadow Breaker", "Shadow Terror Axe"
            })
            .ToArray());


        int i = 1;
        while (!Bot.ShouldExit && !Core.CheckInventory("Unidentified 34", quant))
        {
            Core.EnsureAccept(5258);

            Nation.FarmUni13(3);
            Adv.BuyItem("shadowfall", 89, "Shadow Lich");
            Adv.BuyItem("arcangrove", 214, "Mystic Tribal Sword");

            Core.EquipClass(ClassType.Farm);
            if (!Core.CheckInventory("Necrot", 5))
            {
                Adv.BuyItem("tercessuinotlim", 1951, "Necrot", 10);
                Bot.Wait.ForItemBuy();
            }
            if (!Core.CheckInventory("Chaoroot", 5))
            {
                Adv.BuyItem("tercessuinotlim", 1951, "Chaoroot", 10);
                Bot.Wait.ForItemBuy();
            }
            if (!Core.CheckInventory("Doomatter", 5))
            {
                Adv.BuyItem("tercessuinotlim", 1951, "Doomatter", 10);
                Bot.Wait.ForItemBuy();
            }
            if (!Core.CheckInventory("Mortality Cape of Revontheus"))
            {
                Nation.ApprovalAndFavor(0, 35);
                Adv.BuyItem("evilwarnul", 452, 13167);
                Bot.Wait.ForItemBuy();
            }

            Core.AddDrop(18768);
            while (!Bot.ShouldExit && !Core.CheckInventory(18768)) // "Facebreakers of Nulgath"
            {
                // "Kindness" of Nulgath
                Core.EnsureAccept(3046);
                Core.EquipClass(ClassType.Solo);
                Core.HuntMonster("citadel", "Grand Inquisitor", "Golden Shadow Breaker", 1, false);
                Core.HuntMonster("battleundera", "Bone Terror", "Shadow Terror Axe", 1, false);
                Nation.FarmDarkCrystalShard(5);
                Nation.SwindleBulk(5);
                Nation.FarmDiamondofNulgath(1);
                Core.EnsureComplete(3046, 18768);

                Bot.Wait.ForDrop(18768);
                Bot.Wait.ForPickup(18768);

                if (Core.CheckInventory(18768))
                    break;
            }

            Nation.ApprovalAndFavor(0, 90);
            Nation.FarmTotemofNulgath(1);
            Nation.EssenceofNulgath(10);

            if (Core.IsMember)
                Adv.BuyItem("tercessuinotlim", 1951, "Unidentified 19");
            else Nation.Supplies("Unidentified 19");

            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("evilwarnul", "Laken", "King Klunk's Crown", 1, false);

            Core.EnsureComplete(5258);
            Bot.Wait.ForDrop("Unidentified 34");
            Bot.Wait.ForPickup("Unidentified 34");

            Core.Logger($"Completed x{i++}");
        }
    }
}
