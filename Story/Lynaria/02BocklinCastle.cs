/*
name: Bocklin Castle
description: This will complete the Victoria Alteon's storyline in /bocklincastle.
tags: story, quest, saga, lynaria, queen lynaria, bocklincastle, bocklin castle,victoria,victoria alteon
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Lynaria/CoreLynaria.cs
using Skua.Core.Interfaces;

public class BocklinCastle
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreLynaria Lyn = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Lyn.BocklinCastle();

        Core.SetOptions(false);
    }
}
