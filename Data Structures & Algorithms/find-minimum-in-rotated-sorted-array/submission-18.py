class Solution:
    def findMin(self, nums: List[int]) -> int:
        l = 0
        r = len(nums) - 1
        minNum = float('inf')
        while l <= r:
            mid = (l + r) // 2
            minNum = min(minNum, nums[mid])
            if mid - 1 >= 0:
                minNum = min(minNum, nums[mid - 1])
            if nums[r] < nums[l]:
                l = mid + 1
            else:
                r = mid - 1

        return minNum