class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        if not prices:
            return 0

        max_index = prices.index(max(prices))
        min_index = prices.index(min(prices))

        if min_index < max_index:
            return max(0, prices[max_index] - prices[min_index])

        min_best = max(prices[min_index:len(prices)]) - prices[min_index]
        max_best = prices[max_index] - min(prices[0:max_index+1])

        return max(0, min_best, max_best)