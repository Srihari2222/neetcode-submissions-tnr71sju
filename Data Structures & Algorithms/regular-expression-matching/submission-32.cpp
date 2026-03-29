class Solution {
public:
    bool isMatch(string s, string p) {
        vector<bool> dp(p.length() + 1, false);
        dp[p.length()] = true;

        for (int i = s.length(); i >= 0; i--) {
            bool dp1 = dp[p.length()];
            dp[p.length()] = (i == s.length());
            bool dp2 = false;

            for (int j = p.length() - 1; j >= 0; j--) {
                bool match = i < s.length() && 
                             (s[i] == p[j] || p[j] == '.');
                bool res = false;
                if (j + 1 < p.length() && p[j + 1] == '*') {
                    res = dp[j + 2];
                    if (match) {
                        res = res || dp[j];
                    }
                } else if (match) {
                    res = dp1;
                }
                swap(dp1, dp2);
                dp1 = dp[j];
                dp[j] = res;
            }
        }

        return dp[0];
    }
};