class Solution:
    def countSubstrings(self, s: str) -> int:
        def countPalindromes(i: int, j: int) -> int:
            count = int(s[i] == s[j])  # <-- mistake here
            while i-1 in range(len(s)) and j+1 in range(len(s)) and s[i-1] == s[j+1]:
                i, j = i-1, j+1
                count += 1
            return count
            
        total = 0
        for i in range(len(s)):
            total += countPalindromes(i, i)
            if i > 0:
                total += countPalindromes(i-1, i)
        
        return total