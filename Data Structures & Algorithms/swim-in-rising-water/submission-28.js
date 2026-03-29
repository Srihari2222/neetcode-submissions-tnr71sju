class Solution {
    /**
     * @param {number[][]} grid
     * @return {number}
     */
    swimInWater(grid) {
        const n = grid.length;
        const visit = Array.from({ length: n }, () => 
                      Array(n).fill(false));
        
        const dfs = (r, c, t) => {
            if (r < 0 || c < 0 || r >= n || 
                c >= n || visit[r][c]) {
                return 1000000;
            }
            if (r === n - 1 && c === n - 1) {
                return Math.max(t, grid[r][c]);
            }
            visit[r][c] = true;
            t = Math.max(t, grid[r][c]);
            const res = Math.min(
                Math.min(dfs(r + 1, c, t),
                        dfs(r - 1, c, t)),
                Math.min(dfs(r, c + 1, t),
                        dfs(r, c - 1, t))
            );
            visit[r][c] = false;
            return res;
        }

        return dfs(0, 0, 0);
    }
}