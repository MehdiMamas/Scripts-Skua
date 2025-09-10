/*
name: Nova Shrine Gifts Merge
description: This bot will farm the items belonging to the selected mode for the Nova Shrine Gifts Merge [2458] in /novashrine
tags: nova, shrine, gifts, merge, novashrine, star, light, destiny, celestial, paladin, winged, nightsky, cloak, lights, stella, empyrean, wings, tail, empyreans, claws, reaver, reavers
*/
//cs_include Scripts/Chaos/AscendedDrakathGear.cs
//cs_include Scripts/Chaos/DrakathsArmor.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Evil/NSoD/CoreNSOD.cs
//cs_include Scripts/Evil/SDKA/CoreSDKA.cs
//cs_include Scripts/Evil/SepulchuresOriginalHelm.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Good/BLoD/1SanctifiedLightofDestiny.cs
//cs_include Scripts/Good/BLoD/2UltimateBlindingLightofDestiny.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Hollowborn/HollowbornPaladin/CoreHollowbornPaladin.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/Various/DragonBlade[mem].cs
//cs_include Scripts/Nation/Various/PurifiedClaymoreOfDestiny.cs
//cs_include Scripts/Nation/Various/TarosManslayer.cs
//cs_include Scripts/Nation/Various/VoidPaladin.cs
//cs_include Scripts/Other/Classes/Necromancer.cs
//cs_include Scripts/Other/Materials/DarknessShard.cs
//cs_include Scripts/Other/MergeShops/DreadspaceReplicatorMerge.cs
//cs_include Scripts/Other/Weapons/CyseroItemUpgradeQuests.cs
//cs_include Scripts/Other/Weapons/ObsidianLightofDestiny.cs
//cs_include Scripts/Story/Artixpointe.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
//cs_include Scripts/Story/DragonsOfYokai/CoreDOY.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
//cs_include Scripts/Story/Summer2015AdventureMap/CoreSummer.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
//cs_include Scripts/Story/TowerOfDoom.cs
//cs_include Scripts/ShadowsOfWar/CoreSoWMats.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/ShadowsOfWar/MergeShops/StreamwarMerge.cs



using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class NovaShrineGiftsMerge
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
private CoreFarms _Farm;

private CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
private CoreAdvanced _Adv;

private static CoreAdvanced sAdv
{
    get => _sAdv ??= new CoreAdvanced();
    set => _sAdv = value;
}
private static CoreAdvanced _sAdv;


public AscendedDrakathGear ADG
{
    get => _ADG ??= new AscendedDrakathGear();
    set => _ADG = value;
}
public AscendedDrakathGear _ADG;

public DreadspaceReplicatorMerge DRM
{
    get => _DRM ??= new DreadspaceReplicatorMerge();
    set => _DRM = value;
}
public DreadspaceReplicatorMerge _DRM;

public VoidPaladin VP
{
    get => _VP ??= new VoidPaladin();
    set => _VP = value;
}
public VoidPaladin _VP;

public CyseroItemUpgrade CIU
{
    get => _CIU ??= new CyseroItemUpgrade();
    set => _CIU = value;
}
public CyseroItemUpgrade _CIU;

public CoreHollowbornPaladin CHP
{
    get => _CHP ??= new CoreHollowbornPaladin();
    set => _CHP = value;
}
public CoreHollowbornPaladin _CHP;

public ObsidianLightofDestiny ObsidianLightofDestiny
{
    get => _ObsidianLightofDestiny ??= new ObsidianLightofDestiny();
    set => _ObsidianLightofDestiny = value;
}
public ObsidianLightofDestiny _ObsidianLightofDestiny;

public UltimateBLoD UltimateBLoD
{
    get => _UltimateBLoD ??= new UltimateBLoD();
    set => _UltimateBLoD = value;
}
public UltimateBLoD _UltimateBLoD;

public SanctifiedLightofDestiny SanctifiedLightofDestiny
{
    get => _SanctifiedLightofDestiny ??= new SanctifiedLightofDestiny();
    set => _SanctifiedLightofDestiny = value;
}
public SanctifiedLightofDestiny _SanctifiedLightofDestiny;

public DragonBladeofNulgath DBoN
{
    get => _DBoN ??= new DragonBladeofNulgath();
    set => _DBoN = value;
}
public DragonBladeofNulgath _DBoN;

public CoreBLOD BLOD
{
    get => _BLOD ??= new CoreBLOD();
    set => _BLOD = value;
}
public CoreBLOD _BLOD;

public CoreDOY CoreDOY
{
    get => _CoreDOY ??= new CoreDOY();
    set => _CoreDOY = value;
}
public CoreDOY _CoreDOY;

