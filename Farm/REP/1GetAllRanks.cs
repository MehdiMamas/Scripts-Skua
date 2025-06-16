/*
name: Get All Ranks
description: This script will get all reputations to rank 10.
tags: all reps, reputation, rank, all ranks, farm, rep, reps
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs    
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/BrightOak.cs

using Skua.Core.Interfaces;
using Skua.Core.Options;

public class GetAllRanks
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreStory Story = new();
    public CoreAdvanced Adv = new();
    public CoreToD TOD = new();
    public Core13LoC LOC => new();
    public GlaceraStory Glac => new();
    public BrightOak BrightOak = new();
    public bool DontPreconfigure = true;
    public string OptionsStorage = "GetAllRanks";
    public List<IOption> Options = new()
    {
        new Option<bool>("doDeathPit", "Do Death Pit", "Should the bot farm Death Pit Brawl and Death Pit Arena reputations?", true)
    };


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoGetAllRanks(Bot.Config!.Get<bool>("doDeathPit"));

        Core.SetOptions(false);
    }


    public void DoGetAllRanks(bool doDeathPit = true)
    {
        //Adv.BestGear(GenericGearBoost.dmgAll);
        //Adv.BestGear(GenericGearBoost.rep);

        //Required Stories add when needed.
        Core.Logger("Doing Required Stories for the reps, let tato know if another is required.");
        TOD.CompleteToD();
        LOC.Complete13LOC();
        BrightOak.doall(true);
        Core.Logger("when doing the `Glacera` storyline, you may have to restart it in the middle of the quests due to ae's bullshit how it keeps another quest locked even though the preivosu is completed till you relog");
        Glac.DoAll();
        // Commented out do to PvP (with farm class or deaths) is still broke appearnly :thumbsup:
        // TOD.DeathPitPVP();


        Farm.GetAllRanks(doDeathPit);

    }
}
