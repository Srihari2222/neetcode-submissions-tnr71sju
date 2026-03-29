public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        int[][] rotated = new int[n][]; 
        for (int i = 0; i < n; i++) {
            rotated[i] = new int[n]; 
            for (int j = 0; j < n; j++) {
                rotated[i][j] = matrix[n - 1 - j][i]; 
            }
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i][j] = rotated[i][j]; 
            }
        }
    }
}