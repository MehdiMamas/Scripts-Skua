/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class CoreIsleOfFotia
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Core.RunCore();

        Core.SetOptions(false);
    }
    public void CompleteALL()
    {
        Fotia();
        UnderRealm();
        Styx();
        Judgement();
        DageFortress();
    }


    public void Fotia()
    {
        if (Core.isCompletedBefore(2949))
            return;

        Story.PreLoad(this);

        //Feeding the Frozen Flame 2942
        Story.KillQuest(2942, "fotia", "Fotia Elemental");

        //Fire for the Frozen Flame  2943
        Story.KillQuest(2943, "Fotia", "Fotia Spirit");

        //Lore Cores 2944
        Story.KillQuest(2944, "Fotia", "Fotia Spirit");

        //Volcanic Exploration 2945
        Story.KillQuest(2945, "Fotia", "Femme Cult Worshiper");

        //Retrieve the Ancient Artifact: Fire Staff 2946
        Story.KillQuest(2946, "BattleUnderA", "Skeletal Fire Mage");

        //Retrieve the Ancient Artifact: Ice Orb 2947
        Story.KillQuest(2947, "BattleUnderA", "Skeletal Ice Mage");

        //This Guy’s on Her Side 2948
        if (!Story.QuestProgression(2948))
        {
            Core.EnsureAccept(2948);
            Core.KillMonster("evilwarnul", "r2", "Down", "*", "Archfiend's Favor", 50, isTemp: false);
            Core.EnsureComplete(2948);
        }

        //Fotia's Only Hope 2949
        if (!Story.QuestProgression(2949))
        {
            Core.EnsureAccept(2949);
            Story.MapItemQuest(2949, "Fotia", 1838);
            Core.HuntMonster("Fotia", "Amia the Cult Leader", "Amia Defeated");
            Bot.Wait.ForCellChange("Cut2");

            if (Bot.Player.Cell == "r2")
                Core.JumpWait();

            if (Bot.Quests.TryGetQuest(2949, out var quest) && quest != null && quest.Active)
            {
                Core.EnsureComplete(quest.ID);
                Bot.Wait.ForActionCooldown(Skua.Core.Models.GameActions.TryQuestComplete);
            }
            else
            {
                if (quest != null)
                {
                    Bot.Wait.ForActionCooldown(Skua.Core.Models.GameActions.TryQuestComplete);
                    Bot.Wait.ForQuestComplete(quest.ID);
                }
                else
                {
                    Core.Logger("Quest not found, stopping bot.", stopBot: true);
                    return;
                }
            }
        }
    }

    public void UnderRealm()
    {
        if (Core.isCompletedBefore(3019))
            return;

        Fotia();

        Story.PreLoad(this);

        //Soul Searching 3010
        Story.KillQuest(3010, "UnderRealm", "Underworld Soul");

        //Chamber of Grief 3011
        Story.KillQuest(3011, "UnderRealm", "Grief");

        //Chamber of Anxiety 3012
        Story.KillQuest(3012, "UnderRealm", "Anxiety");

        //Chamber of Disease 3013
        Story.KillQuest(3013, "UnderRealm", "Disease");

        //Chamber of Old Age 3014
        Story.KillQuest(3014, "UnderRealm", "Old Age");

        //Chamber of Fear 3015
        Story.KillQuest(3015, "UnderRealm", "Fear");

        //Chamber of Hunger 3016
        Story.KillQuest(3016, "UnderRealm", "Hunger");

        //Chamber of Death 3017
        Story.KillQuest(3017, "UnderRealm", "Death");

        //Chamber of Agony 3018
        Story.KillQuest(3018, "UnderRealm", "Agony");

        //Chamber of Sleep 3019
        Story.KillQuest(3019, "UnderRealm", "Sleep");
    }

    public void Styx()
    {
        if (Core.isCompletedBefore(3025))
            return;

        UnderRealm();

        Story.PreLoad(this);

        //Sullen Souls Survival  3022
        Story.KillQuest(3022, "Styx", "Sullen Soul");

        //Wrathful Souls Rage 3023
        Story.KillQuest(3023, "Styx", "Wrathful Soul");

        //Hydra Hospitality 3024
        Story.KillQuest(3024, "Styx", "Styx Hydra");

        //Dage’s Guard Dog 3025
        Story.KillQuest(3025, "Styx", "Cerberus");
    }

    public void Judgement()
    {
        if (Core.isCompletedBefore(3042))
            return;

        Styx();

        Story.PreLoad(this);

        //IMPressive  3034
        Story.KillQuest(3034, "Judgement", "Underworld Imp");

        //The Raven’s Loss 3035
        Story.KillQuest(3035, "Judgement", "Raven");

        // The Power of Flowers 3036
        if (!Story.QuestProgression(3036))
        {
            FlowerPower("Delivered Asphodel Flower", 8, true);
        }

        //The Time for Judgment 3038
        Story.MapItemQuest(3038, "Judgement", 1914);

        //Judged on Performance 3039
        Bot.Lite.DisableMonsterAnimation = true;
        Story.KillQuest(3039, "Judgement", "Rhadamanthys");

        //Judged on Undead Legion Standards 3040
        Story.KillQuest(3040, "Judgement", "Minos");

        //Judged on Allegiance to Dage 3041
        Story.KillQuest(3041, "Judgement", "Aeacus");

        //Challenged Allegiance to Dage 3042
        Story.KillQuest(3042, "Judgement", "Ultra Aeacus");
        Bot.Lite.DisableMonsterAnimation = false;

    }


    public void DageFortress(bool map = false)
    {
        if (map && Core.CheckInventory("Palace Map"))
            return;

        if (Core.isCompletedBefore(4258) && !map)
            return;

        Judgement();

        Story.PreLoad(this);

        //Defend Against the Scorned 4249
        Story.KillQuest(4249, "DageFortress", "Sullied Master");

        //The Key to Discovery 4250
        Story.MapItemQuest(4250, "DageFortress", 3406);
        Story.KillQuest(4250, "DageFortress", "Tainted Seneschal");

        //Locate the Compass Stone 4251
        if (!Story.QuestProgression(4251) || (map && !Core.CheckInventory("Compass Stone")))
            CompassStone();

        //Create the Dark Fortress Map 4255
        if (map && !Core.CheckInventory("Palace Map") || !Story.QuestProgression(4255))
        {
            if (!map)
                Core.EnsureAccept(4255);
            CompassStone();
            PalaceMap();
            if (map)
                return;
            Core.EnsureComplete(4255);
        }

        //Quest for the Room of Rune-ation 4256
        Story.MapItemQuest(4256, "DageFortress", 3404);

        //Defeat the Underworld Guardian 4258
        Story.KillQuest(4258, "DageFortress", "Grrrberus");

    }

    public void FlowerPower(string? item = null, int quant = 1, bool isTemp = false)
    {
        Core.EnsureAccept(3036);

        while (!Bot.ShouldExit && (isTemp ? !Bot.TempInv.Contains("Delivered Asphodel Flower", quant) : !Bot.Inventory.Contains("Delivered Asphodel Flower", quant)))
        {
            if (Bot.Map.Name != "judgement")
            {
                Core.Join("judgement");
                Bot.Wait.ForActionCooldown(Skua.Core.Models.GameActions.Transfer);
            }

            if (Bot.Player.Cell != "r5")
            {
                Core.Jump("r5", "Left");
                Bot.Wait.ForCellChange("r5");
                Bot.Player.SetSpawnPoint();
            }

            foreach (var mob in Bot.Monsters.CurrentAvailableMonsters.Where(x => x != null && x.Name.EndsWith("Mourner")))
            {
                Bot.Kill.Monster(mob);
                Bot.Wait.ForMonsterDeath();
                if (isTemp ? Bot.TempInv.Contains("Delivered Asphodel Flower", quant) : Bot.Inventory.Contains("Delivered Asphodel Flower", quant))
                {
                    break;
                }
            }
        }

        Core.EnsureComplete(3036);
    }

    void CompassStone()
    {
        if (Core.CheckInventory("Compass Stone"))
            return;

        Core.AddDrop("Compass Stone");
        Core.EnsureAccept(4251);
        Core.KillMonster("DageFortress", "r2", "Bottom", "Scorned Knight", "Compass Stone Piece Found");
        Core.GetMapItem(3405, 4, "DageFortress");
        Core.EnsureComplete(4251);
    }

    void PalaceMap()
    {
        if (Core.CheckInventory("Palace Map"))
            return;

        string[] MapPieces = { "Left Map Piece", "Right Map Piece", "Center Map Piece" };
        Core.AddDrop(MapPieces);

        if (!Core.CheckInventory("Left Map Piece"))
        {
            //The First Map Piece 4252
            Core.EnsureAccept(4252);
            Core.HuntMonster("DageFortress", "Scorned Knight", "Map Fragment");
            Core.EnsureComplete(4252);
            Bot.Wait.ForPickup("Left Map Piece");
        }
        if (!Core.CheckInventory("Right Map Piece"))
        {
            //The Second Map Piece 4253
            Core.EnsureAccept(4253);
            Core.HuntMonster("DageFortress", "Twisted Warrior", "Map Fragment", 3);
            Core.EnsureComplete(4253);
            Bot.Wait.ForPickup("Right Map Piece");
        }
        if (!Core.CheckInventory("Center Map Piece"))
        {
            //The Final Map Piece 4254
            Core.EnsureAccept(4254);
            Core.HuntMonster("DageFortress", "Leeched Legend", "Map Fragment", 5);
            Core.EnsureComplete(4254);
            Bot.Wait.ForPickup("Center Map Piece");
        }
        Core.BuyItem("DageFortress", 1144, "Palace Map");
    }

}
