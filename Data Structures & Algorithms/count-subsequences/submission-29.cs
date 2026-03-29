public class Solution {
    public int NumDistinct(string s, string t) {
        int m = s.Length, n = t.Length;
        int[] dp = new int[n + 1];
        int[] nextDp = new int[n + 1];

        dp[n] = nextDp[n] = 1;
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                nextDp[j] = dp[j];
                if (s[i] == t[j]) {
                    nextDp[j] += dp[j + 1];
                }
            }
            dp = (int[])nextDp.Clone();
        }

        return dp[0];
    }
}