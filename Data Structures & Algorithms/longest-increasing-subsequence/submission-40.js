class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    lengthOfLIS(nums) {
        const n = nums.length;
        const memo = new Array(n).fill(-1);

        const dfs = (i) => {
            if (memo[i] !== -1) {
                return memo[i];
            }

            let LIS = 1;
            for (let j = i + 1; j < n; j++) {
                if (nums[i] < nums[j]) {
                    LIS = Math.max(LIS, 1 + dfs(j));
                }
            }

            memo[i] = LIS;
            return LIS;
        };

        return Math.max(...nums.map((_, i) => dfs(i)));
    }
}
