/*
name: Merge Shop Bot Generator/Helper
description: Fill in the map and shop ID and this tool will generate most of the merge bot for you, then you fill in the rest
tags: merge, shop, generator, helper, developer
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;
using Skua.Core.Models;
using Skua.Core.Models.Shops;
using Skua.Core.Models.Items;
using Skua.Core.Utils;
using System.IO;
using System.Diagnostics;



public class CaseStorage
{    
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.RunCore();
    }

    public static readonly Dictionary<string, string> Cases = new()
    {

        /*
        // Example:
                {
                    "Item Name",
                    @"
                case ""Item Name"":
                Core.FarmingLogger(req.Name, quant);
                Core.EquipClass(ClassType.Farm);
                Core.AddDrop(req.ID);
                if (Core.IsMember)
                    Core.RegisterQuests(10255);
                while (!Bot.ShouldExit && !Core.CheckInventory(req.ID, quant))
                {
                    Core.HuntMonsterQuest(10253,
                        (""map"", ""monster"", ClassType.Farm),
                        (""map"", ""drop"", ClassType.Solo)
                    );
                    Bot.Wait.ForPickup(req.Name);
                }
                Core.CancelRegisteredQuests();
                break;
               "
                },
        */

{
    "Unidentified 13",
    @"
            case ""Unidentified 13"":
        Core.FarmingLogger(req.Name, quant);
        Nation.FarmUni13(quant);
        break;
    "
},
{
    "Tainted Gem",
    @"
            case ""Tainted Gem"":
        Core.FarmingLogger(req.Name, quant);
        Nation.FarmTaintedGem(quant);
        break;
    "
},
{
    "Dark Crystal Shard",
    @"
            case ""Dark Crystal Shard"":
        Core.FarmingLogger(req.Name, quant);
        Nation.FarmDarkCrystalShard(quant);
        break;
    "
},
{
    "Diamond of Nulgath",
    @"
            case ""Diamond of Nulgath"":
        Core.FarmingLogger(req.Name, quant);
        Nation.FarmDiamondofNulgath(quant);
        break;
    "
},
{
    "Totem of Nulgath",
    @"
            case ""Totem of Nulgath"":
        Core.FarmingLogger(req.Name, quant);
        Nation.FarmTotemofNulgath(quant);
        break;
    "
},
{
    "Blood Gem of the Archfiend",
    @"
            case ""Blood Gem of the Archfiend"":
        Core.FarmingLogger(req.Name, quant);
        Nation.FarmBloodGem(quant);
        break;
    "
},
{
    "Voucher of Nulgath (non-mem)",
    @"
            case ""Voucher of Nulgath (non-mem)"":
        Core.FarmingLogger(req.Name, quant);
        Nation.FarmVoucher(false);
        break;
    "
},
{
    "Gem of Nulgath",
    @"
            case ""Gem of Nulgath"":
        Core.FarmingLogger(req.Name, quant);
        Nation.FarmGemofNulgath(quant);
        break;
    "
},
{
    "Archfiend's Favor",
    @"
            case ""Archfiend's Favor"":
        Nation.ApprovalAndFavor(0, quant);
        break;
    "
},
{
    "Acquiescence",
    @"
            case ""Acquiescence"":
        SOWM.Acquiescence(quant);
        break;
    "
},
{
    "Unbound Thread",
    @"
            case ""Unbound Thread"":
        SOWM.UnboundThread(quant);
        break;
    "
},
{
    "Prismatic Seams",
    @"
            case ""Prismatic Seams"":
        SOWM.PrismaticSeams(quant);
        break;
    "
},
{
    "Garish Remnant",
    @"
            case ""Garish Remnant"":
        SOWM.GarishRemnant(quant);
        break;
    "
},
{
    "Willpower",
    @"
            case ""Willpower"":
        SOWM.Willpower(quant);
        break;
    "
},

    };

    public static bool TryGetCase(string itemName, out string? logic)
        => Cases.TryGetValue(itemName, out logic);

    /// <summary>
    /// Returns the case logic with placeholders replaced by provided values.
    /// </summary>
    public static string GetCaseWithValues(string itemName, string reqName, int quant, string map, string monster, string drop)
    {
        if (!TryGetCase(itemName, out string? logic) || string.IsNullOrWhiteSpace(logic))
            return string.Empty;

        return logic
            .Replace("{reqName}", reqName)
            .Replace("{quant}", quant.ToString())
            .Replace("{map}", map)
            .Replace("{monster}", monster)
            .Replace("{drop}", drop);
    }
}
