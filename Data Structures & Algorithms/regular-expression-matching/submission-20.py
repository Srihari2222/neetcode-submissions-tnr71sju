class Solution:
    def isMatch(self, s: str, p: str) -> bool:
        dp = [False] * (len(p) + 1)
        dp[-1] = True  # Initialize the last element to True
        
        for i in range(len(s), -1, -1):
            dp1 = (i == len(s))
            dp2 = True  # Initialize dp2 to True for each iteration
            for j in range(len(p) - 1, -1, -1):
                match = i < len(s) and (s[i] == p[j] or p[j] == ".")
                res = False
                if (j + 1) < len(p) and p[j + 1] == "*":
                    res = dp2
                    if match:
                        res |= dp[j]
                elif match:
                    res = dp1
                
                dp1, dp2 = dp[j], dp1
                dp[j] = res
        
        return dp[0]