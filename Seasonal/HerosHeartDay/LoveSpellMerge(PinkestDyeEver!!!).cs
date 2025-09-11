/*
name: Love Spell Merge (Pinkest Dye Ever!!!)
description: This will farm Pinkest Dye Ever!!! for the Love Spell Merge.
tags: farm, merge, shop, seasonal, heros, heart, love, spell, pinkest, dye
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/HerosHeartDay/LoveSpellStory.cs
using Skua.Core.Interfaces;

public class PinkestDyeEver
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static LoveSpell LSS { get => _LSS ??= new LoveSpell(); set => _LSS = value; }    private static LoveSpell _LSS;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        PinkestDyeEverScript();

        Core.SetOptions(false);
    }

    public void PinkestDyeEverScript()
    {
        if (!Core.isSeasonalMapActive("lovespell"))
            return;
        if (Core.CheckInventory("Pinkest Dye Ever!!!", 200))
        {
            Core.Logger("You already have 200 (Max Quantity) Pinkest Dye Ever!!!");
            return;
        }

        Core.AddDrop("Pinkest Dye Ever!!!");

        LSS.LoveSpellScript();

        while (!Bot.ShouldExit && !Core.CheckInventory("Pinkest Dye Ever!!!", 200))
        {
            Core.EnsureAccept(7935);
            Core.HuntMonster("lovespell", "Mood Slime", "Mood Slime Hearts", 10);
            Core.HuntMonster("lovespell", "Stolen Heart");
            Core.EnsureComplete(7935);
        }
        Core.Logger("You now have 200 (Max Quantity) Pinkest Dye Ever!!!");
    }
}
