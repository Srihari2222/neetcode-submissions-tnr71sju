class Solution {
public:
    int numDistinct(string s, string t) {
        int m = s.size(), n = t.size();
        vector<int> dp(n + 1, 0);
        vector<int> nextDp(n + 1, 0);
        dp[n] = nextDp[n] = 1;

        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                nextDp[j] = dp[j];
                if (s[i] == t[j]) {
                    nextDp[j] += dp[j + 1];
                }
            }
            dp = nextDp;
        }

        return dp[0];
    }
};