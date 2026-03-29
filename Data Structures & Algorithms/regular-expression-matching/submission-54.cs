public class Solution {
    public bool IsMatch(string s, string p) {
        bool[] dp = new bool[p.Length + 1];
        dp[p.Length] = true;

        for (int i = s.Length; i >= 0; i--) {
            bool[] nextDp = new bool[p.Length + 1];
            nextDp[p.Length] = (i == s.Length);

            for (int j = p.Length - 1; j >= 0; j--) {
                bool match = i < s.Length && (s[i] == p[j] || p[j] == '.');

                if (j + 1 < p.Length && p[j + 1] == '*') {
                    nextDp[j] = nextDp[j + 2];
                    if (match) {
                        nextDp[j] |= dp[j];
                    }
                } else if (match) {
                    nextDp[j] = dp[j + 1];
                }
            }

            dp = nextDp;
        }

        return dp[0];
    }
}