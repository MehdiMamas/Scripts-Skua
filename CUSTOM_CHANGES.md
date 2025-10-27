# Custom Modifications Log

This document tracks all custom modifications made to this fork that differ from the upstream repository.

## ⚠️ IMPORTANT - KEEP THIS UPDATED!

**After EVERY change, modification, fix, or new script you add:**

1. ✅ Update this file (CUSTOM_CHANGES.md) with what was changed
2. ✅ Update version history at the bottom
3. ✅ Update "Last Updated" date
4. ✅ Update AGENT.md if you added new patterns/guidelines

**This is critical for:**

- 📝 Tracking what differs from upstream
- 🔄 Resolving merge conflicts when pulling updates
- 📚 Understanding the fork's evolution
- ✅ Knowing what custom features exist

**Don't skip this step - document as you code!**

---

## Modified Core Files

### 1. CoreBots.cs

#### Cutscene Skip Black Screen Fix

**Lines Modified:**

- ~5493-5506 (new FixCutsceneBlackScreen method)
- ~6991 (in Jump method - called after cell change)
- ~7236 (in PerformJump method - called after cell change)
- ~8010 (in Join method - called after map load)
- ~8213 (in CutSceneFixer method - called when stuck in cutscene cell)

**What it does:** Fixes black screen that occurs after skipping cutscenes by toggling the LagKiller option.

**Code Added:**

```csharp
// New reusable method (lines ~5493-5506)
/// <summary>
/// Fixes black screen after cutscene skip by toggling LagKiller
/// Runs asynchronously to not block bot execution
/// </summary>
private void FixCutsceneBlackScreen()
{
    Task.Run(async () =>
    {
        await Task.Delay(500); // Wait 500ms for cutscene to be skipped
        Bot.Options.LagKiller = true;
        await Task.Delay(100);
        Bot.Options.LagKiller = false;
    });
}

// Called in multiple locations:
// 1. Jump method - after jumping to new cell
FixCutsceneBlackScreen();

// 2. PerformJump method - after cell change
FixCutsceneBlackScreen();

// 3. Join method - after map load
FixCutsceneBlackScreen();

// 4. CutSceneFixer method - when stuck in cutscene cell
FixCutsceneBlackScreen();
```

**Why this change:**
When `Bot.Options.SkipCutscenes = true` is enabled (line 228), the game client automatically skips cutscenes. This often leaves the screen black because the client doesn't properly refresh the display.

The fix toggles `LagKiller` which forces the game client to redraw/refresh the screen.

**Applied in 4 key locations:**

1. **Jump method** - After jumping to any cell (room-to-room movement)
2. **PerformJump method** - After cell changes via JumpWait
3. **Join method** - After loading any map
4. **CutSceneFixer method** - When stuck in cutscene cells

**How it works:**

- Waits **500ms asynchronously** (for cutscene to be skipped)
- Toggles `LagKiller = true` → wait 100ms → `LagKiller = false`
- Runs in background, doesn't block bot execution
- Forces game client to redraw/refresh screen

The async delay is critical - cutscenes are skipped slightly AFTER movement/loading completes, so we wait 500ms before applying the fix.

**Impact:**

- ✅ Works automatically for ALL maps, cells, and scripts
- ✅ Fixes black screen after ANY movement (map-to-map, room-to-room, cell-to-cell)
- ✅ Comprehensive coverage - catches cutscenes everywhere
- ⚠️ May conflict if upstream modifies Jump, PerformJump, Join, or CutSceneFixer methods

---

## New Custom Scripts

### 1. Good/BLoD/BrightAuraFarm.cs

**Purpose:** Dedicated script for farming Bright Aura using the fastest available methods.

**What it does:**

- Automatically detects which Blinding weapons you have
- Uses the fastest farming method available:
  - **Blinding Bow Quest (2174)** - 5 Bright Aura per turn-in (FASTEST)
  - **Blinding Scythe/Broadsword Quests** - Alternative fast methods
  - **Ultimate Weapon Kit Quest (2163)** - If unlocked
  - **Loyal Spirit Orb Merge** - Fallback method (50 LSO = 1 Bright Aura)
- Provides detailed logging about which method is being used
- Configurable quantity option (default: 125)

