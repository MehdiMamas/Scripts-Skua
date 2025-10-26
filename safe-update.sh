#!/bin/bash
# Safe Update Script - Updates from upstream Skua branch with automatic backup

cd "C:\Users\mehdi\OneDrive\Documents\Skua\Scripts"

echo "============================================"
echo "  Safe Update from Upstream"
echo "============================================"
echo ""

# Save current work
echo "💾 Step 1: Saving current work..."
git add .
git commit -m "Auto-save before upstream update $(date +%Y-%m-%d_%H-%M-%S)" 2>/dev/null || echo "   (No changes to save)"

# Create backup branch
BACKUP_BRANCH="backup-$(date +%Y%m%d-%H%M%S)"
echo ""
echo "🔒 Step 2: Creating backup branch: $BACKUP_BRANCH"
git branch $BACKUP_BRANCH
echo "   ✅ Backup created! To restore: git reset --hard $BACKUP_BRANCH"

# Fetch upstream
echo ""
echo "📥 Step 3: Fetching from upstream Skua branch..."
git fetch upstream

# Check if there are updates
UPDATES=$(git log HEAD..upstream/Skua --oneline)
if [ -z "$UPDATES" ]; then
    echo ""
    echo "✅ Already up-to-date!"
    echo "   No updates needed."
    exit 0
fi

# Show what will change
echo ""
echo "📋 Step 4: Preview of changes:"
echo "-------------------------------------------"
git log HEAD..upstream/Skua --oneline --color -5
echo "-------------------------------------------"

echo ""
FILECOUNT=$(git diff --name-only HEAD..upstream/Skua | wc -l)
echo "Files that will be modified: $FILECOUNT files total"
echo ""
echo "First 20 files:"
echo "-------------------------------------------"
git diff --name-only HEAD..upstream/Skua | head -20
echo "-------------------------------------------"
if [ $FILECOUNT -gt 20 ]; then
    echo "... and $(($FILECOUNT - 20)) more files"
fi

echo ""
echo "⚠️  Checking your custom files..."
CONFLICTS=""
if git diff --name-only HEAD..upstream/Skua | grep -q "CoreBots.cs"; then
    echo "   ⚠️  WARNING: CoreBots.cs will be updated (you have custom changes here!)"
    CONFLICTS="yes"
fi
if git diff --name-only HEAD..upstream/Skua | grep -q "CoreStory.cs"; then
    echo "   ⚠️  WARNING: CoreStory.cs will be updated (you have custom changes here!)"
    CONFLICTS="yes"
fi

if [ -z "$CONFLICTS" ]; then
    echo "   ✅ Your custom files are safe!"
fi

echo ""
echo "-------------------------------------------"
echo "Ready to merge?"
echo "-------------------------------------------"
read -p "Continue with merge? (y/N) " -n 1 -r
echo

if [[ ! $REPLY =~ ^[Yy]$ ]]; then
    echo ""
    echo "❌ Update cancelled."
    echo "   Backup branch $BACKUP_BRANCH is still available."
    exit 0
fi

# Perform merge
echo ""
echo "🔀 Step 5: Merging upstream/Skua..."
git merge upstream/Skua

if [ $? -eq 0 ]; then
    echo ""
    echo "✅ Merge successful!"
    echo ""
    echo "📤 Step 6: Pushing to your fork..."
    git push origin Skua
    
    echo ""
    echo "============================================"
    echo "  Update Complete!"
    echo "============================================"
    echo ""
    echo "✅ Your fork is now up-to-date!"
    echo ""
    echo "🧪 IMPORTANT: Test your custom modifications:"
    echo "   - Cutscene skip fix (run story with cutscenes)"
    echo "   - Multi-monster KillQuest (quest 7114)"
    echo ""
    echo "If everything works, you can delete the backup:"
    echo "   git branch -d $BACKUP_BRANCH"
else
    echo ""
    echo "⚠️  CONFLICTS DETECTED!"
    echo ""
    echo "Conflicts need to be resolved manually."
    echo "See FORK_WORKFLOW.md for conflict resolution guide."
    echo ""
    echo "To abort the merge:"
    echo "   git merge --abort"
    echo ""
    echo "To restore from backup:"
    echo "   git reset --hard $BACKUP_BRANCH"
fi

