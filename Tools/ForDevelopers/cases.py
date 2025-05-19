# -----------------------------------------------------------------------------
# Instructions:
# 1. Set the 'root_dir' variable below to the root path of your scripts folder.
#    Example: root_dir = r'C:\Path\To\Your\Scripts'
# 2. Make sure CaseStorage.cs exists at Tools\ForDevelopers\CaseStorage.cs
#    relative to your root_dir.
# 3. Save this script.
# 4. Run the script using Python:
#       - Open a terminal/command prompt.
#       - Navigate to the folder containing this script.
#       - Run: python cases.py
# 5. The script will update CaseStorage.cs by adding any new cases found.
# -----------------------------------------------------------------------------
import os
import re
# Paths
root_dir = r'PROVIDE YOUR SCRIPTS FILE PATH HERE'
case_storage_path = os.path.join(root_dir, r'Tools\ForDevelopers\CaseStorage.cs')

# 1. Load existing cases from CaseStorage.cs
with open(case_storage_path, encoding='utf-8') as f:
    case_storage_content = f.read()

existing_cases = set(re.findall(r'{\s*"([^"]+)"\s*,', case_storage_content))

# 2. Find all *merge*.cs files
merge_files = []
for dirpath, _, filenames in os.walk(root_dir):
    for fn in filenames:
        if fn.lower().endswith('.cs') and 'merge' in fn.lower():
            merge_files.append(os.path.join(dirpath, fn))

# 3. Extract all case blocks from merge scripts
def extract_case_blocks(content):
    lines = content.splitlines()
    n = len(lines)
    i = 0
    case_blocks = []
    while i < n:
        # Find start of a case group
        case_labels = []
        while i < n:
            m = re.match(r'\s*case\s+"([^"]+)"\s*:', lines[i])
            if m:
                case_labels.append(m.group(1))
                i += 1
            else:
                break
        if case_labels:
            block_lines = []
            brace_depth = 0
            while i < n:
                line = lines[i]
                # Check for new case/default only if not inside a nested block
                if brace_depth == 0 and (
                    re.match(r'\s*case\s+"', line) or
                    re.match(r'\s*default\s*:', line) or
                    re.match(r'\s*#endregion', line)
                ):
                    break
                # Track braces
                brace_depth += line.count('{')
                brace_depth -= line.count('}')
                block_lines.append(line)
                i += 1
                # If we hit a closing brace at depth 0, it's the end of the switch/case block
                if brace_depth < 0:
                    break
            # Remove trailing empty lines
            while block_lines and not block_lines[-1].strip():
                block_lines.pop()
            # Remove a trailing '}' if present (and only whitespace before/after)
            while block_lines and block_lines[-1].strip() == '}':
                block_lines.pop()
            case_blocks.append((case_labels, block_lines))
        else:
            i += 1
    return case_blocks

new_cases = {}

for file in merge_files:
    with open(file, encoding='utf-8') as f:
        content = f.read()
    for case_labels, block_lines in extract_case_blocks(content):
        for case_name in case_labels:
            if case_name not in existing_cases and case_name not in new_cases:
                # Only the single case line for this label
                block = f'case "{case_name}":\n' + '\n'.join(block_lines)
                block_escaped = block.replace('"', '""')
                new_cases[case_name] = block_escaped

if not new_cases:
    print("No new cases found.")
    exit(0)

# 4. Prepare new cases in CaseStorage.cs dictionary format
formatted_cases = []
for name, block in new_cases.items():
    formatted = f'{{\n    "{name}",\n    @"\n{block}\n    "\n}},\n'
    formatted_cases.append(formatted)

# 5. Insert new cases before the closing '};'
insert_point = case_storage_content.rfind('};')
if insert_point == -1:
    print("Could not find end of dictionary in CaseStorage.cs!")
    exit(1)

new_content = (
    case_storage_content[:insert_point]
    + ''.join(formatted_cases)
    + case_storage_content[insert_point:]
)

# 6. Write back to CaseStorage.cs (NO BACKUP)
with open(case_storage_path, 'w', encoding='utf-8') as f:
    f.write(new_content)

print(f"Inserted {len(new_cases)} new cases into CaseStorage.cs.")