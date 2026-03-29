class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    singleNumber(nums) {
        for (let i = 0; i < nums.length; i++) {
            let flag = true;
            for (let j = 0; j < nums.length; j++) {
                if (i !== j && nums[i] === nums[j]) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                return nums[i];
            }
        }
        return -1;
    }
}