class Solution {
    /**
     * @param {number[]} cost
     * @return {number}
     */
    minCostClimbingStairs(cost) {
        const memo = new Int32Array(cost.length).fill(-1);
        const dfs = (i) => {
            if (i >= cost.length) {
                return 0;
            }
            if (memo[i] !== -1) {
                return memo[i];
            }
            memo[i] = cost[i] + Math.min(dfs(i + 1),
                                         dfs(i + 2));
            return memo[i];
        }
        return Math.min(dfs(0), dfs(1));
    }
}