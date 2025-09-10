/*
name: Hollowborn Vindicator Class (Non Insignia)
description: Farms Hollowborn Vindicator Class.
tags: hollowborn, class, hbv,hollowborn vindicator, vindicator, gramiel, non insignia,ultragramielhub
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Hollowborn/Materials/HollowSoul.cs
//cs_include Scripts/Hollowborn/Materials/VindicatorBadge.cs
//cs_include Scripts/Hollowborn/Materials/DeathsPower.cs
//cs_include Scripts/Hollowborn/Materials/GraceOrb.cs
//cs_include Scripts/Hollowborn/Materials/GramielsEmblem.cs
//cs_include Scripts/Hollowborn/Materials/VindicatorCrest.cs
//cs_include Scripts/Story/Hollowborn/CoreHollowbornStory.cs


using Skua.Core.Interfaces;
using Skua.Core.Options;

public class HBVNonInsig
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

private CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
private CoreFarms _Farm;

private HollowSoul HS
{
    get => _HS ??= new HollowSoul();
    set => _HS = value;
}
private HollowSoul _HS;

private CoreHollowbornStory HBS
{
    get => _HBS ??= new CoreHollowbornStory();
    set => _HBS = value;
}
private CoreHollowbornStory _HBS;

private VindicatorBadge VB
{
    get => _VB ??= new VindicatorBadge();
    set => _VB = value;
}
private VindicatorBadge _VB;

private DeathsPower DP
{
    get => _DP ??= new DeathsPower();
    set => _DP = value;
}
private DeathsPower _DP;

private GraceOrb GO
{
    get => _GO ??= new GraceOrb();
    set => _GO = value;
}
private GraceOrb _GO;

private GramielsEmblem GE
{
    get => _GE ??= new GramielsEmblem();
    set => _GE = value;
}
private GramielsEmblem _GE;

private VindicatorCrest VC
{
    get => _VC ??= new VindicatorCrest();
    set => _VC = value;
}
private VindicatorCrest _VC;


    public string OptionsStorage = "FarmerJoePet";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        new Option<bool>("FarmExtra", "Farm Next Weeks Mats", "Save yourself some time", true),
        CoreBots.Instance.SkipOptions,
    };


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();
        GetClass();
        Core.SetOptions(false);
    }

    public void GetClass(bool rankUpClass = true, bool merge = false, int quant = 0, bool FarmNextWeeks = false)
    {
        if ((!merge && Core.CheckInventory(94357)) || (merge && Core.CheckInventory("Condensed Grace", quant)))
        {
            if (!merge && rankUpClass)
                Adv.RankUpClass("Hollowborn Vindicator");
            return;
        }
        FarmNextWeeks = Bot.Config!.Get<bool>("FarmExtra");
        Farm.Experience(80);
        Farm.HollowbornREP();
        HBS.DawnSanctum();
        string reqName = Core.QuestRewards(10299)[0];
        Core.AddDrop(reqName);

        if (!Core.CheckInventory(reqName, merge ? quant : 4))
        {
            Core.EnsureAccept(10299);

            // Vindicator Crest
            VC.GetVindicatorCrest(100);

            // Gramiel's Emblem
            GE.GetGramielsEmblem(300);

            // Grace Orb
            GO.GetGraceOrb(400);

            // Vindicator Badge
            VB.GetVindicatorBadge(200);

            // Hollow Soul
            HS.GetYaSoulsHeeeere(1500);

            // Death's Power
            DP.GetDP(1);

            if (!Bot.Quests.IsAvailable(10299))
            {
                Core.Logger("This is a weekly quest, you need to wait until next week to get the class.");
                if (FarmNextWeeks)
                    this.FarmNextWeeks();
                else
                    Core.Logger($"run the script next on: {DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss")}");
                return;
            }
            else
                Core.EnsureComplete(10299);
            Bot.Wait.ForPickup(reqName);
        }

        if (!Core.CheckInventory(reqName, 4))
        {
            Core.Logger($"You need 4x {reqName} to get the class. Run the script next week on: {DateTime.Now.AddDays(7):yyyy-MM-dd HH:mm:ss}");
            if (FarmNextWeeks)
                this.FarmNextWeeks();
            else
                Core.Logger($"run the script next on: {DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss")}");
            return;
        }
        else
            Adv.BuyItem("ultragramielhub", 2593, "Hollowborn Vindicator");

        if (rankUpClass)
            Adv.RankUpClass("Hollowborn Vindicator");

    }

    void FarmNextWeeks()
    {
        Core.Logger("Farming next week's requirements for Hollowborn Vindicator Class.");
        VC.GetVindicatorCrest(100);
        GE.GetGramielsEmblem(300);
        GO.GetGraceOrb(400);
        VB.GetVindicatorBadge(200);
        HS.GetYaSoulsHeeeere(1500);
        DP.GetDP(1);
        Core.Logger("Next week's requirements for Hollowborn Vindicator Class have been farmed.");
    }
}