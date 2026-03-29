class Solution {
    /**
     * @param {number} n
     * @return {number}
     */
    climbStairs(n) {

        const dfs = (i) => {
            if (i >= n) return i == n;
            return dfs(i + 1) + dfs(i + 2);
        }
        return dfs(0);
    }
}