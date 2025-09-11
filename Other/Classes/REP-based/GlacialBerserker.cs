/*
name: GlacialBerserker
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Glacera.cs

using Skua.Core.Interfaces;

public class GlacialBerserker
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;
    private static GlaceraStory Glacera { get => _Glacera ??= new GlaceraStory(); set => _Glacera = value; }    private static GlaceraStory _Glacera;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetGB();

        Core.SetOptions(false);
    }

    public void GetGB(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Glacial Berserker"))
        {
            if (rankUpClass)
                Adv.RankUpClass("Glacial Berserker");
            return;
        }

        Glacera.DoAll();
        Farm.GlaceraREP();
        // Adv.BestGear(GenericGearBoost.rep);
        if (!Core.CheckInventory(new[] { 38049, 38084 }, any: true))
            Adv.BuyItem("icewindpass", 1339, "Glacial Berserker", shopItemID: 22266);

        if (rankUpClass)
            Adv.RankUpClass("Glacial Berserker");
    }
}
