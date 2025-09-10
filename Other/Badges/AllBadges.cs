/*
name: Get All Badges
description: This will get all badges in the game.
tags: badge, complete, all
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/Asylum.cs
//cs_include Scripts/Story/Artixpointe.cs
//cs_include Scripts/Story/ArtixWedding.cs
//cs_include Scripts/Story/Borgars.cs
//cs_include Scripts/Story/CruxShip.cs
//cs_include Scripts/Story/EtherstormWastes.cs
//cs_include Scripts/Story/RavenlossSaga.cs
//cs_include Scripts/Story/ShadowVault.cs
//cs_include Scripts/Story/SkyGuardSaga.cs
//cs_include Scripts/Story/UnderGroundLab.cs
//cs_include Scripts/Story/DragonsOfYokai/CoreDOY.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQOM.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/CelestialArena.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/GoldenArena.cs
//cs_include Scripts/Story/Cornelis[mem].cs
//cs_include Scripts/Other/Badges/6thBirthdaySavior.cs
//cs_include Scripts/Other/Badges/BattleBabysitter.cs
//cs_include Scripts/Other/Badges/BattleConVIP.cs
//cs_include Scripts/Other/Badges/CelestialChampion.cs
//cs_include Scripts/Other/Badges/ChaosPuppetMaster.cs
//cs_include Scripts/Other/Badges/Committed.cs
//cs_include Scripts/Other/Badges/ConZombieSlayer.cs
//cs_include Scripts/Other/Badges/CornelisReborn.cs
//cs_include Scripts/Other/Badges/CtrlAltDelMemberBadge.cs
//cs_include Scripts/Other/Badges/DerpMoosefishBadge.cs
//cs_include Scripts/Other/Badges/DesolichFreed.cs
//cs_include Scripts/Other/Badges/GoldenLaurel.cs
//cs_include Scripts/Other/Badges/GravelynsWarrior.cs
//cs_include Scripts/Other/Badges/HordeZombieSLAYER.cs
//cs_include Scripts/Other/Badges/LordOfTheWeddingRing.cs
//cs_include Scripts/Other/Badges/MoglinPunter.cs
//cs_include Scripts/Other/Badges/MummySlayerAndCruxShadowsDefender.cs
//cs_include Scripts/Other/Badges/RavenlossWarAndChampion.cs
//cs_include Scripts/Other/Badges/ShadowVaultChampion.cs
//cs_include Scripts/Other/Badges/SkyPirateSlayerBadge.cs
//cs_include Scripts/Other/Badges/StoneCold.cs
//cs_include Scripts/Other/Badges/TableFlipper.cs
//cs_include Scripts/Other/Badges/YouMadBroBadge.cs
//cs_include Scripts/Other/Badges/VoidHighlordBadge.cs
//cs_include Scripts/Other/Badges/StoryARC.cs
//cs_include Scripts/Other/Badges/JusticeSquad.cs
//cs_include Scripts/Other/Badges/ThiefofChaos.cs
//cs_include Scripts/Other/Badges/Goal.cs
//cs_include Scripts/Other/Badges/UltraCarnax.cs
//cs_include Scripts/Other/Badges/YokaiAscension.cs
//cs_include Scripts/Story/MagicThief.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/Seasonal/Frostvale/Story/CoreFrostvale.cs
//cs_include Scripts/Seasonal/Frostvale/FrostvaleBadges.cs
using Skua.Core.Interfaces;

public class AllBadges
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;


public CornelisRebornbadge CRB
{
    get => _CRB ??= new CornelisRebornbadge();
    set => _CRB = value;
}
public CornelisRebornbadge _CRB;

public DerpMoosefishBadge DMF
{
    get => _DMF ??= new DerpMoosefishBadge();
    set => _DMF = value;
}
public DerpMoosefishBadge _DMF;

public SkyPirateBadge SPB
{
    get => _SPB ??= new SkyPirateBadge();
    set => _SPB = value;
}
public SkyPirateBadge _SPB;

public YouMadBroBadge YMBB
{
    get => _YMBB ??= new YouMadBroBadge();
    set => _YMBB = value;
}
public YouMadBroBadge _YMBB;

public MoglinPunter MPB
{
    get => _MPB ??= new MoglinPunter();
    set => _MPB = value;
}
public MoglinPunter _MPB;

public CtrlAltDelMemberBadge CAD
{
    get => _CAD ??= new CtrlAltDelMemberBadge();
    set => _CAD = value;
}
public CtrlAltDelMemberBadge _CAD;

public BirthdaySavior BS
{
    get => _BS ??= new BirthdaySavior();
    set => _BS = value;
}
public BirthdaySavior _BS;

public BattleBabysitter BB
{
    get => _BB ??= new BattleBabysitter();
    set => _BB = value;
}
public BattleBabysitter _BB;

public BattleConVIP BCV
{
    get => _BCV ??= new BattleConVIP();
    set => _BCV = value;
}
public BattleConVIP _BCV;

public CelestialArenaChampion CAC
{
    get => _CAC ??= new CelestialArenaChampion();
    set => _CAC = value;
}
public CelestialArenaChampion _CAC;

public ChaosPuppetMaster CPM
{
    get => _CPM ??= new ChaosPuppetMaster();
    set => _CPM = value;
}
public ChaosPuppetMaster _CPM;

public Committed C
{
    get => _C ??= new Committed();
    set => _C = value;
}
public Committed _C;

public ConZombieSlayer CZS
{
    get => _CZS ??= new ConZombieSlayer();
    set => _CZS = value;
}
public ConZombieSlayer _CZS;

public DesolichFreed DF
{
    get => _DF ??= new DesolichFreed();
    set => _DF = value;
}
public DesolichFreed _DF;

public GoldenLaurel GL
{
    get => _GL ??= new GoldenLaurel();
    set => _GL = value;
}
public GoldenLaurel _GL;

public GravelynsWarrior GW
{
    get => _GW ??= new GravelynsWarrior();
    set => _GW = value;
}
public GravelynsWarrior _GW;

public HordeZombieSLAYER HZS
{
    get => _HZS ??= new HordeZombieSLAYER();
    set => _HZS = value;
}
public HordeZombieSLAYER _HZS;

public LordOfTheWeddingRing LOTWR
{
    get => _LOTWR ??= new LordOfTheWeddingRing();
    set => _LOTWR = value;
}
public LordOfTheWeddingRing _LOTWR;

public MummySlayerAndCruxShadowsDefender MSACSD
{
    get => _MSACSD ??= new MummySlayerAndCruxShadowsDefender();
    set => _MSACSD = value;
}
public MummySlayerAndCruxShadowsDefender _MSACSD;

public RavenlossWarAndChampion RWAC
{
    get => _RWAC ??= new RavenlossWarAndChampion();
    set => _RWAC = value;
}
public RavenlossWarAndChampion _RWAC;

public ShadowVaultChampion SVC
{
    get => _SVC ??= new ShadowVaultChampion();
    set => _SVC = value;
}
public ShadowVaultChampion _SVC;

public StoneCold SC
{
    get => _SC ??= new StoneCold();
    set => _SC = value;
}
public StoneCold _SC;

public TableFlipper TF
{
    get => _TF ??= new TableFlipper();
    set => _TF = value;
}
public TableFlipper _TF;

public VoidHighlordBadge VHL
{
    get => _VHL ??= new VoidHighlordBadge();
    set => _VHL = value;
}
public VoidHighlordBadge _VHL;

public StoryArcBadge SA
{
    get => _SA ??= new StoryArcBadge();
    set => _SA = value;
}
public StoryArcBadge _SA;

public JusticeSquadBadge JS
{
    get => _JS ??= new JusticeSquadBadge();
    set => _JS = value;
}
public JusticeSquadBadge _JS;

public ThiefofChaosBadge ToC
{
    get => _ToC ??= new ThiefofChaosBadge();
    set => _ToC = value;
}
public ThiefofChaosBadge _ToC;

public UltraCarnaxBadge UC
{
    get => _UC ??= new UltraCarnaxBadge();
    set => _UC = value;
}
public UltraCarnaxBadge _UC;

public GoalBadge G
{
    get => _G ??= new GoalBadge();
    set => _G = value;
}
public GoalBadge _G;

public FrostvaleBadges FV
{
    get => _FV ??= new FrostvaleBadges();
    set => _FV = value;
}
public FrostvaleBadges _FV;

private YokaiAscension YA
{
    get => _YA ??= new YokaiAscension();
    set => _YA = value;
}
private YokaiAscension _YA;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoAll();

        Core.SetOptions(false);
    }

    public void DoAll()
    {
        CRB.Badge();
        SPB.Badge();
        MPB.Badge();
        CAD.Badge();
        BS.Badge();
        BB.Badge();
        BCV.Badge();
        CAC.Badge();
        CPM.Badge();
        C.Badge();
        CZS.Badge();
        DF.Badge();
        GL.Badge();
        GW.Badge();
        HZS.Badge();
        LOTWR.Badge();
        MSACSD.Badge();
        RWAC.Badge();
        SVC.Badge();
        SC.Badge();
        TF.Badge();
        DMF.Badge();
        SA.Badge();
        JS.Badge();
        ToC.Badge();
        UC.Badge();
        G.Badge();
        FV.Badges();
        YMBB.Badge();
        VHL.Badge();
        YA.Badge();
        //add more as they are made.
    }
}
