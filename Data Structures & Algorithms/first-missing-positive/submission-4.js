class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    firstMissingPositive(nums) {
        let missing = 1;
        while (true) {
            let flag = true;
            for (let num of nums) {
                if (missing === num) {
                    flag = false;
                    break;
                }
            }
            if (flag) return missing;
            missing++;
        }
    }
}