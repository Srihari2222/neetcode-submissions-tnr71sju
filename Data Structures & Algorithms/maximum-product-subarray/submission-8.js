class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    maxProduct(nums) {
        let res = nums[0];

        for (let i = 0; i < nums.length; i++) {
            let cur = nums[i];
            res = Math.max(res, cur);
            for (let j = i + 1; j < nums.length; j++) {
                cur *= nums[j];
                res = Math.max(res, cur);
            }
        }
        
        return res;
    }
}