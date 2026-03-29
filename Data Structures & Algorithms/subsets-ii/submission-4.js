class Solution {
    constructor() {
        this.res = [];
    }

    /**
     * @param {number[]} nums
     * @return {number[][]}
     */
    subsetsWithDup(nums) {
        nums.sort((a, b) => a - b);
        this.backtrack(0, [], nums);
        return this.res;
    }

    /**
     * @param {number} i
     * @param {number[]} subset
     * @param {number[]} nums
     * @return {void}
     */
    backtrack(i, subset, nums) {
        this.res.push([...subset]);
        for (let j = i; j < nums.length; j++) {
            if (j > i && nums[j] === nums[j - 1]) {
                continue;
            }
            subset.push(nums[j]);
            this.backtrack(j + 1, subset, nums);
            subset.pop();
        }
    }
}