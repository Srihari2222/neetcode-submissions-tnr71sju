class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    missingNumber(nums) {
        let n = nums.length;
        nums.sort((a, b) => a - b);
        for (let i = 0; i < n; i++) {
            if (nums[i] !== i) {
                return i;
            }
        }
        return n;
    }
}