class Solution:
    def search(self, nums: List[int], target: int) -> int:
        l, r = 0, len(nums) - 1
        result = -1

        while l <= r:
            if nums[l] == target:
                result = l
            elif nums[r] == target:
                result = r

            m = l + ((r - l) // 2)
            if nums[m] > target:
                if nums[r] > nums[m]:
                    r = m - 1
                else:
                    l = m + 1
            elif nums[m] < target:
                if nums[l] < nums[m]:
                    l = m + 1
                else:
                    r = m - 1
            else:
                result = m
                break

        return result