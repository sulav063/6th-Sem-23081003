
# Step 1: Create and add welcome file (already done in main)
echo "Welcome to My Project!" > welcome.md

# Stage and commit on main branch
git add welcome.md
git commit -m "Initial commit: Add welcome message in markdown"

# Step 2: Create a NEW BRANCH called 'feature-update'
git branch feature-update

# Step 3: Switch to the new branch
git checkout feature-update
# OR (modern way): git switch feature-update

# Step 4: Make a change in the new branch
echo "" >> welcome.md
echo "## Version 2.0" >> welcome.md
echo "- Added feature section" >> welcome.md

# Step 5: Check what changed
git status
# Output: modified: welcome.md

# Step 6: Stage the changes
git add welcome.md

# Step 7: Commit the update
git commit -m "feat: Add version header and feature note"

# Step 8: View commit history (compact view)
git log --oneline
