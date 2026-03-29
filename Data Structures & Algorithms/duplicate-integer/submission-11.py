class Solution:
    def hasDuplicate(self, nums: List[int]) -> bool:
        answer = None
        for i in nums:
            if nums.count(i) == 1:
                answer = False
            else:
                answer = True
                break

        return answer