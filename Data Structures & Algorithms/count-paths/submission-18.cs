public class Solution {
    public int UniquePaths(int m, int n) {
        return Dfs(0, 0, m, n);
    }

    int Dfs(int i, int j, int m, int n) {
        if (i == (m - 1) && j == (n - 1)) {
            return 1;
        }
        if (i >= m || j >= n) return 0;
        return Dfs(i, j + 1, m, n) + 
               Dfs(i + 1, j, m, n);
    }
}