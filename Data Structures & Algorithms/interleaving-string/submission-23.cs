public class Solution {
    private bool?[,] dp;

    public bool IsInterleave(string s1, string s2, string s3) {
        int m = s1.Length, n = s2.Length;
        if (m + n != s3.Length) return false;
        dp = new bool?[m + 1, n + 1];
        return dfs(0, 0, 0, s1, s2, s3);
    }
    
    private bool dfs(int i, int j, int k, string s1, string s2, string s3) {
        if (k == s3.Length) {
            return (i == s1.Length) && (j == s2.Length);
        }
        if (dp[i, j].HasValue) {
            return dp[i, j].Value;
        }

        bool res = false;
        if (i < s1.Length && s1[i] == s3[k]) {
            res = dfs(i + 1, j, k + 1, s1, s2, s3);
        }
        if (!res && j < s2.Length && s2[j] == s3[k]) {
            res = dfs(i, j + 1, k + 1, s1, s2, s3);
        }

        dp[i, j] = res;
        return res;
    }
}