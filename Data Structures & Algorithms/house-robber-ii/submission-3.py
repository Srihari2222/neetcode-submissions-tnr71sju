class Solution:
    def rob(self, nums: List[int]) -> int:
        if len(nums) == 1:
            return nums[0]
        memo = [-1] * len(nums)

        def dfs(i, nums):
            if i >= len(nums):
                return 0
            if memo[i] != -1:
                return memo[i]

            memo[i] = max(dfs(i + 1, nums), 
                          nums[i] + dfs(i + 2, nums))
            return memo[i]

        res = dfs(0, nums[1:])
        memo = [-1] * len(nums)
        res = max(res, dfs(1, nums[:-1]))
        return res