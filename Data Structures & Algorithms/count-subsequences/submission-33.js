class Solution {
    /**
     * @param {string} s
     * @param {string} t
     * @return {number}
     */
    numDistinct(s, t) {
        let m = s.length, n = t.length;
        let dp = new Array(n + 1).fill(0);

        dp[n] = 1;
        for (let i = m - 1; i >= 0; i--) {
            let prev = 1;
            for (let j = n - 1; j >= 0; j--) {
                let res = dp[j];
                if (s[i] === t[j]) {
                    res += prev;
                }

                prev = dp[j];
                dp[j] = res;
            }
        }

        return dp[0];
    }
}