/*
name: Bright Aura Farm
description: Farms Bright Aura using the fastest methods available. Uses Blinding Bow quest (5 per turn-in) if available, Ultimate WK quest, or merges from Loyal Spirit Orbs as fallback.
tags: bright aura, blod, blinding light of destiny, bow, spirit orb, loyal spirit orb
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Story/BattleUnder.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class BrightAuraFarm
{
  private IScriptInterface Bot => IScriptInterface.Instance;
  private CoreBots Core => CoreBots.Instance;
  private static CoreBLOD BLOD { get => _BLOD ??= new CoreBLOD(); set => _BLOD = value; }
  private static CoreBLOD _BLOD;

  public string OptionsStorage = "BrightAuraFarm";
  public bool DontPreconfigure = true;
  public List<IOption> Options = new()
    {
        new Option<int>("Quantity", "How many Bright Aura do you need?", "Enter the quantity of Bright Aura you want to farm", 125),
        CoreBots.Instance.SkipOptions
    };

  public void ScriptMain(IScriptInterface Bot)
  {
    Core.SetOptions();

    int quantity = Bot.Config!.Get<int>("Quantity");

    Core.Logger($"=== Bright Aura Farming Guide ===");
    Core.Logger($"Target: {quantity} Bright Aura");
    Core.Logger($"");
    Core.Logger($"FASTEST METHODS (in order of speed):");
    Core.Logger($"1. Blinding Bow Quest (2174) - Gives 5 Bright Aura per turn-in");
    Core.Logger($"   Requires: Blinding Bow of Destiny");
    Core.Logger($"2. Ultimate Weapon Kit Quest (2163) - Gives Bright Aura");
    Core.Logger($"   Requires: Quest 2163 unlocked");
    Core.Logger($"3. Merge from Loyal Spirit Orbs - 50 Loyal Spirit Orbs = 1 Bright Aura");
    Core.Logger($"   Slowest method, used as fallback");
    Core.Logger($"");

    // Check what methods are available
    bool hasBlindingBow = Core.CheckInventory("Blinding Bow of Destiny");
    bool hasBlindingScythe = Core.CheckInventory("Blinding Scythe of Destiny");
    bool hasBlindingBroadsword = Core.CheckInventory("Blinding Broadsword of Destiny");
    bool hasUltimateWKUnlocked = Bot.Quests.IsUnlocked(2163);
    bool hasAnyBlindingWeapon = hasBlindingBow || hasBlindingScythe || hasBlindingBroadsword;

    if (hasBlindingBow)
    {
      Core.Logger($"✓ You have Blinding Bow - Using FASTEST method!");
      Core.Logger($"  This will give you 5 Bright Aura per quest turn-in");
    }
    else if (hasBlindingScythe || hasBlindingBroadsword)
    {
      Core.Logger($"✓ You have Blinding weapon - Using fast method!");
    }
    else if (hasUltimateWKUnlocked)
    {
      Core.Logger($"✓ Ultimate WK quest unlocked - Using alternative method");
    }
    else
    {
      Core.Logger($"⚠ No Blinding weapons found - Will use Loyal Spirit Orb merge (slower)");
      Core.Logger($"  Recommendation: Get Blinding Bow first for 5x faster farming!");
    }
    Core.Logger($"");

    BLOD.BrightAura(quantity);

    Core.Logger($"");
    Core.Logger($"=== Farming Complete! ===");
    Core.Logger($"You now have {Bot.Inventory.GetQuantity("Bright Aura")} Bright Aura");

    Core.SetOptions(false);
  }
}

