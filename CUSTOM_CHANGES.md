# Custom Modifications Log

This document tracks all custom modifications made to this fork that differ from the upstream repository.

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

## New Custom Files

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

### v1.1 (Current - Custom Modifications)

- ✅ Added cutscene skip black screen fix (CoreBots.cs)
- ✅ Fixed multi-monster KillQuest issue (CoreStory.cs)
- ✅ Created AGENT.md documentation
- ✅ Created FORK_WORKFLOW.md guide
- ✅ Created CUSTOM_CHANGES.md tracking

---

Last Updated: 2025-10-26
