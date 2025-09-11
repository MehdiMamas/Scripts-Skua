/*
name: Retrieve Void Auras
description: farms void auras via the "retrieve void auras" quest.
tags: retrieve, void aura
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Good/BLOD/CoreBLOD.cs
//cs_include Scripts/Evil/SDKA/CoreSDKA.cs
//cs_include Scripts/Other/Classes/Necromancer.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Evil/NSoD/CoreNSOD.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class RetrieveVoidAuras
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public static CoreBots sCore => CoreBots.Instance;
    private static CoreNSOD NSoD { get => _NSoD ??= new CoreNSOD(); set => _NSoD = value; }    private static CoreNSOD _NSoD;
public static CoreNSOD sNSoD
{
    get => _sNSoD ??= new CoreNSOD();
    set => _sNSoD = value;
}
public static CoreNSOD _sNSoD;


    public bool DontPreconfigure = true;
    public string OptionsStorage = sNSoD.OptionsStorage;
    public List<IOption> Options = new()
    {
        sNSoD.MaxStack,
        CoreBots.Instance.SkipOptions,
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(NSoD.Essences);

        Core.SetOptions();

        NSoD.RetrieveVoidAuras();

        Core.SetOptions(false);
    }
}