public StreamwarMerge StreamwarMerge
{
    get => _StreamwarMerge ??= new StreamwarMerge();
    set => _StreamwarMerge = value;
}
public StreamwarMerge _StreamwarMerge;




    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Star Piece", "Ascended Light of Destiny", "Blackhole Light of Dread Space", "Void Light of Destiny", "Polished Blinding Light of Destiny", "Hollowborn Shadow of Fate", "Obsidian Light of Destiny", "Ultimate Blinding Light of Destiny", "Sanctified Light of Destiny", "DragonBlade of Nulgath", "Star of the Empyrean", "ArchPaladin Armor", "Blinding Aura", "Cosmic Stardust", "Nova Empyrean Tail" });
        Core.SetOptions();

        BuyAllMerge();
        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        CoreDOY.NovaShrine();
        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("novashrine", 2458, findIngredients, buyOnlyThis, buyMode: buyMode);

        #region Dont edit this part
        void findIngredients()
        {
            ItemBase req = Adv.externalItem;
            int quant = Adv.externalQuant;
            int currentQuant = req.Temp ? Bot.TempInv.GetQuantity(req.Name) : Bot.Inventory.GetQuantity(req.Name);
            if (req == null)
            {
                Core.Logger("req is NULL");
                return;
            }


            switch (req.Name)
            {
                default:
                    bool shouldStop = !Adv.matsOnly || !dontStopMissingIng;
                    Core.Logger($"The bot hasn't been taught how to get {req.Name}." + (shouldStop ? " Please report the issue." : " Skipping"), messageBox: shouldStop, stopBot: shouldStop);
                    break;
                #endregion

                case "Star Piece":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.KillMonster("starfield", "r3", "bottom", "*", req.Name, quant, req.Temp, log: false);
                    break;

                case "Ascended Light of Destiny":
                    ADG.AscendedGear("Ascended Light of Destiny");

                    break;

                case "Blackhole Light of Dread Space":
                    DRM.BuyAllMerge(req.Name);
                    break;

                case "Void Light of Destiny":
                    VP.Sacrifice();
                    break;

                case "Polished Blinding Light of Destiny":
                    CIU.GetPolishedBLoD();
                    break;

                case "Hollowborn Shadow of Fate":
                    CHP.HBShadowOfFate();
                    break;

                case "Obsidian Light of Destiny":
                    ObsidianLightofDestiny.Axe();
                    break;

                case "Ultimate Blinding Light of Destiny":
                    UltimateBLoD.UltimateBlindingLightofDestiny();
                    break;

                case "Sanctified Light of Destiny":
                    SanctifiedLightofDestiny.GetSanctifiedLightofDestiny();
                    break;

                case "DragonBlade of Nulgath":
                case "Dark Dragon Slayer's Halberd":
                    if (!Bot.Player.IsMember)
                        StreamwarMerge.BuyAllMerge("Dark Dragon Slayer's Halberd");
                    else
                        DBoN.GetDragonBlade();

                    Core.BuyItem("novashrine", 2458, "Star Light of Destiny", 1, !Bot.Player.IsMember ? 13334 : 13333);
                    break;

                case "Star of the Empyrean":
                    Core.Logger($"Cannot Obtain {req.Name} as its from an \"Ultra\", and Skua cannot do ultras. Please Wait until InsertCreates/adds this ultra to his Bot Collecetion (and update grim li to 1.5.2 for the newest handler)");

                    break;

                case "ArchPaladin Armor":
                    Adv.BuyItem("darkthronehub", 1303, req.Name);
                    break;

                case "Blinding Aura":
                    BLOD.BlindingAura(quant);

                    break;

                case "Cosmic Stardust":
                case "Nova Empyrean Tail":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Solo);
                    Core.RegisterQuests(9802);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.KillMonster("novashrine", "r2", "left", "Nova Empyrean", req.Name, quant, req.Temp);
                    }
                    Core.CancelRegisteredQuests();
                    break;

            }
        }
    }

    public List<IOption> Select = new()
    {
        new Option<bool>("86372", "Star Light of Destiny", "Mode: [select] only\nShould the bot buy \"Star Light of Destiny\" ?", false),
        new Option<bool>("86846", "Celestial Paladin", "Mode: [select] only\nShould the bot buy \"Celestial Paladin\" ?", false),
        new Option<bool>("86847", "Celestial Paladin Winged Helm", "Mode: [select] only\nShould the bot buy \"Celestial Paladin Winged Helm\" ?", false),
        new Option<bool>("86848", "Celestial Paladin Helmet", "Mode: [select] only\nShould the bot buy \"Celestial Paladin Helmet\" ?", false),
        new Option<bool>("86849", "Celestial Nightsky Cloak", "Mode: [select] only\nShould the bot buy \"Celestial Nightsky Cloak\" ?", false),
        new Option<bool>("86916", "Star Lights of Destiny", "Mode: [select] only\nShould the bot buy \"Star Lights of Destiny\" ?", false),
        new Option<bool>("82857", "Stella Empyrean Axe", "Mode: [select] only\nShould the bot buy \"Stella Empyrean Axe\" ?", false),
        new Option<bool>("82858", "Stella Empyrean Axes", "Mode: [select] only\nShould the bot buy \"Stella Empyrean Axes\" ?", false),
        new Option<bool>("86854", "Nova Empyrean Wings", "Mode: [select] only\nShould the bot buy \"Nova Empyrean Wings\" ?", false),
        new Option<bool>("86855", "Nova Empyrean Wings and Tail", "Mode: [select] only\nShould the bot buy \"Nova Empyrean Wings and Tail\" ?", false),
        new Option<bool>("86858", "Nova Empyrean's Claws", "Mode: [select] only\nShould the bot buy \"Nova Empyrean's Claws\" ?", false),
        new Option<bool>("87394", "Star Light of the Empyrean", "Mode: [select] only\nShould the bot buy \"Star Light of the Empyrean\" ?", false),
        new Option<bool>("87395", "Star Lights of the Empyrean", "Mode: [select] only\nShould the bot buy \"Star Lights of the Empyrean\" ?", false),
        new Option<bool>("82861", "Stella Empyrean Reaver", "Mode: [select] only\nShould the bot buy \"Stella Empyrean Reaver\" ?", false),
        new Option<bool>("82862", "Stella Empyrean Reavers", "Mode: [select] only\nShould the bot buy \"Stella Empyrean Reavers\" ?", false),
    };
}
