/*
name: ShadowslayerSummoningRitual2
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/7DeadlyDragons/Core7DD.cs
//cs_include Scripts/Story/GiantTaleStory.cs
//cs_include Scripts/Farm/BuyScrolls.cs
//cs_include Scripts/Story/ShadowSlayerK.cs
//cs_include Scripts/Other/Various/ShadowslayerSummoningRitual.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class ShadowslayerSummoningRitual2
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
public CoreDailies _Daily;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public ShadowSlayerK ShadowStory
{
    get => _ShadowStory ??= new ShadowSlayerK();
    set => _ShadowStory = value;
}
public ShadowSlayerK _ShadowStory;

public Core7DD DD
{
    get => _DD ??= new Core7DD();
    set => _DD = value;
}
public Core7DD _DD;

public BuyScrolls Scroll
{
    get => _Scroll ??= new BuyScrolls();
    set => _Scroll = value;
}
public BuyScrolls _Scroll;

public ShadowslayerSummoningRitual SSR
{
    get => _SSR ??= new ShadowslayerSummoningRitual();
    set => _SSR = value;
}
public ShadowslayerSummoningRitual _SSR;

public ShadowSlayerK SSK
{
    get => _SSK ??= new ShadowSlayerK();
    set => _SSK = value;
}
public ShadowSlayerK _SSK;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        LunateSigil();

        Core.SetOptions(false);
    }

    public void LunateSigil(int quant = 30)
    {
        if (Core.CheckInventory("Lunate Sigil", quant))
            return;

        if (!Core.isCompletedBefore(9845))
            SSK.DoAll();

        //Get "Sparkly Shadowslayer Relic"
        SSR.GetAll(true);

        Core.AddDrop("Lunate Sigil");
        Core.FarmingLogger("Lunate Sigil", quant);

        while (!Core.CheckInventory("Lunate Sigil", quant))
        {
            Core.HuntMonsterQuest(9846,
("chaoscave", "Dracowerepyre", ClassType.Solo),
        ("darkoviaforest", "Lich Of The Stone", ClassType.Solo),
        ("borgars", "Burglinster", ClassType.Solo),
        ("firewar", "Uriax", ClassType.Solo),
        ("maul", "Creature Creation ", ClassType.Solo),
        ("techdungeon", "Kalron the Cryptborg", ClassType.Solo)
);
            Bot.Wait.ForPickup("Lunate Sigil");
        }

    }
}
