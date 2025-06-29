/*
name: Vindicator Badge
description: Farms "Vindicator Badge"
tags: vindicator, badge, hollowborn, farm
*/
//cs_include Scripts/CoreBots.cs

using Skua.Core.Interfaces;
using Skua.Core.Models.Quests;
using Skua.Core.Models.Items;

public class VindicatorBadgeFarm
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;

    private int GetMax()
    {
        Quest? quest = Bot.Quests.EnsureLoad(10299);
        if (quest == null)
        {
            return 1; // Default max stack if quest is not found
        }
        ItemBase? req = quest.Requirements.FirstOrDefault(r => r.Name == "Vindicator Badge");
        return req?.MaxStack ?? 1;
    }

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();
        GetVindicatorBadge(GetMax());
        Core.SetOptions(false);
    }

    public void GetVindicatorBadge(int? quant = null)
    {
        int badgeQuant = quant ?? GetMax();
        const string item = "Vindicator Badge";
        if (Core.CheckInventory(item, badgeQuant))
            return;

        Core.FarmingLogger(item, badgeQuant);
        Core.AddDrop(item);
        Core.EquipClass(ClassType.Solo);

        Core.HuntMonster("dawnsanctum", "Vindicator", item, badgeQuant, false);
        Bot.Wait.ForPickup(item);
    }
}