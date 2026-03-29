class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    missingNumber(nums) {
        let n = nums.length;
        let xorr = n;  
        for (let i = 0; i < n; i++) {
            xorr ^= i ^ nums[i];
        }
        return xorr;
    }
}