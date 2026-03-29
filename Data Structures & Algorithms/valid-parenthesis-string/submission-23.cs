public class Solution {
    public bool CheckValidString(string s) {
        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true;

        for (int i = n - 1; i >= 0; i--) {
            bool[] newDp = new bool[n + 1];
            for (int open = 0; open < n; open++) {
                if (s[i] == '*') {
                    newDp[open] = dp[open + 1] || 
                                  (open > 0 && dp[open - 1]) || dp[open];
                } else if (s[i] == '(') {
                    newDp[open] = dp[open + 1];
                } else if (open > 0) {
                    newDp[open] = dp[open - 1];
                }
            }
            dp = newDp;
        }
        return dp[0];
    }
}