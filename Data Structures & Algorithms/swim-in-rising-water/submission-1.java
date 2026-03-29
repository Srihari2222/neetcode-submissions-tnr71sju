public class Solution {
    public int swimInWater(int[][] grid) {
        int n = grid.length;
        boolean[][] visit = new boolean[n][n];

        return dfs(grid, visit, 0, 0, 0);
    }

    private int dfs(int[][] grid, boolean[][] visit, int r, int c, int t) {
        int n = grid.length;
        if (r < 0 || c < 0 || r >= n || c >= n || visit[r][c]) {
            return 1000000;
        }
        if (r == n - 1 && c == n - 1) {
            return Math.max(t, grid[r][c]);
        }
        visit[r][c] = true;
        t = Math.max(t, grid[r][c]);
        int res = Math.min(Math.min(dfs(grid, visit, r + 1, c, t),
                                     dfs(grid, visit, r - 1, c, t)),
                           Math.min(dfs(grid, visit, r, c + 1, t),
                                    dfs(grid, visit, r, c - 1, t)));
        visit[r][c] = false;
        return res;
    }
}