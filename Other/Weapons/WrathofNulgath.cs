/*
name: Wrath of Nulgath
description: This script will get Wrath of Nulgath.
tags: wrathofnulgath, wrath, ravenous, weapon
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/Various/JuggernautItems.cs
//cs_include Scripts/Story/Legion/DarkWarLegionandNation.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;

public class WrathofNulgath
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;

public JuggernautItemsofNulgath juggernaut
{
    get => _juggernaut ??= new JuggernautItemsofNulgath();
    set => _juggernaut = value;
}
public JuggernautItemsofNulgath _juggernaut;

private DarkWarLegionandNation DWLN
{
    get => _DWLN ??= new DarkWarLegionandNation();
    set => _DWLN = value;
}
private DarkWarLegionandNation _DWLN;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetSword();

        Core.SetOptions(false);
    }

    public void GetSword()
    {
        if (Core.CheckInventory("Wrath of Nulgath"))
            return;

        DWLN.DoBoth();

        Core.Logger("Farming Wrath of Nulgath.");

        juggernaut.JuggItems(reward: JuggernautItemsofNulgath.RewardsSelection.Overfiend_Blade_of_Nulgath);
        Nation.FarmVoucher(false, true);
        Nation.FarmVoucher(true, true);
        Nation.FarmUni13(1);
        Nation.FarmTaintedGem(80);
        Nation.FarmDarkCrystalShard(60);
        Nation.FarmDiamondofNulgath(100);
        Adv.BuyItem("darkwarnation", 2123, "Wrath of Nulgath");
        Bot.Wait.ForPickup("Wrath of Nulgath");
    }
}

