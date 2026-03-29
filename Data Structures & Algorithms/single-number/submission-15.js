class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    singleNumber(nums) {
        nums.sort((a, b) => a - b);
        let i = 0;
        while (i < nums.length - 1) {
            if (nums[i] === nums[i + 1]) {
                i += 2;
            } else {
                return nums[i];
            }
        }
        return nums[i];
    }
}