public class Solution {
    private int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };
    private int INF = 2147483647;
    private bool[,] visit;
    private int ROWS, COLS;

    private int Dfs(int[][] grid, int r, int c) {
        if (r < 0 || c < 0 || r >= ROWS || 
            c >= COLS || grid[r][c] == -1 || visit[r, c]) {
            return INF;
        }
        if (grid[r][c] == 0) {
            return 0;
        }
        visit[r, c] = true;
        int res = INF;
        foreach (var dir in directions) {
            int cur = Dfs(grid, r + dir[0], c + dir[1]);
            if (cur != INF) {
                res = Math.Min(res, 1 + cur);
            }
        }
        visit[r, c] = false;
        return res;
    }

    public void islandsAndTreasure(int[][] grid) {
        ROWS = grid.Length;
        COLS = grid[0].Length;
        visit = new bool[ROWS, COLS];

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == INF) {
                    grid[r][c] = Dfs(grid, r, c);
                }
            }
        }
    }
}