class Solution:

    # Encode a list of strings into a single string
    def encode(self, strs: List[str]) -> str:
        if not strs:
            return ""
        
        sizes, res = [], ""
        for s in strs:
            sizes.append(len(s))  # Record the size of each string
        
        for sz in sizes:
            res += str(sz) + ','  # Store sizes with a comma separator
        
        res += '#'  # Use a special character to separate sizes from the actual strings
        
        for s in strs:
            res += s  # Append the actual strings
        return res

    # Decode the encoded string back into a list of strings
    def decode(self, s: str) -> List[str]:
        if not s:
            return []
        
        # Step 1: Extract the sizes
        sizes = []
        i = 0
        while s[i] != '#':  # Read until the delimiter '#'
            size = ""
            while s[i] != ',':  # Collect the size of the next string
                size += s[i]
                i += 1
            sizes.append(int(size))  # Store the size
            i += 1  # Move past the comma
        
        i += 1  # Move past the '#' delimiter

        # Step 2: Extract the actual strings based on sizes
        res = []
        for size in sizes:
            res.append(s[i:i + size])  # Extract the substring of the corresponding size
            i += size  # Move the pointer forward by the size of the string

        return res
