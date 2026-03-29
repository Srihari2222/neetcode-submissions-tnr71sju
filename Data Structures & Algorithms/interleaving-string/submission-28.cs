public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int m = s1.Length, n = s2.Length;
        if (m + n != s3.Length) {
            return false;
        }

        bool[,] dp = new bool[m + 1, n + 1];
        dp[m, n] = true;

        for (int i = m; i >= 0; i--) {
            for (int j = n; j >= 0; j--) {
                if (i < m && s1[i] == s3[i + j] && dp[i + 1, j]) {
                    dp[i, j] = true;
                }
                if (j < n && s2[j] == s3[i + j] && dp[i, j + 1]) {
                    dp[i, j] = true;
                }
            }
        }
        return dp[0, 0];
    }
}