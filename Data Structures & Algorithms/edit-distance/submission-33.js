class Solution {
    /**
     * @param {string} word1
     * @param {string} word2
     * @return {number}
     */
    minDistance(word1, word2) {
        let m = word1.length, n = word2.length;
        if (m < n) {
            [m, n] = [n, m];
            [word1, word2] = [word2, word1];
        }

        let dp = new Array(n + 1).fill(0);
        for (let j = 0; j <= n; j++) {
            dp[j] = n - j;
        }

        for (let i = m - 1; i >= 0; i--) {
            let nextDp = dp[n];
            dp[n] = m - i;
            for (let j = n - 1; j >= 0; j--) {
                let temp = dp[j];
                if (word1[i] === word2[j]) {
                    dp[j] = nextDp;
                } else {
                    dp[j] = 1 + Math.min(dp[j], dp[j + 1], nextDp);
                }
                nextDp = temp;
            }
        }

        return dp[0];
    }
}