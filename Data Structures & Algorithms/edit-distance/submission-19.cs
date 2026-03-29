public class Solution {
    private int?[,] dp; 
    public int MinDistance(string word1, string word2) {
        int m = word1.Length, n = word2.Length;
        dp = new int?[m + 1, n + 1]; 
        return Dfs(0, 0, word1, word2, m, n);
    }

    private int Dfs(int i, int j, string word1, string word2, int m, int n) {
        if (i == m) return n - j; 
        if (j == n) return m - i; 

        if (dp[i, j].HasValue) { 
            return dp[i, j].Value;
        }

        if (word1[i] == word2[j]) {
            dp[i, j] = Dfs(i + 1, j + 1, word1, word2, m, n); 
        } else {
            int res = Math.Min(Dfs(i + 1, j, word1, word2, m, n), 
                               Dfs(i, j + 1, word1, word2, m, n));
            res = Math.Min(res, Dfs(i + 1, j + 1, word1, word2, m, n)); 
            dp[i, j] = res + 1; 
        }

        return dp[i, j].Value; 
    }
}