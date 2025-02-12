/*
name: (VHL) Challenge Quest
description: This will farm all the requirements for Roentgenium of Nulgath Token.
tags: farm, quest, nation, VHL, void, highlord, roentgenium, void-crystal-a, void-crystal-b, challenge
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/AssistingCragAndBamboozle[Mem].cs
//cs_include Scripts/Nation/VHL/CoreVHL.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class VoidHighlordsChallenge
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreVHL VHL = new();
    public static CoreVHL sVHL = new();
    public CoreNation Nation = new();

    public string OptionsStorage = sVHL.OptionsStorage;
    public bool DontPreconfigure = true;
    public List<IOption> Options = sVHL.Options;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops);
        Core.SetOptions();

        VHL.VHLChallenge(25);

        Core.SetOptions(false);
    }
}
