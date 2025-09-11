/*
name: All Dailies
description: Does all the avaiable dailies.
tags: all dailies, dailies, daily, all
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs

//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Evil/SDKA/CoreSDKA.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs

//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/Nation/CitadelRuins.cs
//cs_include Scripts/Story/DragonFableOrigins.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/Story/Friendship.cs

//cs_include Scripts/Dailies/LordOfOrder.cs
//cs_include Scripts/Dailies/MineCrafting.cs

//cs_include Scripts/Tools/BankAllItems.cs

using Skua.Core.Interfaces;
using Skua.Core.Options;

public class FarmAllDailies
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreDailies Daily { get => _Daily ??= new CoreDailies(); set => _Daily = value; }
    private static CoreDailies _Daily;
    private static LordOfOrder LOO { get => _LOO ??= new LordOfOrder(); set => _LOO = value; }
    private static LordOfOrder _LOO;
    private static GlaceraStory Glac { get => _Glac ??= new GlaceraStory(); set => _Glac = value; }
    private static GlaceraStory _Glac;
    private static CoreBLOD BLOD { get => _BLOD ??= new CoreBLOD(); set => _BLOD = value; }
    private static CoreBLOD _BLOD;
    private static Friendship FR { get => _FR ??= new Friendship(); set => _FR = value; }
    private static Friendship _FR;
    private static CoreSDKA CSDKA { get => _CSDKA ??= new CoreSDKA(); set => _CSDKA = value; }
    private static CoreSDKA _CSDKA;
    private static MineCrafting MineCrafting { get => _MineCrafting ??= new MineCrafting(); set => _MineCrafting = value; }
    private static MineCrafting _MineCrafting;
    //private BankAllItems BAI = new();

    public bool DontPreconfigure = true;
    public string OptionsStorage = "FarmAllDailies";
    public List<IOption> Options = new()
    {
        new Option<DailySet>("Select Dailies Set", "Dailies set: Recommended or All?", "only do the few that we recommend to make it a bit quicker?", DailySet.All),
        CoreBots.Instance.SkipOptions,
    };

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        DoAllDailies(Bot.Config!.Get<DailySet>("Select Dailies Set"));

        Core.SetOptions(false);
    }

    public void DoAllDailies(DailySet Set = DailySet.All)
    {
        if (Set == DailySet.Recommended)
        {
            Core.Logger($"Doing selected set of dailies: Recommended");
            LOO.GetLoO();
            Daily.Pyromancer();
            Daily.DeathKnightLord();
            Daily.ShadowScytheClass();
            Daily.WheelofDoom();
            Daily.FreeDailyBoost();
            Daily.CollectorClass();
            Glac.FrozenTower();
            Daily.Cryomancer();
            Daily.EldersBlood();
            Daily.ShadowShroud();
            Daily.DagesScrollFragment();
            MineCrafting.DoMinecrafting();
            Daily.CryptoToken();
            Core.Logger("Recommended Dailies finished!");
        }
        else
        {
            Core.Logger($"Doing selected set of dailies: All");
            LOO.GetLoO();
            Daily.Pyromancer();
            Daily.DeathKnightLord();
            Daily.ShadowScytheClass();
            Daily.WheelofDoom();
            Daily.FreeDailyBoost();
            Daily.CollectorClass();
            Glac.FrozenTower();
            Daily.Cryomancer();
            Daily.EldersBlood();
            Daily.PearlOfNulgath();
            Daily.CryptoToken();
            Daily.ShadowShroud();
            MineCrafting.DoMinecrafting();
            Daily.SparrowsBlood();
            Daily.BeastMasterChallenge();
            Daily.FungiforaFunGuy();
            CSDKA.UnlockHardCoreMetals();
            Daily.HardCoreMetals(new[] { "Arsenic", "Beryllium", "Chromium", "Palladium", "Rhodium", "Rhodium", "Thorium", "Mercury" }, 10, ToBank: true);
            Daily.GoldenInquisitor();
            Daily.BreakIntotheHoard(false, false);
            Daily.EldenRuby();
            Daily.NCSGem();
            Daily.EnchantedDarkBlood();
            Daily.MadWeaponSmith();
            Daily.CyserosSuperHammer();
            Daily.BrightKnightArmor();
            Daily.GrumbleGrumble();
            Daily.TenacityChallenge();
            Daily.MonthlyTreasureChestKeys();
            Daily.PowerGem();
            Daily.DesignNotes();
            Daily.MoglinPets();
            if (Set == DailySet.All)
            {
                FR.CompleteStory();
                Daily.Friendships();
            }
            Daily.DagesScrollFragment();
            Core.Logger("\"All\" Dailies finished!");
        }
    }

    public enum DailySet
    {
        Recommended,
        All,
        All_Without_Friendship
    }
}
