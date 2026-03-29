class Solution {
    /**
     * @param {string} s1
     * @param {string} s2
     * @param {string} s3
     * @return {boolean}
     */
    isInterleave(s1, s2, s3) {
        let m = s1.length, n = s2.length;
        if (m + n !== s3.length) return false;
        if (n < m) {
            [s1, s2] = [s2, s1];
            [m, n] = [n, m];
        }

        let dp = Array(n + 1).fill(false);
        dp[n] = true;
        for (let i = m; i >= 0; i--) {
            let nextDp = true;
            for (let j = n - 1; j >= 0; j--) {
                let res = false;
                if (i < m && s1[i] === s3[i + j] && dp[j]) {
                    res = true;
                }
                if (j < n && s2[j] === s3[i + j] && nextDp) {
                    res = true;
                }
                dp[j] = res;
                nextDp = dp[j];
            }
        }
        return dp[0];
    }
}