**Why it exists:** Based on Reddit community feedback, having the Blinding Bow gives 5x faster Bright Aura farming. This script optimizes the farming process by automatically selecting the best method.

**scripts.json entry:**

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

**Important:** Uses custom fork URL (`MehdiMamas/Scripts-Skua`) instead of upstream URL.

---

### 2. SkuaScriptsGenerator/Factories/Writers/SkuaScriptsJsonWriter.cs

**Purpose:** Automatic scripts.json generator that scans all .cs files and creates the scripts.json database.

**What was changed:**

- **Line 11:** Changed base URL from upstream to fork URL

  ```csharp
  // BEFORE:
  var rawScriptsURL = "https://raw.githubusercontent.com/BrenoHenrike/Scripts/Skua/";

  // AFTER:
  var rawScriptsURL = "https://raw.githubusercontent.com/MehdiMamas/Scripts-Skua/Skua/";
  ```

**Why this change:**

When you regenerate scripts.json (which happens when adding new scripts), this tool automatically:

1. Scans all .cs files in the repository
2. Reads their headers (name, description, tags)
3. Generates downloadUrl for each script
4. Creates the scripts.json file

By changing the base URL to your fork, **all scripts automatically use your fork URL** when scripts.json is regenerated. This means:

- ✅ You don't have to manually edit URLs after regenerating
- ✅ All scripts (including upstream ones) point to your fork
- ✅ Skua will download scripts from your fork, including your custom scripts
- ✅ Consistent URL structure across all entries

**Important for merge conflicts:**

This file is unlikely to change in upstream, but if it does:

- ✅ **KEEP:** Your custom fork URL on line 11
- ✅ **MERGE:** Any other changes from upstream (new features, bug fixes)

**How to regenerate scripts.json:**

```bash
cd SkuaScriptsGenerator
dotnet run > ../scripts.json
```

This will regenerate scripts.json with all scripts pointing to your fork.

---

## New Custom Documentation Files

### 1. AGENT.md

**Purpose:** Comprehensive debugging guide for AI agents fixing script issues.

**What it contains:**

- Project structure overview
- Common issues and fixes
- Core methods reference (CoreBots, CoreStory, CoreFarms, CoreAdvanced, CoreDailies)
- Debugging workflow
- Important reminders about not editing z_CompiledScript.cs
- Before creating new functions checklist
- Script structure guidelines
- Debugging and logging methods

**Why it exists:** To help AI assistants (or future developers) understand the codebase structure, avoid recreating existing functionality, and fix issues properly without breaking things.

---

### 2. FORK_WORKFLOW.md

**Purpose:** Guide for managing this fork while staying up-to-date with upstream.

**Why it exists:** To document the process of safely pulling updates from BrenoHenrike/Scripts while preserving custom modifications.

---

### 3. CUSTOM_CHANGES.md

**Purpose:** This file - tracks all modifications.

**Why it exists:** Quick reference for what's been changed when resolving merge conflicts.

---

## Files Modified (Summary)

### Core Framework Files (⚠️ Watch for conflicts)

1. `CoreBots.cs` - Added cutscene skip fix

### Custom Scripts (✅ Safe, unique to this fork)

1. `Good/BLoD/BrightAuraFarm.cs` - New custom script
2. `scripts.json` - Modified to include custom script with fork URL

### Configuration Files (⚠️ Important for fork maintenance)

1. `SkuaScriptsGenerator/Factories/Writers/SkuaScriptsJsonWriter.cs` - Changed base URL
   - **Line 11:** Changed from `BrenoHenrike/Scripts` to `MehdiMamas/Scripts-Skua`
   - **Why:** Ensures all scripts.json entries use the fork URL when regenerated
   - **Impact:** When regenerating scripts.json, all URLs automatically point to this fork

### Documentation Files (✅ Safe, no upstream equivalent)

1. `AGENT.md` - New file
2. `FORK_WORKFLOW.md` - New file
3. `CUSTOM_CHANGES.md` - New file (this)
4. `SETUP_FORK.md` - New file
5. `REGULAR_CHECK_GUIDE.md` - New file
6. `QUICK_START.md` - New file

