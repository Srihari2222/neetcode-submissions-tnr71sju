class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        res = 0
        minBuy = [prices[0]] * len(prices)
        for i in range(1, len(prices)):
            minBuy[i] = min(minBuy[i - 1], prices[i - 1])
        
        for i in range(1, len(prices)):
            res = max(res, prices[i] - minBuy[i])
        return res