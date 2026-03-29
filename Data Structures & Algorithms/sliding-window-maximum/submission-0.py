class Solution:
    def maxSlidingWindow(self, nums: List[int], k: int) -> List[int]:
        output = []

        for i in range(len(nums) - k + 1):
            curMax = nums[i]
            for j in range(i, i + k):
                curMax = max(curMax, nums[j])
            output.append(curMax)
        return output