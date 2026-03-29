class Solution {
    /**
     * @param {string} s
     * @return {boolean}
     */
    checkValidString(s) {
        const n = s.length;
        const dp = Array.from({ length: n + 1 }, () => 
                   Array(n + 1).fill(false));
        dp[n][0] = true;

        for (let i = n - 1; i >= 0; i--) {
            for (let open = 0; open < n; open++) {
                let res = false;
                if (s[i] === '*') {
                    res ||= dp[i + 1][open + 1];
                    if (open > 0) res ||= dp[i + 1][open - 1];
                    res ||= dp[i + 1][open];
                } else {
                    if (s[i] === '(') {
                        res ||= dp[i + 1][open + 1];
                    } else if (open > 0) {
                        res ||= dp[i + 1][open - 1];
                    }
                }
                dp[i][open] = res;
            }
        }
        return dp[0][0];
    }
}