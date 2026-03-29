public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        for (int r = 0; r < matrix.Length; r++) {
            for (int c = 0; c < matrix[r].Length; c++) {
                if (matrix[r][c] == target) {
                    return true;
                }
            }
        }
        return false;
    }
}