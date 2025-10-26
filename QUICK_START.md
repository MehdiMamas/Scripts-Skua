# Quick Start Guide - Regular Updates

## 📌 You're All Set Up!

Your fork is configured and ready. Here's how to regularly check for updates.

## 🚀 Regular Check (Do This Weekly)

### Option 1: Double-Click (Easiest) ⭐

**Just double-click this file in Windows Explorer:**

```
check-updates.bat
```

That's it! The script will:

- Check if updates are available from upstream/Skua branch
- Show you what's new
- Warn you if your custom files are affected
- Tell you exactly what to do next

### Option 2: Quick Git Command

Open Git Bash here and run:

```bash
git fetch upstream && git log HEAD..upstream/Skua --oneline -10
```

## ✅ When To Check

- **Every Monday morning** (or your preferred day)
- **Before major bot sessions** (to get latest bug fixes)
- **After AQW game updates** (scripts may be updated for new content)

## 🔄 How To Update (When Available)

When `check-updates.bat` shows updates are available:

### Option 1: Safe Auto-Update (Recommended) ⭐

**Double-click:**

```
safe-update.bat
```

The script will:

1. Save your current work
2. Create automatic backup
3. Show what will change
4. Ask for confirmation
5. Merge updates safely
6. Push to your fork

### Option 2: Manual Update

```bash
# In Git Bash
git add . && git commit -m "Save work"
git fetch upstream
git merge upstream/Skua
git push origin Skua
```

## ⚠️ Your Custom Files

You have custom changes in:

- **CoreBots.cs** - Cutscene skip fix
- **CoreStory.cs** - Multi-monster KillQuest fix

When these files update from upstream, you might need to **resolve conflicts**.

### If Conflicts Happen

The safe-update script will warn you. Then:

1. **Don't panic!** You have automatic backup
2. **Open the conflicted file** in your editor
3. **Look for conflict markers** (`<<<<<<<`, `=======`, `>>>>>>>`)
4. **Keep both** your changes AND upstream changes (merge them)
5. **Test after resolving**

Or read: `FORK_WORKFLOW.md` for detailed conflict resolution guide.

## 🧪 After Updating - Test These

- [ ] Run a story with cutscenes (test cutscene skip fix)
- [ ] Run quest 7114 in ghostnexus (test multi-monster fix)
- [ ] Run any basic script (general functionality)

## 📁 All Your Files

- **check-updates.bat** - Check for updates (Windows)
- **check-updates.sh** - Check for updates (Git Bash)
- **safe-update.bat** - Safe auto-update (Windows)
- **safe-update.sh** - Safe auto-update (Git Bash)
- **REGULAR_CHECK_GUIDE.md** - Detailed check guide
- **FORK_WORKFLOW.md** - Complete fork management
- **CUSTOM_CHANGES.md** - What you've modified
- **AGENT.md** - Debugging guide

## 🆘 Emergency Commands

### Undo Last Update

```bash
git reset --hard backup-[date]
git push -f origin Skua
```

### See Backup Branches

```bash
git branch | grep backup
```

### Restore From Backup

```bash
git reset --hard backup-20251026-143022
```

## 🎯 TL;DR (Too Long; Didn't Read)

**Every week:**

1. Double-click `check-updates.bat`
2. If updates available → Double-click `safe-update.bat`
3. Resolve any conflicts if needed
4. Test your custom fixes
5. Done!

---

**Need detailed help?** Check the other guides:

- **REGULAR_CHECK_GUIDE.md** - Full checking guide
- **FORK_WORKFLOW.md** - Conflict resolution
- **AGENT.md** - Development guide
