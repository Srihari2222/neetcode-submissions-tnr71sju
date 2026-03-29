class Solution:
    def isInterleave(self, s1: str, s2: str, s3: str) -> bool:
        m, n = len(s1), len(s2)
        if m + n != len(s3):
            return False
        if n < m:
            s1, s2 = s2, s1
            m, n = n, m
        
        dp = [False for _ in range(n + 1)]
        dp[n] = True
        for i in range(m - 1, -1, -1):
            for j in range(n - 1, -1, -1):
                if s2[j] == s3[i + j]:
                    dp[j] |= dp[j + 1]
        return dp[0]