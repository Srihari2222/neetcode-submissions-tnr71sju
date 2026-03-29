public class Solution {
    private static int[][] directions = new int[][] {
        new int[] {-1, 0}, new int[] {1, 0}, 
        new int[] {0, -1}, new int[] {0, 1}
    };

    private int Dfs(int[][] matrix, int r, int c, int prevVal) {
        int ROWS = matrix.Length, COLS = matrix[0].Length;
        if (r < 0 || r >= ROWS || c < 0 || 
            c >= COLS || matrix[r][c] <= prevVal) {
            return 0;
        }

        int res = 1;
        foreach (var dir in directions) {
            res = Math.Max(res, 1 + Dfs(matrix, r + dir[0], 
                                    c + dir[1], matrix[r][c]));
        }
        return res;
    }

    public int LongestIncreasingPath(int[][] matrix) {
        int ROWS = matrix.Length, COLS = matrix[0].Length;
        int LIP = 0;
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                LIP = Math.Max(LIP, Dfs(matrix, r, c, int.MinValue));
            }
        }
        return LIP;
    }
}