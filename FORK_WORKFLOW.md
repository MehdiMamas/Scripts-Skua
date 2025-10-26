# Fork Management & Update Strategy

## Overview

This repository is a fork of [BrenoHenrike/Scripts](https://github.com/BrenoHenrike/Scripts) with custom modifications. This document explains how to safely pull updates from upstream while preserving your custom changes.

## Repository Setup

### Current State

- **Upstream (Original):** https://github.com/BrenoHenrike/Scripts (branch: **Skua**)
- **Your Fork:** https://github.com/MehdiMamas/Scripts-Skua
- **Local:** C:\Users\mehdi\OneDrive\Documents\Skua\Scripts

**IMPORTANT:** This fork tracks the **Skua branch** of upstream, not master!

### Remotes Configuration

```bash
# Check configured remotes
git remote -v

# Should show:
# origin    https://github.com/MehdiMamas/Scripts-Skua.git (fetch)
# origin    https://github.com/MehdiMamas/Scripts-Skua.git (push)
# upstream  https://github.com/BrenoHenrike/Scripts.git (fetch)
# upstream  https://github.com/BrenoHenrike/Scripts.git (push)
```

## Files With Custom Modifications

### Critical Files (Your Changes)

These files contain YOUR custom modifications and should be carefully managed:

1. **CoreBots.cs** - Added cutscene skip black screen fix

   - Lines ~5493-5506: FixCutsceneBlackScreen() method
   - Line ~6991: Call in Jump method
   - Line ~7236: Call in PerformJump method
   - Line ~8010: Call in Join method
   - Line ~8213: Call in CutSceneFixer method

2. **CoreStory.cs** - Fixed multi-monster KillQuest handling

   - Lines ~242-294: Modified main farming loop to use Bot.Quests.CanComplete()

3. **Custom Documentation Files:**

   - AGENT.md
   - FORK_WORKFLOW.md (this file)
   - CUSTOM_CHANGES.md
   - SETUP_FORK.md
   - REGULAR_CHECK_GUIDE.md
   - QUICK_START.md

4. **Update Scripts:**
   - check-updates.bat/sh
   - safe-update.bat/sh

## Update Workflow

### Method 1: Safe Update (Recommended)

This method preserves your changes and lets you review conflicts:

```bash
# 1. Make sure your work is committed
git add .
git commit -m "Save current work before update"

# 2. Fetch upstream changes
git fetch upstream

# 3. Create a backup branch (safety net)
git branch backup-before-update

# 4. Review what's changed upstream (tracking Skua branch)
git log HEAD..upstream/Skua --oneline
git diff HEAD..upstream/Skua

# 5. Merge upstream changes into your Skua branch
git merge upstream/Skua

# If conflicts occur, see "Handling Conflicts" section below
```

### Method 2: Using the Safe Update Script

Simply run:

```bash
safe-update.bat    # Windows
./safe-update.sh   # Git Bash
```

The script will:

- Auto-save your work
- Create backup branch
- Fetch from upstream
- Show preview of changes
- Warn about conflicts with your custom files
- Ask for confirmation
- Merge and push

## Handling Conflicts

When conflicts occur during merge:

### Step 1: Identify Conflicted Files

```bash
# View conflicted files
git status

# Files with conflicts will show as "both modified" or "both added"
```

### Step 2: Resolve Conflicts

For each conflicted file:

1. **Open the file** in your editor
2. **Look for conflict markers:**
   ```
   <<<<<<< HEAD (your changes)
   Your code here
   =======
   Upstream code here
   >>>>>>> upstream/Skua
   ```
3. **Decide what to keep:**
   - Keep your changes only
   - Keep upstream changes only
   - Merge both changes together (most common for core files)

### Step 3: Common Conflict Scenarios

#### Scenario A: CoreBots.cs Conflict

If there's a conflict in CoreBots.cs:

1. **Find your custom code:**
   - FixCutsceneBlackScreen method (~lines 5493-5506)
   - Calls to FixCutsceneBlackScreen() in Jump, PerformJump, Join
2. **Keep BOTH your changes AND upstream changes**
3. **Make sure your FixCutsceneBlackScreen method and calls are intact**

Example resolution:

```csharp
// If upstream added new code near your fix, keep both:
public void RespawnListener(dynamic packet)
{
    // ... upstream code ...
}

// YOUR CUSTOM METHOD - KEEP THIS!
private void FixCutsceneBlackScreen()
{
    Task.Run(async () =>
    {
        await Task.Delay(500);
        Bot.Options.LagKiller = true;
        await Task.Delay(100);
        Bot.Options.LagKiller = false;
    });
}

public bool IsDungeonMonsterAlive(Monster? mon)
{
    // ... upstream code continues ...
}
```

#### Scenario B: CoreStory.cs Conflict

If there's a conflict in CoreStory.cs:

1. **Find your KillQuest modification** (lines ~242-294)
2. **Upstream may have updated other parts** - keep their changes
3. **Your modification changes the loop condition** - keep your version
4. **Merge carefully:**
   ```csharp
   // YOUR CRITICAL CHANGE - Keep this loop condition:
   while (!Bot.Quests.CanComplete(QuestID))
   {
       // ... rest of the loop
   }
   ```

### Step 4: Complete the Merge

```bash
# After resolving all conflicts:

# 1. Mark as resolved
git add <resolved-file>

# 2. Continue merge
git merge --continue

# 3. If you mess up, abort and try again
git merge --abort
```

## Testing After Update

After successfully merging updates:

```bash
# 1. Run a test script to ensure nothing broke
# Test basic functionality

# 2. Check your custom modifications still work:
# - Test cutscene skip fix (run a story with cutscenes)
# - Test multi-monster KillQuest (quest 7114 in ghostnexus)

# 3. If everything works, push to your fork
git push origin Skua
```

## Recommended Update Schedule

- **Weekly:** Check for upstream updates from Skua branch
- **Before Major Bot Sessions:** Update to get latest bug fixes
- **After Upstream Has Major Changes:** Review changelog before updating

## Viewing Changes Before Updating

```bash
# See what changed in upstream (Skua branch)
git fetch upstream
git log HEAD..upstream/Skua --oneline

# See detailed changes in specific file
git diff HEAD..upstream/Skua -- CoreBots.cs

# See list of changed files
git diff --name-only HEAD..upstream/Skua
```

## Emergency Recovery

If an update completely breaks everything:

```bash
# Option 1: Restore from backup branch
git reset --hard backup-before-update

# Option 2: Restore to last working commit
git log  # Find the commit hash
git reset --hard <commit-hash>

# Option 3: Restore specific file
git checkout HEAD~1 -- CoreBots.cs

# Option 4: Force push to fix your fork
git push -f origin master
```

## Best Practices

### ✅ DO:

- Always create backup branch before updating
- Commit your work before pulling updates
- Test thoroughly after merging updates
- Document your custom changes
- Review upstream changelog before updating
- Track the **Skua branch** specifically

### ❌ DON'T:

- Don't force push to your fork without backups
- Don't modify z_CompiledScript.cs (it's auto-generated anyway)
- Don't update during active bot runs
- Don't merge blindly without reviewing changes
- Don't track upstream/master (use upstream/Skua instead!)

---

**You're all set!** Your fork is properly configured to receive updates from upstream's Skua branch while maintaining your custom changes.
