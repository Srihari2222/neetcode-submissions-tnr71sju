class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    jump(nums) {
        const dfs = (i) => {
            if (i === nums.length - 1) {
                return 0;
            }
            if (nums[i] === 0) return 1000000;
            let res = 1000000;
            const end = Math.min(nums.length - 1, i + nums[i]);
            for (let j = i + 1; j <= end; j++) {
                res = Math.min(res, 1 + dfs(j));
            }
            return res;
        }

        return dfs(0);
    }
}