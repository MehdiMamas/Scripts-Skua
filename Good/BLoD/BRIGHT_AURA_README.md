# Bright Aura Farming Guide

## Overview

`BrightAuraFarm.cs` is a custom script created for this fork to optimize Bright Aura farming for the Blinding Light of Destiny (BLoD) quest.

## Why This Script Exists

Based on Reddit community feedback, the fastest way to farm Bright Aura is using the **Blinding Bow** "Finding Fragments" quest, which gives **5 Bright Aura per turn-in** instead of the default merge method (50 Loyal Spirit Orbs = 1 Bright Aura).

This script automatically detects which farming methods are available and uses the fastest one.

## Farming Methods (Fastest to Slowest)

### 1. Blinding Bow Quest (FASTEST) ⭐

- **Quest ID:** 2174 (Finding Fragments with Blinding Bow of Destiny)
- **Reward:** 5 Bright Aura per turn-in
- **Requirement:** Blinding Bow of Destiny
- **Location:** battleunderb (Skeleton Warriors)
- **Speed:** ~5x faster than merge method

### 2. Blinding Scythe Quest (Fast)

- **Quest ID:** 2177 (Finding Fragments with Blinding Scythe of Destiny)
- **Reward:** Bright Aura
- **Requirement:** Blinding Scythe of Destiny

### 3. Blinding Broadsword Quest (Fast)

- **Quest ID:** 2178 (Finding Fragments with Blinding Broadsword of Destiny)
- **Reward:** Bright Aura
- **Requirement:** Blinding Broadsword of Destiny

### 4. Ultimate Weapon Kit Quest (Alternative)

- **Quest ID:** 2163
- **Reward:** Bright Aura (as byproduct)
- **Requirement:** Quest 2163 unlocked

### 5. Loyal Spirit Orb Merge (Slowest)

- **Shop:** Light Merge Shop (Necropolis, Shop ID 422)
- **Cost:** 50 Loyal Spirit Orbs = 1 Bright Aura
- **Used as:** Fallback when no Blinding weapons available

## How to Use This Script

### In Skua:

1. **Navigate to:** Scripts → Good → BLoD
2. **Select:** "Bright Aura Farm"
3. **Configure:** Set the quantity you need (default: 125)
4. **Run:** The script will automatically use the fastest method available

### Configuration Options:

- **Quantity:** How many Bright Aura you need (default: 125)

## What the Script Does

1. ✅ Checks which Blinding weapons you have
2. ✅ Checks if Ultimate WK quest is unlocked
3. ✅ Selects the fastest available method
4. ✅ Shows you which method it's using
5. ✅ Farms until target quantity reached
6. ✅ Logs progress and completion

## Output Example

```
=== Bright Aura Farming Guide ===
Target: 125 Bright Aura

FASTEST METHODS (in order of speed):
1. Blinding Bow Quest (2174) - Gives 5 Bright Aura per turn-in
   Requires: Blinding Bow of Destiny
2. Ultimate Weapon Kit Quest (2163) - Gives Bright Aura
   Requires: Quest 2163 unlocked
3. Merge from Loyal Spirit Orbs - 50 Loyal Spirit Orbs = 1 Bright Aura
   Slowest method, used as fallback

✓ You have Blinding Bow - Using FASTEST method!
  This will give you 5 Bright Aura per quest turn-in

[Farming begins...]

=== Farming Complete! ===
You now have 125 Bright Aura
```

## Recommendation

If you **don't have Blinding Bow yet** and need a lot of Bright Aura (100+):

- Consider getting the Blinding Bow first
- The 5x speed increase is worth it for large quantities
- Use the main BLoD script to get the Bow

If you **already have Blinding Bow**:

- Just run this script directly
- It will automatically use the fast method

## Reddit Community Feedback

From the Reddit thread about BLoD farming:

> "yeah merge loyal spirit orbs. or if you have blinding bow you could get 5 per turn in."

> "Get the blinding weapons. Bow, mace and something else it'll make the rest of the grind ez"

> "The fastest way is to get the mace and the scythe, it helped me farm for blod in 2 days literally."

## Technical Details

### Script Location

- **Path:** `Good/BLoD/BrightAuraFarm.cs`
- **Size:** 3,346 bytes
- **Repository:** https://github.com/MehdiMamas/Scripts-Skua

### Dependencies

```csharp
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Story/BattleUnder.cs
```

### Core Methods Used

- `CoreBLOD.BrightAura(int quant)` - Main farming logic
- `CoreBLOD.FindingFragments(weapon, item, quant)` - For Blinding weapon quests
- `CoreBLOD.UltimateWK(item, quant)` - For Ultimate WK quest
- `CoreBLOD.LoyalSpiritOrb(int quant)` - For merge fallback

## scripts.json Entry

```json
{
  "name": "Bright Aura Farm",
  "description": "Farms Bright Aura using the fastest methods available. Uses Blinding Bow quest (5 per turn-in) if available, Ultimate WK quest, or merges from Loyal Spirit Orbs as fallback.",
  "tags": [
    "bright aura",
    "blod",
    "blinding light of destiny",
    "bow",
    "spirit orb",
    "loyal spirit orb"
  ],
  "path": "Good/BLoD/BrightAuraFarm.cs",
  "size": 3346,
  "fileName": "BrightAuraFarm.cs",
  "downloadUrl": "https://raw.githubusercontent.com/MehdiMamas/Scripts-Skua/Skua/Good/BLoD/BrightAuraFarm.cs"
}
```

## Version History

### v1.0 (2025-10-26)

- ✅ Initial release
- ✅ Automatic method detection
- ✅ Support for all farming methods
- ✅ Detailed logging and progress tracking
- ✅ Configurable quantity option

---

**Created:** 2025-10-26  
**Author:** Custom fork modification  
**Based on:** Reddit community feedback and CoreBLOD.cs optimization
