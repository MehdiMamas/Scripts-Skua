# Regular Update Check Guide

This guide shows you how to regularly check for updates from the upstream repository (BrenoHenrike/Scripts - Skua branch).

## 🚀 Quick Check Methods

### Method 1: Double-Click Check (Easiest)

Simply double-click one of these files in Windows Explorer:

- **`check-updates.bat`** - Check if updates are available
- **`safe-update.bat`** - Check AND update with automatic backup

### Method 2: Manual Git Command

Open Git Bash in the Scripts folder and run:

```bash
git fetch upstream && git log HEAD..upstream/Skua --oneline
```

If you see commits listed, there are updates available!

### Method 3: GitHub Web Check

1. Go to BrenoHenrike's repo: https://github.com/BrenoHenrike/Scripts/commits/Skua
2. Check recent commits on the Skua branch
3. Compare with your last update date

## 📅 Recommended Schedule

### Weekly Check (Recommended)

BrenoHenrike updates frequently, so check weekly:

- Every Monday morning
- OR every Friday afternoon
- Run `check-updates.bat`

### Before Important Bot Runs

Before major farming sessions:

- Check for bug fixes
- Run `check-updates.bat`
- Update if there are critical fixes

### After Major AQW Updates

When AQW releases major updates:

- Scripts might be updated to fix broken quests
- Check within 1-2 days of AQW release

## 🔧 Setting Up Desktop Shortcuts (Optional)

Create desktop shortcuts for easy access:

1. **Right-click on Desktop** → New → Shortcut
2. **For check script:**
   - Location: `C:\Users\mehdi\OneDrive\Documents\Skua\Scripts\check-updates.bat`
   - Name: "🔍 Check Script Updates"
3. **For update script:**
   - Location: `C:\Users\mehdi\OneDrive\Documents\Skua\Scripts\safe-update.bat`
   - Name: "⬇️ Update Scripts Safely"

## 📊 What the Check Script Shows

When you run `check-updates.bat`, you'll see:

```
============================================
  Checking for Upstream Updates
============================================

Fetching from upstream Skua branch...

============================================
  Current Status
============================================

Current branch: master

Checking for new commits...
================================
  NEW UPDATES AVAILABLE!
================================

New commits from upstream Skua branch:
-------------------------------------------
abc1234 Fixed quest 7890 monster name
def5678 Updated CoreFarms gold farming
ghi9012 Bug fix for cutscene handling
-------------------------------------------

Total new commits: 3

Files that will be affected: 5 files total

First 20 files:
-------------------------------------------
Farm/GoldFarm.cs
Story/SomeStory.cs
CoreFarms.cs
-------------------------------------------

IMPORTANT: Check if your custom files are affected:
   ✅ Your custom files are safe!

To update, run:
   safe-update.bat
```

### Understanding the Output

#### ✅ If Up-to-Date:

```
Your fork is up-to-date!
No new commits from upstream.
```

**Action:** Nothing to do! You're current.

#### 🔔 If Updates Available (No Conflicts):

```
NEW UPDATES AVAILABLE!
✅ Your custom files are safe!
```

**Action:** Run `safe-update.bat` to update safely.

#### ⚠️ If Updates Affect Your Files:

```
NEW UPDATES AVAILABLE!
WARNING: CoreBots.cs will be updated (you have custom changes!)
```

**Action:**

1. Read the FORK_WORKFLOW.md guide
2. Run `safe-update.bat` (it creates automatic backup)
3. Resolve conflicts carefully
4. Test your custom modifications after update

## 🛡️ Safe Update Process

The `safe-update.bat` script does this automatically:

1. ✅ **Saves your current work** (auto-commit)
2. ✅ **Creates backup branch** (for easy rollback)
3. ✅ **Fetches upstream changes from Skua branch**
4. ✅ **Shows preview** of what will change
5. ✅ **Warns about conflicts** with your custom files
6. ❓ **Asks for confirmation** before merging
7. ✅ **Merges updates** (with conflict detection)
8. ✅ **Pushes to your fork**

If anything goes wrong, you can restore from the backup!

## 🧪 After Update Testing Checklist

After updating, test these features:

- [ ] **Cutscene Skip Fix**

  - Run any story script with cutscenes (e.g., DoomVault)
  - Verify screen doesn't stay black after cutscene skip

- [ ] **Multi-Monster KillQuest**

  - Run quest 7114 in ghostnexus
  - Verify it hunts BOTH "Abumi Guchi" AND "Infernal Knight"

- [ ] **General Functionality**
  - Run a simple gold farming script
  - Run a simple story script
  - Verify no errors

## 📞 Quick Commands Reference

### Check for Updates

```bash
# Windows (double-click or run in cmd)
check-updates.bat

# Git Bash
./check-updates.sh
```

### Safe Update

```bash
# Windows (double-click or run in cmd)
safe-update.bat

# Git Bash
./safe-update.sh
```

### Manual Commands

```bash
# Check for updates manually (Skua branch)
git fetch upstream
git log HEAD..upstream/Skua --oneline

# See what files changed
git diff --name-only HEAD..upstream/Skua

# Update (if no conflicts expected)
git merge upstream/Skua
git push origin Skua
```

## 🆘 Emergency Recovery

If an update breaks something:

### Restore from Automatic Backup

```bash
# List backup branches
git branch | grep backup

# Restore from most recent backup
git reset --hard backup-20251026-143022

# Force push to your fork (careful!)
git push -f origin Skua
```

### Restore Specific File

```bash
# Restore just CoreBots.cs from last commit
git checkout HEAD~1 -- CoreBots.cs

# Or from specific backup
git checkout backup-20251026-143022 -- CoreBots.cs
```

## 🎯 Summary

**Recommended Workflow:**

1. **Every Monday:** Double-click `check-updates.bat`
2. **If updates available:** Double-click `safe-update.bat`
3. **After update:** Test cutscene fix and multi-monster quests
4. **If problems:** Restore from automatic backup

**That's it!** The scripts handle everything else automatically.

---

**Need Help?** Check:

- FORK_WORKFLOW.md - Detailed update procedures
- CUSTOM_CHANGES.md - Your modification list
- AGENT.md - General development guide
