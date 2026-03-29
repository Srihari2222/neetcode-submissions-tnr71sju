class Solution:
    def binary_search(self, left: int, right: int, nums: List[int], target: int) -> int:
        if left > right:
            return -1

        middle = left + (right-left // 2)
        print(f"middle: {middle}, left: {left}, right: {right}")
        if nums[middle] == target:
            print(f"Its a match! nums[middle] == {target}")
            # match ! return the index of matching value
            return middle
        elif nums[middle] < target:
            print("smaller, rec for l={middle+1}, right={right}")
            # smaller, we go right to find bigger value by doing: left = middle+1 
            return self.binary_search(left=middle+1,right=right,nums=nums,target=target)
        else:
            print("bigger, rec for l={left}, right={middle-1}")
            # bigger, we go left to find smaller value by doing: right = middle -1
            return self.binary_search(left=left,right=middle-1,nums=nums,target=target)

    def search(self, nums: List[int], target: int) -> int:
        # init the recursion func with initial values
        return self.binary_search(left=0,right=(len(nums)-1),nums=nums,target=target)