/*
name: VoidAvengerScythe
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Evil/NSoD/CoreNSOD.cs
//cs_include Scripts/Nation/Various/JuggernautItems.cs
//cs_include Scripts/Nation/EmpoweringItems.cs
//cs_include Scripts/Good/BLOD/CoreBLOD.cs
//cs_include Scripts/Evil/SDKA/CoreSDKA.cs
//cs_include Scripts/Other/Classes/Necromancer.cs
//cs_include Scripts/Story/BattleUnder.cs
using Skua.Core.Interfaces;

public class VoidAvengerScythe
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreAdvanced Adv = new();
    public CoreStory Story = new();
    public CoreNation Nation = new();
    public CoreNSOD NSoD = new();
    public JuggernautItemsofNulgath juggernaut = new();
    public EmpoweringItems Empower = new();
    public bool DontPreconfigure = true;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        SkewsQuests();

        Core.SetOptions(false);
    }
    public void SkewsQuests()
    {
        SnowbeardsQuests();
        DonnaCharmersQuests();

        if (Core.CheckInventory("Void Avenger Scythe"))
            return;

        Core.Logger("Farming Void Avenger Scythe.");

        Core.AddDrop("Void Avenger Scythe", "Batwing Scythe");

        Core.EnsureAccept(5025);

        //Eternal Rest

        Farm.EvilREP();
        // Batwing Scythe - 
        // if (!Bot.Quests.IsUnlocked(498))
        //     BatwingScythe();

        Bot.Quests.UpdateQuest(498);
        Core.HuntMonster("darkoviagrave", "Blightfang", "Batwing Scythe", isTemp: false);


        Core.EquipClass(ClassType.Solo);
        while (!Bot.ShouldExit && !Core.CheckInventory("Batwing Scythe"))
        {
            Core.EnsureAccept(498);
            Core.HuntMonster("darkoviagrave", "Blightfang", "Blightfang's Skull", log: false);
            Core.EnsureComplete(498);
            Bot.Wait.ForPickup("Batwing Scythe");
        }
        // Dark Crystal Shard - 
        Nation.FarmDarkCrystalShard(200);
        // Death Scythe of Nulgath - 
        Empower.EmpoweringStuff();
        // Ungodly Reavers of Nulgath - 
        juggernaut.JuggItems(reward: JuggernautItemsofNulgath.RewardsSelection.Ungodly_Reavers_of_Nulgath);
        // Scythe of Sisyphean - 
        Core.EquipClass(ClassType.Farm);
        Core.HuntMonster("dragonplane", "Wind Elemental", "Scythe of Sisyphean", isTemp: false);
        // Heart of the Void - 
        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("void", "Void Dragon", "Heart of the Void", isTemp: false);
        // The Scythe of Eternal Rest - 
        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("sepulchure", "Dark Sepulchure", "The Scythe of Eternal Rest", isTemp: false);
        // Nulgath's Approval -
        Core.EquipClass(ClassType.Farm);
        Nation.ApprovalAndFavor(1000, 0);
        // Dracolich Destroyer Scythe - 
        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("dragonheart", "Avatar of Desolich", "Dracolich Destroyer Scythe", isTemp: false);
        // Void Aura - 
        NSoD.VoidAuras(150);
        // Letter from Asuka and Tendou -    
        Core.EquipClass(ClassType.Farm);
        Core.HuntMonster("Citadel", "Burning Witch", "Letter from Asuka and Tendou", isTemp: false);
        Core.EnsureComplete(5025);
        Bot.Wait.ForPickup("Void Avenger Scythe");
    }

    public void BatwingScythe()
    {
        if (Core.CheckInventory("Batwing Scythe"))
            return;

        Core.AddDrop("Batwing Scythe");

        // A Grave Mission
        Story.MapItemQuest(494, "darkoviagrave", 97);

        // Lending a Helping Hand
        Story.KillQuest(495, "darkoviagrave", "Skeletal Fire Mage");

        // Bone Appetit
        Story.KillQuest(496, "darkoviagrave", "Rattlebones");

        // Batting Cage
        Story.KillQuest(497, "darkoviagrave", "Albino Bat");

        // His Bark is worse than his Blight (Batwing Scythe Reward)
        if (!Story.QuestProgression(498) || Core.CheckInventory("Batwing Scythe"))
        {
            Core.EnsureAccept(498);
            Core.HuntMonster("darkoviagrave", "Blightfang", "Blightfang's Skull");
            Core.EnsureComplete(498);
        }

        Core.HuntMonster("darkoviagrave", "Blightfang", "Batwing Scythe", isTemp: false);
    }

    public void DonnaCharmersQuests()
    {
        if (Core.isCompletedBefore(327))
            return;

        // Requirements: Must have completed the 'Bear Facts' quest.


        // The Spittoon Saloon
        Story.KillQuest(324, "pines", "Red Shell Turtle");
        // Bear it all!
        Story.KillQuest(325, "pines", "Pine Grizzly");
        // Leather Feathers
        Story.KillQuest(326, "pines", "LeatherWing");
        // Follow your Nose!      
        Story.KillQuest(327, "pines", "LeatherWing");
    }

    public void SnowbeardsQuests()
    {
        if (Core.isCompletedBefore(322))
            return;

        // Adorable Sisters
        Story.MapItemQuest(319, "tavern", 56, 7);
        // Warm and Furry
        Story.KillQuest(320, "pines", "Pine Grizzly");
        // Shell Shock
        Story.KillQuest(321, "pines", "Red Shell Turtle");
        // Bear Facts     
        Story.KillQuest(322, "pines", "Twistedtooth");
    }
}
