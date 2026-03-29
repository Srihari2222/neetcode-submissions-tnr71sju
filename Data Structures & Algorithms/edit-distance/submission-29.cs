public class Solution {
    public int MinDistance(string word1, string word2) {
        int m = word1.Length, n = word2.Length;
        if (m < n) {
            var temp = m;
            m = n;
            n = temp;
            var t = word1;
            word1 = word2;
            word2 = t;
        }

        int[] dp = new int[n + 1];
        int[] nextDp = new int[n + 1];

        for (int j = 0; j <= n; j++) {
            dp[j] = n - j;
        }

        for (int i = m - 1; i >= 0; i--) {
            nextDp[n] = m - i;
            for (int j = n - 1; j >= 0; j--) {
                if (word1[i] == word2[j]) {
                    nextDp[j] = dp[j + 1];
                } else {
                    nextDp[j] = 1 + Math.Min(dp[j], 
                                Math.Min(nextDp[j + 1], dp[j + 1]));
                }
            }
            Array.Copy(nextDp, dp, n + 1);
        }

        return dp[0];
    }
}