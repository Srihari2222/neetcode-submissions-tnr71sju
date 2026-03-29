public class Solution {
    public int MinDistance(string word1, string word2) {
        int[,] dp = new int[word1.Length + 1, word2.Length + 1];

        for (int j = 0; j <= word2.Length; j++) {
            dp[word1.Length, j] = word2.Length - j;
        }
        for (int i = 0; i <= word1.Length; i++) {
            dp[i, word2.Length] = word1.Length - i;
        }

        for (int i = word1.Length - 1; i >= 0; i--) {
            for (int j = word2.Length - 1; j >= 0; j--) {
                if (word1[i] == word2[j]) {
                    dp[i, j] = dp[i + 1, j + 1];
                } else {
                    dp[i, j] = 1 + Math.Min(dp[i + 1, j], 
                                   Math.Min(dp[i, j + 1], dp[i + 1, j + 1]));
                }
            }
        }
        return dp[0, 0];
    }
}