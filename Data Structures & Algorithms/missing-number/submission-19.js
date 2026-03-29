class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    missingNumber(nums) {
        let res = nums.length;

        for (let i = 0; i < nums.length; i++) {
            res += i - nums[i];
        }
        return res;
    }
}