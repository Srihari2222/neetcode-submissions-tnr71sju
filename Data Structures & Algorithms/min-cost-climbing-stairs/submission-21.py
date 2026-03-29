class Solution:
    memoization = {}
    def recur(self, i, curr):
        if i in self.memoization: return self.memoization[i]
        if i >= len(self.cost): return curr
        new = self.cost[i] + min(self.recur(i+1, curr), self.recur(i+2, curr))
        curr += new
        self.memoization[i] = new
        return curr
    def minCostClimbingStairs(self, cost: list[int]) -> int:
        self.cost = cost
        return min(self.recur(0, 0), self.recur(1, 0))