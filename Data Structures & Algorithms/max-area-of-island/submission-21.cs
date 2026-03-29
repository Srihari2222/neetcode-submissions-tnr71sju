public class Solution {
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };
    
    public int MaxAreaOfIsland(int[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int area = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == 1) {
                    area = Math.Max(area, Dfs(grid, r, c));
                }
            }
        }

        return area;
    }

    private int Dfs(int[][] grid, int r, int c) {
        if (r < 0 || c < 0 || r >= grid.Length || 
            c >= grid[0].Length || grid[r][c] == 0) {
            return 0;
        }

        grid[r][c] = 0;
        int res = 1;
        foreach (var dir in directions) {
            res += Dfs(grid, r + dir[0], c + dir[1]);
        }
        return res;
    }
}