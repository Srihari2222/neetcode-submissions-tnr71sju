public class Solution {
    int[,] memo;
    public int UniquePaths(int m, int n) {
        memo = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                memo[i, j] = -1;

        return Dfs(0, 0, m, n);
    }

    int Dfs(int i, int j, int m, int n) {
        if (i == (m - 1) && j == (n - 1)) {
            return 1;
        }
        if (i >= m || j >= n) return 0;
        if (memo[i, j] != -1) {
            return memo[i, j];
        }
        return memo[i, j] = Dfs(i, j + 1, m, n) + 
                            Dfs(i + 1, j, m, n);
    }
}