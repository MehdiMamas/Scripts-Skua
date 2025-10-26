#!/bin/bash
# Regular Update Checker for Upstream Repository
# Tracks upstream/Skua branch

cd "C:\Users\mehdi\OneDrive\Documents\Skua\Scripts"

echo "============================================"
echo "  Checking for Upstream Updates"
echo "============================================"
echo ""

# Fetch latest from upstream
echo "📥 Fetching from upstream Skua branch..."
git fetch upstream

echo ""
echo "============================================"
echo "  Current Status"
echo "============================================"

# Show current branch
echo ""
echo "📍 Current branch:"
git branch --show-current

# Check if there are updates
echo ""
echo "📊 Checking for new commits..."
UPDATES=$(git log HEAD..upstream/Skua --oneline)

if [ -z "$UPDATES" ]; then
    echo "✅ Your fork is up-to-date!"
    echo "   No new commits from upstream."
else
    echo "🔔 NEW UPDATES AVAILABLE!"
    echo ""
    echo "New commits from upstream Skua branch:"
    echo "-------------------------------------------"
    git log HEAD..upstream/Skua --oneline --color -10
    echo "-------------------------------------------"
    echo ""
    
    # Count commits
    COUNT=$(git rev-list --count HEAD..upstream/Skua)
    echo "📈 Total new commits: $COUNT"
    
    echo ""
    FILECOUNT=$(git diff --name-only HEAD..upstream/Skua | wc -l)
    echo "Files that will be affected: $FILECOUNT files total"
    echo ""
    echo "First 20 files:"
    echo "-------------------------------------------"
    git diff --name-only HEAD..upstream/Skua | head -20
    echo "-------------------------------------------"
    if [ $FILECOUNT -gt 20 ]; then
        echo "... and $(($FILECOUNT - 20)) more files"
    fi
    
    echo ""
    echo "⚠️  IMPORTANT: Check if these files are affected:"
    git diff --name-only HEAD..upstream/Skua | grep -E "(CoreBots.cs|CoreStory.cs)" || echo "   ✅ Your custom files are safe!"
    
    echo ""
    echo "To update, run:"
    echo "   git merge upstream/Skua"
    echo ""
    echo "Or use the safe update script:"
    echo "   ./safe-update.sh"
fi

echo ""
echo "============================================"
echo "  Your Last Commit"
echo "============================================"
echo ""
git log -1 --oneline --color

echo ""
echo "============================================"
echo "Done!"
echo "============================================"

