class Solution {
    /**
     * @param {number[]} nums
     * @return {number[][]}
     */
    permute(nums) {
        if (nums.length === 0) {
            return [[]];
        }

        let perms = this.permute(nums.slice(1));
        let res = [];
        for (let p of perms) {
            for (let i = 0; i <= p.length; i++) {
                let p_copy = p.slice();
                p_copy.splice(i, 0, nums[0]);
                res.push(p_copy);
            }
        }
        return res;
    }
}