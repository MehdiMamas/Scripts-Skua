/*
name: BehemothBlades
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class BehemothBlade
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;



    public bool DontPreconfigure = true;
    public string OptionsStorage = "BehemothBlade";
    public List<IOption> Options = new()
    {
        CoreBots.Instance.SkipOptions,
        new Option<Blade>("BladeChoice", "Choose Your Version", "Choose between Behemoth Blade of Shadow, Light, or both", Blade.Both),
    };


    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(new[] { "", "Combat Trophy", "Basic War Sword", "Behemoth Blade of Shadow", "Behemoth Blade of Light" });
        Core.SetOptions();

        Blades();

        Core.SetOptions(false);
    }

    public void Blades()
    {
        Blade bladeChoice = Bot.Config?.Get<Blade>("BladeChoice") ?? default;

        if (bladeChoice == Blade.Both)
        {
            BehemothBladeof("Shadow");
            BehemothBladeof("Light");
        }
        else
        {
            BehemothBladeof(bladeChoice.ToString());
        }

    }

    public void BehemothBladeof(string blade)
    {
        if (Core.CheckInventory($"Behemoth Blade of {blade}"))
            return;

        Core.FarmingLogger($"Behemoth Blade of {blade}", 1);

        Core.EquipClass(ClassType.Solo);
        if (!Core.CheckInventory("Basic War Sword"))
        {
            Farm.BludrutBrawlBoss(quant: 50);
            Core.BuyItem("battleon", 222, "Basic War Sword");
        }
        if (!Core.CheckInventory("Steel Afterlife"))
        {
            Farm.BludrutBrawlBoss(quant: 50);
            Core.BuyItem("battleon", 222, "Steel Afterlife");
        }
        Farm.BludrutBrawlBoss(quant: 500);
        string bladeChoice = Bot.Config?.Get<Blade>("BladeChoice").ToString() ?? string.Empty;
        Core.BuyItem("battleon", 222, $"Behemoth Blade of {bladeChoice}");
    }

    enum Blade
    {
        Shadow,
        Light,
        Both
    }

}
