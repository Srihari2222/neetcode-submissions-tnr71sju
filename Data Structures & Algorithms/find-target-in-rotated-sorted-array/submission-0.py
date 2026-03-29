class Solution:
    def search(self, nums: List[int], target: int) -> int:
        l, r = 0, len(nums) - 1

        while l < r:
            m = (l + r) // 2
            if nums[m] > nums[r]:
                l = m + 1
            else:
                r = m

        rot = l
        l, r = 0, len(nums) - 1

        while l <= r:
            m = (l + r) // 2
            realmid = (m + rot) % len(nums)
            if nums[realmid] == target:
                return realmid
            if nums[realmid] < target:
                l = m + 1
            else:
                r = m - 1
        return -1