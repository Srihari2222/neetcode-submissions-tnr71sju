public class Solution {
    public bool IsMatch(string s, string p) {
        bool[,] dp = new bool[s.Length + 1, p.Length + 1];
        dp[s.Length, p.Length] = true;

        for (int i = s.Length; i >= 0; i--) {
            for (int j = p.Length - 1; j >= 0; j--) {
                bool match = i < s.Length && 
                             (s[i] == p[j] || p[j] == '.');

                if ((j + 1) < p.Length && p[j + 1] == '*') {
                    dp[i, j] = dp[i, j + 2];
                    if (match) {
                        dp[i, j] = dp[i + 1, j] || dp[i, j];
                    }
                } else if (match) {
                    dp[i, j] = dp[i + 1, j + 1];
                }
            }
        }

        return dp[0, 0];
    }
}