public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        List<int> res = new List<int>();

        // append all the elements in the given direction
        Dfs(m, n, 0, -1, 0, 1, matrix, res);
        return res;
    }

    private void Dfs(int row, int col, int r, int c, int dr, 
                     int dc, int[][] matrix, List<int> res) {
        if (row == 0 || col == 0) return;
        
        for (int i = 0; i < col; i++) {
            r += dr;
            c += dc;
            res.Add(matrix[r][c]);
        }

        // sub-problem
        Dfs(col, row - 1, r, c, dc, -dr, matrix, res);
    }
}