class Solution:
    def findDuplicate(self, nums: List[int]) -> int:
        for num in nums :
            idx = abs(num)
            if nums[idx] < 0 :
                return abs(num)
            nums[idx] *= -1
        return -1