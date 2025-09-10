/*
name: Doom Metal Necro[class]
description: does the battle concert even quests for the classes.
tags: concert, metal necro, doom metal necro, neo metal necro
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Other/Concerts/BattleConcert2023.cs
//cs_include Scripts/Other/Concerts/NeoMetalNecro.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
//cs_include Scripts/Evil/ADK.cs
//cs_include Scripts/Evil/VordredsArmor.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
//cs_include Scripts/Evil/SDKA/CoreSDKA.cs
using Skua.Core.Interfaces;

public class DoomMetalNecro
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

private CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
private CoreDailies _Daily;

private CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
private CoreAdvanced _Adv;

private BattleConcertClassQuests BCCQ
{
    get => _BCCQ ??= new BattleConcertClassQuests();
    set => _BCCQ = value;
}
private BattleConcertClassQuests _BCCQ;

private NeoMetalNecro NMN
{
    get => _NMN ??= new NeoMetalNecro();
    set => _NMN = value;
}
private NeoMetalNecro _NMN;

private ArchDoomKnight ADK
{
    get => _ADK ??= new ArchDoomKnight();
    set => _ADK = value;
}
private ArchDoomKnight _ADK;

private VordredArmor VA
{
    get => _VA ??= new VordredArmor();
    set => _VA = value;
}
private VordredArmor _VA;


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        GetClass();

        Core.SetOptions(false);
    }

    public void GetClass(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Doom Metal Necro"))
        {
            if (rankUpClass)
                Adv.RankUpClass("Doom Metal Necro");
            return;
        }

        BCCQ.BattleConcertQuests();
        NMN.GetClass();

        // Doom Metal Necro Class 9328
        Core.EnsureAccept(9328);

        //Arch DoomKnight (takes the longest?)
        ADK.DoAll(true);
        Core.Unbank("Arch DoomKnight");

        Core.EquipClass(ClassType.Solo);
        //Doom Metal Ore x200
        Core.HuntMonster("shadowsong", "Oh'Garr", "Doom Metal Ore", 200, isTemp: false);
        //Rotting Ectoplasm x100
        Core.HuntMonster("ectocave", "Ektorax", "Rotting Ectoplasm", 100, isTemp: false);
        Core.AddDrop("Bone Pick");
        Core.RegisterQuests(9327);
        while (!Bot.ShouldExit && !Core.CheckInventory("Bone Pick", 150))
            Core.HuntMonster("brainmeat", "Brain Matter");


        //Voiduminance Necrock-Morph Spell
        VA.GetVordredsArmor(true);
        Adv.BuyItem("stonewood", 2063, 78923, shopItemID: 48545);
        
        //Neverborn Ritual
        Adv.BuyItem("dragonrune", 691, 77458, shopItemID: 47277);

        //Darkness Sigil
        Daily.Pyromancer();
        if (Core.CheckInventory("Pyromancer"))
            Adv.BuyItem("fireforge", 1142, 29684, shopItemID: 18695);
        else Core.Logger("Can't continue, missing Pyromancer");
        Core.EnsureComplete(9328);


        if (rankUpClass)
            Adv.RankUpClass("Doom Metal Necro");
    }
}
