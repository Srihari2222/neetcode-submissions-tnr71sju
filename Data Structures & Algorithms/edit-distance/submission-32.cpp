class Solution {
public:
    int minDistance(string word1, string word2) {
        int m = word1.size(), n = word2.size();
        if (m < n) {
            swap(m, n);
            swap(word1, word2);
        }

        vector<int> dp(n + 1);
        for (int i = 0; i <= n; i++) dp[i] = n - i;

        for (int i = m - 1; i >= 0; i--) {
            int nextDp = dp[n];
            dp[n] = m - i;
            for (int j = n - 1; j >= 0; j--) {
                int temp = dp[j];
                if (word1[i] == word2[j]) {
                    dp[j] = nextDp;
                } else {
                    dp[j] = 1 + min({dp[j], dp[j + 1], nextDp});
                }
                nextDp = temp;
            }
        }
        return dp[0];
    }
};