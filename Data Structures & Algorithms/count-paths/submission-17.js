class Solution {
    /**
     * @param {number} m
     * @param {number} n
     * @return {number}
     */
    uniquePaths(m, n) {

        const dfs = (i, j) => {
            if (i == (m - 1) && j == (n - 1)) {
                return 1;
            }
            if (i >= m || j >= n) return 0;
            return dfs(i, j + 1) + dfs(i + 1, j);
        }

        return dfs(0, 0);
    }
}