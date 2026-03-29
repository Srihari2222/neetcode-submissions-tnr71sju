class Solution {
    /**
     * @param {string} s
     * @return {boolean}
     */
    checkValidString(s) {
        const n = s.length;
        let dp = Array(n + 1).fill(false);
        dp[0] = true;

        for (let i = n - 1; i >= 0; i--) {
            const newDp = Array(n + 1).fill(false);
            for (let open = 0; open < n; open++) {
                if (s[i] === '*') {
                    newDp[open] = dp[open + 1] || 
                                  (open > 0 && dp[open - 1]) || dp[open];
                } else if (s[i] === '(') {
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