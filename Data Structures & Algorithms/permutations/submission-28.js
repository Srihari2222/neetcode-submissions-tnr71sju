class Solution {
    /**
     * @param {number[]} nums
     * @return {number[][]}
     */
    permute(nums) {
        let res = [];
        this.backtrack([], nums, 0, res);
        return res;
    }

    /**
     * @param {number[]} perm
     * @param {number[]} nums
     * @param {number} mask
     * @param {number[][]} res
     * @return {void}
     */
    backtrack(perm, nums, mask, res) {
        if (perm.length === nums.length) {
            res.push([...perm]);
            return;
        }
        for (let i = 0; i < nums.length; i++) {
            if (!(mask & (1 << i))) {
                perm.push(nums[i]);
                this.backtrack(perm, nums, mask | (1 << i), res);
                perm.pop();
            }
        }
    }
}