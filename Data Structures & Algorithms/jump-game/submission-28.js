class Solution {
    /**
     * @param {number[]} nums
     * @return {boolean}
     */
    canJump(nums) {
        const memo = new Map();
        const dfs = (i) => {
            if (memo.has(i)) {
                return memo.get(i);
            }
            if (i == nums.length - 1) {
                return true;
            }
            if (nums[i] === 0) {
                return false;
            }
            const end = Math.min(nums.length - 1, i + nums[i]);
            for (let j = i + 1; j <= end; j++) {
                if (dfs(j)) {
                    memo.set(i, true);
                    return true;
                }
            }
            memo.set(i, false);
            return false;
        }

        return dfs(0);
    }
}