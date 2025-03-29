/*
name: Sin of the SinoftheUnderworld NoInsignia
description: Does the Sin of the SinoftheUnderworld quest upto the "Atlas Regalia" item, of which skua cannot get.
tags: sin, of, the, SinoftheUnderworld, no, insignia, quest, atlas, regalia, sin of the SinoftheUnderworld, no insignia, 51, fifty one
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/Revenant/CoreLR.cs
//cs_include Scripts/Legion/HeadOfTheLegionBeast.cs
//cs_include Scripts/Story/Legion/SevenCircles(War).cs
//cs_include Scripts/Story/Legion/AtlasKingdom.cs
//cs_include Scripts/Story/Legion/AtlasPromenade.cs
//cs_include Scripts/Story/Legion/AtlasFalls.cs
//cs_include Scripts/Legion/InfiniteLegionDarkCaster.cs
//cs_include Scripts/Story/Legion/SeraphicWar.cs
//cs_include Scripts/Legion/YamiNoRonin/CoreYnR.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Legion/SwordMaster.cs
//cs_include Scripts/Legion/Various/VulcarsMerge.cs
//cs_include Scripts/Legion/LegionMaterials/SoulSand.cs
//cs_include Scripts/Legion/Various/LegionBonfire.cs
//cs_include Scripts/Legion/LegionMaterials/LetitBurn(SoulEssence).cs
//cs_include Scripts/Seasonal/StaffBirthdays/DageTheEvil/UnderworldTeamMerge.cs
//cs_include Scripts/Legion/MergeShops/SoulForgeMerge.cs
using Skua.Core.Interfaces;

public class SinoftheSinoftheUndyingNoInsignia
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreAdvanced Adv = new();
    private CoreFarms Farm = new();
    private CoreLegion LR = new();
    private HeadoftheLegionBeast HotLB = new();
    private AtlasFalls AtlasFalls = new();
    private CoreYnR YnR = new();
    private VulcarsMerge VulcarsMerge = new();
    private UnderworldTeamMerge UnderworldTeamMerge = new();
    private SoulForgeMerge SoulForgeMerge = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();
        Core.BankingBlackList.AddRange(new[] { "Sin of the Undying", "Atlas Lion Pelt", "Beast Soul", "Broken Chain", "Essence of Wrath", "Essence of Violence", "Essence of Treachery", "Atlas Regalia" });
        GetSword();

        Core.SetOptions(false);
    }

    public void GetSword()
    {
        Core.OneTimeMessage("WARNING", "Please do the Atlas Regalia quest manually, as it is not possible to get it with the bot.");
        Core.AddDrop("Sin of the Undying", "Atlas Lion Pelt", "Beast Soul", "Broken Chain", "Essence of Wrath", "Essence of Violence", "Essence of Treachery", "Atlas Regalia");
        AtlasFalls.Storyline();

        Core.EnsureAccept(10146);

        // Atlas Lion Pelt x 20
        if (!Core.CheckInventory("Atlas Lion Pelt", 20))
        {
            Core.FarmingLogger("Atlas Lion Pelt", 20);
            while (!Bot.ShouldExit && !Core.CheckInventory("Atlas Lion Pelt", 20))
            {
                Core.HuntMonsterQuest(10126,
                ("atlaskingdom", "Atlas Leo", ClassType.Solo),
                ("atlaskingdom", "Atlas Elite", ClassType.Solo),
                ("atlaskingdom", "Executioner Ladon", ClassType.Solo));
                Bot.Wait.ForPickup("Atlas Lion Pelt");
            }
        }

        // 20 Beast's Soul
        if (!Core.CheckInventory("Beast Soul", 20))
        {
            Core.EquipClass(ClassType.Solo);
            Core.FarmingLogger("Beast Soul", 20);
            Core.HuntMonster("sevencircleswar", "The Beast", "Beast Soul", 20, isTemp: false, publicRoom: true);
        }

        // Broke Chain x 20
        if (!Core.CheckInventory("Broken Chain", 150))
        {
            Core.FarmingLogger("Broken Chain", 20);
            while (!Bot.ShouldExit && !Core.CheckInventory("Broken Chain", 20))
            {
                Core.HuntMonsterQuest(10115,
                ("atlaspromenade", "Atlas Light Magus", ClassType.Farm),
                ("atlaspromenade", "Wrath Guard", ClassType.Farm),
                ("atlaspromenade", "Usurper Lord Slaine", ClassType.Solo)
                );
                Bot.Wait.ForPickup("Broken Chain");
            }
        }

        //5k LTs
        LR.FarmLegionToken(5000);

        // 20 of each Essence
        var requiredItems = new Dictionary<string, Action<int>>
            {
                { "Essence of Wrath", HotLB.EssenceWrath },
                { "Essence of Violence", HotLB.EssenceViolence },
                { "Essence of Treachery", HotLB.EssenceTreachery },
            };

        foreach (var (item, farmAction) in requiredItems)
        {
            if (!Core.CheckInventory(item, 20))
            {
                farmAction(20);
            }
        }

        if (!Core.CheckInventory("Atlas Regalia", 20))
        {
            Core.Logger("Bot **Cannot** get Atlas Regalia, please do it manually.");
        }
        else
        {
            Core.EnsureComplete(10146);
            Bot.Wait.ForDrop("Sin of the Undying");
            Bot.Wait.ForPickup("Sin of the Undying");
            if (Core.CheckInventory("Sin of the Undying"))
            {
                Core.Logger("You have successfully obtained the Sin of the Undying.");
            }
        }



    }
}
