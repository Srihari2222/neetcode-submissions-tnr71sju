class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    findDuplicate(nums) {
        let seen = new Array(nums.length).fill(0);
        for (let num of nums) {
            if (seen[num - 1]) {
                return num;
            }
            seen[num - 1] = 1;
        }
        return -1;
    }
}