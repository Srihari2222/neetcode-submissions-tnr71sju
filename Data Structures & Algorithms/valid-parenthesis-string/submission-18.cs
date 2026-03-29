public class Solution {
    public bool CheckValidString(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n + 1, n + 1];
        dp[n, 0] = true;

        for (int i = n - 1; i >= 0; i--) {
            for (int open = 0; open < n; open++) {
                bool res = false;
                if (s[i] == '*') {
                    res |= dp[i + 1, open + 1];
                    if (open > 0) res |= dp[i + 1, open - 1];
                    res |= dp[i + 1, open];
                } else {
                    if (s[i] == '(') {
                        res |= dp[i + 1, open + 1];
                    } else if (open > 0) {
                        res |= dp[i + 1, open - 1];
                    }
                }
                dp[i, open] = res;
            }
        }
        return dp[0, 0];
    }
}