public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++) {
            visit[i] = new bool[n];
        }
        return Dfs(grid, visit, 0, 0, 0);
    }

    private int Dfs(int[][] grid, bool[][] visit, 
                    int r, int c, int t) {
        int n = grid.Length;
        if (r < 0 || c < 0 || r >= n || 
            c >= n || visit[r][c]) {
            return 1000000;
        }
        if (r == n - 1 && c == n - 1) {
            return Math.Max(t, grid[r][c]);
        }
        visit[r][c] = true;
        t = Math.Max(t, grid[r][c]);
        int res = Math.Min(Math.Min(Dfs(grid, visit, r + 1, c, t),
                                     Dfs(grid, visit, r - 1, c, t)),
                           Math.Min(Dfs(grid, visit, r, c + 1, t),
                                    Dfs(grid, visit, r, c - 1, t)));
        visit[r][c] = false;
        return res;
    }
}