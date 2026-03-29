class Solution:
    def majorityElement(self, nums: List[int]) -> List[int]:
        res = set()
        for num in nums:
            count = sum(1 for i in nums if i == num)
            if count > len(nums) // 3:
                res.add(num)
        return list(res)