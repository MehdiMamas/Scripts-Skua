/*
name: Lynaria's Saga (Do All)
description: This will finish the Lynaria's Saga storyline in /bocklingrove.
tags: story, quest, saga, doall, lynaria, complete, all, queen lynaria, bocklingrove, bocklin grove, bocklincastle, bocklin castle, bocklin sanctum,bocklinsanctum,victoria,victoria alteon
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Lynaria/CoreLynaria.cs
using Skua.Core.Interfaces;

public class DoAllLynaria
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreLynaria Lyn = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Lyn.DoAll();

        Core.SetOptions(false);
    }
}
