/*
name: Volley Baller
description: This will finish the Volley Baller Quest and farm items.
tags: farm, quest, volley-baller, summer-break
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class VolleyBaller
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;

    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Rewards);
        Core.SetOptions();

        VolleyBallerQuest();

        Core.SetOptions(false);
    }

    public readonly string[] Rewards =
 {
        "Volleyball Captain",
        "Volleyball Hero",
        "Volleyball Hero's Hat",
        "Volleyball Heroine's Hat",
        "Volleyball Hero's Hat + Glasses",
        "Volleyball Heroine's Hat + Glasses",
        "Volleyball Hero's Glasses",
        "Volleyball Team A Mascot",
        "Volleyball Hero's Board Cape",
        "Volleyball Team A Mascot Pet",
        "Volleyball Hero's Rod",
        "Volleyball Hero's Surfboard",
        "Volleyball Hero's Foam Spear",
        "Volleyball Hero's Foam Gauntlets",
        "Volleyball Hero's WaterGun",
        "Volleyball Hero's WaterGuns",
    };
    public void VolleyBallerQuest()
    {
        if (!Core.isSeasonalMapActive("summerbreak"))
            return;

        Core.AddDrop(Rewards);

        int i = 1;
        while (!Bot.ShouldExit && !Core.CheckInventory(Rewards, toInv: false))
        {
            Core.EnsureAccept(8794);
            Core.HuntMonster("summerbreak", "MMMirage", "Gum Ball", 6);
            Core.EnsureCompleteChoose(8794);
            Core.ToBank(Rewards);
            Core.Logger($"Completed x{i++}");
        }
        Core.Logger("All drops Already Acquired");
    }

}
