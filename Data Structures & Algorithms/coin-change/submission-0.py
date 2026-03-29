class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        
        def dfs(target):
            if target == 0:
                return 0
            
            res = 1e9
            for coin in coins:
                if target - coin >= 0:
                    res = min(res, 1 + dfs(target - coin))
            return res
        minCoins = dfs(amount)
        return -1 if minCoins >= 1e9 else minCoins