/*
name: Hollow Soul
description: Farms "Hollow Soul"
tags: hollow soul, shadowrealm, hollowborn
*/
//cs_include Scripts/CoreBots.cs

using Skua.Core.Interfaces;
using Skua.Core.Models.Quests;
using Skua.Core.Models.Items;

public class HollowSoul
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;

    private int GetMax(int QuestID, string? item)
    {
        Quest? quest = Bot.Quests.EnsureLoad(QuestID);
        if (quest == null)
        {
            return 1; // Default max stack if quest is not found
        }
        ItemBase? req = quest.Requirements.FirstOrDefault(r => r.Name == item);
        return req?.MaxStack ?? 1;
    }

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetYaSoulsHeeeere();

        Core.SetOptions(false);
    }

    public void GetYaSoulsHeeeere(int? quant = null)
    {
        int HSQuant = quant ?? GetMax(10299, "Hollow Soul");
        if (Core.CheckInventory("Hollow Soul", HSQuant))
            return;

        Core.FarmingLogger("Hollow Soul", HSQuant);
        Core.EquipClass(ClassType.Solo);
        Core.KillMonster("shadowrealm", "r9", "Left", "*", "Hollow Soul", HSQuant, false);
    }
}
