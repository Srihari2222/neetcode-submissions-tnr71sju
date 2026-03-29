class Solution:
    def findTargetSumWays(self, nums: List[int], target: int) -> int:
        
        def dfs(i, total):
            if i ==len(nums):
                return  total == target
            
            return (dfs(i + 1, total + nums[i]) + 
                    dfs(i + 1, total - nums[i]))
                
        return dfs(0, 0)