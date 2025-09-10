/*
name: HBP - inserthere
description: does the 'inserthere' part of hollowborn doomKnight
tags: hollowborn paladin, hollowborn, inserthere
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Hollowborn/HollowbornPaladin/CoreHollowbornPaladin.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Chaos/DrakathsArmor.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Chaos/AscendedDrakathGear.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/TowerOfDoom.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Story/Artixpointe.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class CoreHollowbornPaladin
{
    public IScriptInterface Bot => IScriptInterface.Instance;

    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreHollowborn HB
{
    get => _HB ??= new CoreHollowborn();
    set => _HB = value;
}
public CoreHollowborn _HB;

public CoreBLOD BLOD
{
    get => _BLOD ??= new CoreBLOD();
    set => _BLOD = value;
}
public CoreBLOD _BLOD;

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public AscendedDrakathGear ADG
{
    get => _ADG ??= new AscendedDrakathGear();
    set => _ADG = value;
}
public AscendedDrakathGear _ADG;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;

public Artixpointe APointe
{
    get => _APointe ??= new Artixpointe();
    set => _APointe = value;
}
public Artixpointe _APointe;

public CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
public CoreDailies _Daily;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.RunCore();
    }

    public string[] PostSummoningItems =
    {
        "Classic Hollowborn Paladin Armor",
        "Hollowborn Paladin Visor",
        "Hollowborn Paladin Hood",
        "Hollowborn Templar Helm",
        "Hollowborn Paladin Cape",
        "Hollowborn Paladin Cloak",
        "Dual Hollowborn Shadows of Fate",
        "Hollowborn Daimyo Battlepet",
        "Hollowborn Daimyo"
    };

    public void GetAll()
    {
        if (Core.CheckInventory(PostSummoningItems))
            return;

        HB.HardcoreContract();
        HBShadowOfFate();
        Farm.Experience();

        Core.AddDrop(PostSummoningItems);
        while (!Bot.ShouldExit && !Core.CheckInventory(PostSummoningItems))
        {
            Core.EnsureAccept(7560);
            Core.HuntMonster("shadowblast", "Carnage", "Shadow Seal", 1, false);
            HB.HumanSoul(50);
            Core.EnsureCompleteChoose(7560, PostSummoningItems);
            Bot.Wait.ForPickup("*");
        }
        Core.ToBank(PostSummoningItems);
    }


    public void GetSpecific(string item)
    {
        if (Core.CheckInventory(item))
            return;

        HB.HardcoreContract();
        HBShadowOfFate();
        Farm.Experience();

        ItemBase[] Rewards = Core.EnsureLoad(7560).Rewards.ToArray();
        ItemBase Item = Rewards.Find(x => x.Name == item) ?? new ItemBase(); // Ensure item is not null
        Core.AddDrop(item);
        while (!Bot.ShouldExit && !Core.CheckInventory(Item.ID))
        {
            Core.EnsureAccept(7560);
            Core.HuntMonster("shadowblast", "Carnage", "Shadow Seal", 1, false);
            HB.HumanSoul(50);
            Core.EnsureComplete(7560, Item.ID);
            Bot.Wait.ForPickup(Item.ID);
        }
        Core.ToBank(PostSummoningItems);
    }

    public void HBPaladin()
    {
        if (Core.CheckInventory("Hollowborn Paladin"))
            return;

        HB.HardcoreContract();
        Farm.Experience(75);

        Core.AddDrop("Sparrow's Blood", "Brilliant Aura", "Gem of Superiority", "Condensed Mana", "Hollowborn Paladin");
        Core.EnsureAccept(7557);
        if (!Core.CheckInventory("Sparrow's Blood"))
        {
            Core.EquipClass(ClassType.Farm);
            Core.EnsureAccept(803);
            Core.HuntMonster("Arcangrove", "Seed Spitter", "Snapdrake", 17);
            Core.HuntMonster("Arcangrove", "Gorillaphant", "Blood Lily", 30);
            Core.HuntMonster("Arcangrove", "Seed Spitter", "Doom Dirt", 12);
            Core.EnsureComplete(803);
        }
        BLOD.BrilliantAura(1);
        Farm.DoomWoodREP(3);
        Core.BuyItem("lightguard", 277, "Dark Arts Scholar");
        Core.EquipClass(ClassType.Farm);
        Core.HuntMonster("shadowblast", "Legion Fenrir", "Gem of Superiority", 1, false);
        if (!Core.CheckInventory("Exalted Paladin Seal"))
        {
            Farm.GoodREP();
            Farm.Gold(500000);
            Core.BuyItem("darkthronehub", 1308, "Exalted Paladin Seal");
        }
        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("timevoid", "Unending Avatar", "Condensed Mana", 1, false, publicRoom: true);
        HB.HumanSoul(200);
        Core.EnsureComplete(7557);
    }

    public void HBPaladinHelmet()
    {
        if (Core.CheckInventory("Hollowborn Paladin Helmet"))
            return;

        HB.HardcoreContract();
        HBPaladin();
        Farm.Experience(85);

        Core.AddDrop("Dark Aura Gem", "Enchantment Rune", "Shadow Dragon Soul", "Hollowborn Paladin Helmet");
        Core.EnsureAccept(7558);
        Core.BuyItem("necropolis", 410, "Templar's Helm of Light");
        Farm.DoomWoodREP(6);
        Core.BuyItem("necropolis", 408, "Destiny Cloak");
        if (!Core.CheckInventory("Dark Aura Gem"))
        {
            if (!Core.CheckInventory("Enchanted Victory Blade"))
            {
                Core.BuyItem("river", 1213, "Silver Victory Blade");
                if (!Core.CheckInventory("Enchantment Rune"))
                {
                    Core.EnsureAccept(4811);
                    Core.EquipClass(ClassType.Farm);
                    Core.HuntMonster("graveyard", "Skeletal Viking", "Ravenwing Scroll");
                    Core.HuntMonster("graveyard", "Skeletal Warrior", "Unseeing Eye", 3);
                    Core.HuntMonster("graveyard", "Big Jack Sprat", "Shard of Diamond Blade", 5);
                    Core.EnsureComplete(4811);
                    Bot.Wait.ForPickup("Enchantment Rune");
                }
                Core.BuyItem("river", 1213, "Enchanted Victory Blade");
            }
            Core.EnsureAccept(4812);
            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("graveyard", "Skeletal Warrior", "Broken Dream Catcher", 10);
            Core.EnsureCompleteChoose(4812, new[] { "Dark Aura Gem" });
        }
        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("necrocavern", "Shadow Dragon", "Shadow Dragon Soul", 1, false);
        Core.HuntMonster("temple", "Cryptkeeper Lich", "Cryptkeeper Lich's Head");
        HB.HumanSoul(200);
        Core.EnsureComplete(7558);
    }

    public void HBShadowOfFate()
    {
        if (Core.CheckInventory("Hollowborn Shadow of Fate"))
            return;

        HB.HardcoreContract();
        HBPaladin();
        HBPaladinHelmet();
        ADG.AscendedGear("Ascended Light of Destiny");
        Farm.Experience(95);

        Core.AddDrop("Undead Skull", "Hollowborn Shadow of Fate");
        Core.EnsureAccept(7559);
        if (!Core.CheckInventory("Unidentified 25"))
        {
            Farm.Gold(15000000);
            Core.BuyItem("tercessuinotlim", 1951, "Unmoulded Fiend Essence");
            Core.BuyItem("tercessuinotlim", 1951, "Unidentified 25");
        }
        if (!Core.CheckInventory("Seal of Light") || !Core.CheckInventory("Seal of Darkness"))
            Daily.BrightKnightArmor(false);
        Core.EquipClass(ClassType.Farm);
        Core.HuntMonster("artixpointe", "Skeletal Minion", "Undead Skull", 1, false);
        APointe.OmniArtifact();
        HB.HumanSoul(300);
        Core.EnsureComplete(7559);
    }
}
