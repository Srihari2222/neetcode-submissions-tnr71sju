class Solution {
    /**
     * @param {number[]} nums
     * @param {number} k
     * @return {number}
     */
    findKthLargest(nums, k) {
        nums.sort();
        console.log(nums)
        return nums[nums.length - k];
    }
}
