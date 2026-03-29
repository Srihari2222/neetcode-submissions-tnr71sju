class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    majorityElement(nums) {
        let n = nums.length;
        for (let num of nums) {
            let count = nums.reduce((acc, val) => acc + (val === num ? 1 : 0), 0);
            if (count > Math.floor(n / 2)) {
                return num;
            }
        }
        return -1;
    }
}