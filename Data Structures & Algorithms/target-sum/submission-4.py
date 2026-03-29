class Solution:
    def findTargetSumWays(self, nums, target):
        total_sum = sum(nums)
        if target > total_sum or target < -total_sum:
            return 0
        
        dp = [[0 for _ in range(2 * total_sum + 1)] for _ in range(len(nums) + 1)]
        dp[0][total_sum] = 1

        for i in range(len(nums)):
            for total in range(-total_sum, total_sum + 1):
                if dp[i][total + total_sum] != 0:
                    dp[i + 1][total + total_sum] += dp[i][total + nums[i] + total_sum]
                    dp[i + 1][total + total_sum] += dp[i][total - nums[i] + total_sum]
                    
        return dp[0][0]