### Data Files (✅ Safe, utility files)

1. `ids/QuestData - QuestData.csv` - Quest database
2. `ids/Shop ID List - 1-1000.csv` - Shop IDs
3. `ids/Shop ID List - 1001-2000.csv` - Shop IDs
4. `ids/Shop ID List - 2001-3000.csv` - Shop IDs

---

## Merge Conflict Strategy

### High Priority (Must Keep Custom Code)

**CoreBots.cs:**

- ✅ **KEEP:** FixCutsceneBlackScreen method (lines ~5493-5506)
- ✅ **KEEP:** FixCutsceneBlackScreen() calls in Jump, PerformJump, Join methods
- ✅ **MERGE:** Any upstream changes to other parts of the file

### Medium Priority (Review Before Merging)

**Story Scripts:**

- Most story scripts can be safely updated from upstream
- Exception: Any story scripts you've personally fixed

### Low Priority (Safe to Update)

**Everything Else:**

- Farm scripts
- Daily scripts
- Seasonal scripts
- Other utility scripts
- Templates

---

## Testing Checklist After Updates

After merging upstream changes, test these features:

- [ ] **Cutscene Skip Fix:** Run a story with cutscenes (e.g., DoomVault)
  - Verify screen doesn't stay black after cutscene
- [ ] **Multi-Monster KillQuest:** Run quest 7114 in ghostnexus
  - Verify it hunts both "Abumi Guchi" AND "Infernal Knight"
  - Should get 8+ kills on each monster
- [ ] **Basic Functionality:**
  - [ ] Core.HuntMonster works
  - [ ] Story.KillQuest works
  - [ ] Farm.Gold works
  - [ ] Core.Join/Jump works

---

## Version History

### v1.0 (Initial Fork)

- Forked from BrenoHenrike/Scripts (Skua branch)

### v1.1 (Custom Modifications)

- ✅ Added cutscene skip black screen fix (CoreBots.cs)
- ✅ Fixed multi-monster KillQuest issue (CoreStory.cs)
- ✅ Created AGENT.md documentation
- ✅ Created FORK_WORKFLOW.md guide
- ✅ Created CUSTOM_CHANGES.md tracking

### v1.2 (Custom Scripts)

- ✅ Created BrightAuraFarm.cs - Optimized Bright Aura farming script
- ✅ Added script to scripts.json with custom fork URL
- ✅ Updated CUSTOM_CHANGES.md to document new script
- ✅ Updated AGENT.md with custom script guidelines
- ✅ Created Good/BLoD/BRIGHT_AURA_README.md - Comprehensive farming guide

### v1.3 (Documentation Standards)

- ✅ Added prominent documentation reminders to AGENT.md (top and bottom)
- ✅ Added documentation reminder section to CUSTOM_CHANGES.md (top)
- ✅ Added "CRITICAL - ALWAYS UPDATE DOCUMENTATION" section to AGENT.md
- ✅ Updated "Remember" checklist in AGENT.md to include documentation
- ✅ Established documentation workflow and best practices

**Why:** To ensure all future changes are properly documented, making merge conflicts easier to resolve and tracking the fork's evolution.

### v1.4 (Current - Scripts Generator Configuration & Complete Regeneration)

- ✅ Updated SkuaScriptsJsonWriter.cs to use fork URL instead of upstream URL
- ✅ Changed line 11 from `BrenoHenrike/Scripts` to `MehdiMamas/Scripts-Skua`
- ✅ Fixed path separator to use forward slashes (/) instead of backslashes (\)
- ✅ Regenerated entire scripts.json with all 1,787 scripts using fork URL
- ✅ Verified BrightAuraFarm.cs is included with correct fork URL
- ✅ Documented in CUSTOM_CHANGES.md with full explanation
- ✅ Added scripts.json regeneration instructions

**Result:**

- All 1,787 scripts in scripts.json now point to `https://raw.githubusercontent.com/MehdiMamas/Scripts-Skua/Skua/`
- Skua will download ALL scripts from your fork (including your custom modifications)
- Custom scripts automatically included when regenerating

**Why:** Ensures Skua always downloads from your fork with all custom modifications and fixes.

---

Last Updated: 2025-10-26
