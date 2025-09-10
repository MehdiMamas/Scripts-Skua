/*
name: Inventory Enhancer
description: This script will enhance all the items in your inventory with optimal enhancements.
tags: inventory, enhance, enh
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class InventoryEnhancer
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        EnhanceInventory();

        Core.SetOptions(false);
    }
    /// <summary>
    /// Enhances all non-leveled/non-user-level level enhanced items
    /// </summary>
    public void EnhanceInventory(EnhancementType type = EnhancementType.Lucky)
    {
        if (Core.CBOBool("DisableAutoEnhance", out bool _disableAutoEnhance) && _disableAutoEnhance)
            return;

        List<string> InventoryItems = Bot.Inventory.Items.FindAll(x => x.EnhancementLevel < Bot.Player.Level && (x.ItemGroup != "None" && x.ItemGroup != "am" && x.ItemGroup != "mi" && x.ItemGroup != "co" && x.ItemGroup != "pe")).Select(x => x.Name).ToList();

        if (InventoryItems.Count == 0)
            Core.Logger("The bot couldn't find any items in your inventory that need enhancing.");
        Adv.EnhanceItem(InventoryItems.ToArray(), type);
    }
}
