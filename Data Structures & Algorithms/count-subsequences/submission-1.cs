public class Solution {
    private int?[,] dp;

    public int NumDistinct(string s, string t) {
        int m = s.Length, n = t.Length;
        if (n > m) return 0;
        dp = new int?[m + 1, n + 1];
        return Dfs(s, t, 0, 0);
    }

    private int Dfs(string s, string t, int i, int j) {
        if (j == t.Length) return 1;
        if (i == s.Length) return 0;
        if (dp[i, j].HasValue) return dp[i, j].Value;

        int res = Dfs(s, t, i + 1, j);
        if (s[i] == t[j]) {
            res += Dfs(s, t, i + 1, j + 1);
        }
        dp[i, j] = res;
        return res;
    }
}