class Solution {
    public int minDistance(String word1, String word2) {
        int m = word1.length(), n = word2.length();
        if (m < n) {
            int temp = m;
            m = n;
            n = temp;
            String t = word1;
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
                if (word1.charAt(i) == word2.charAt(j)) {
                    nextDp[j] = dp[j + 1];
                } else {
                    nextDp[j] = 1 + Math.min(dp[j], 
                                Math.min(nextDp[j + 1], dp[j + 1]));
                }
            }
            System.arraycopy(nextDp, 0, dp, 0, n + 1);
        }
        
        return dp[0];
    }
}