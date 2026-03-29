public class Solution {
    public void SetZeroes(int[][] matrix) {
        int ROWS = matrix.Length, COLS = matrix[0].Length;
        int[][] mark = new int[ROWS][];
        for (int r = 0; r < ROWS; r++) {
            mark[r] = (int[]) matrix[r].Clone();
        }

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (matrix[r][c] == 0) {
                    for (int col = 0; col < COLS; col++) {
                        mark[r][col] = 0;
                    }
                    for (int row = 0; row < ROWS; row++) {
                        mark[row][c] = 0;
                    }
                }
            }
        }

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                matrix[r][c] = mark[r][c];
            }
        }
    }
}