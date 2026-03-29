class Solution {
    /**
     * @param {string} s
     * @return {number}
     */
    numDecodings(s) {
        let dp2 = 0, dp = 0;
        let dp1 = 1;
        for (let i = s.length - 1; i >= 0; i--) {
            if (s.charAt(i) === '0') {
                dp = 0;
            } else {
                dp = dp1;
                if (i + 1 < s.length && (s.charAt(i) === '1' ||
                   (s.charAt(i) === '2' && s.charAt(i + 1) < '7'))) {
                   dp += dp2;
                }
            }
            dp2 = dp1;
            dp1 = dp;
            dp = 0;
        }
        return dp1;
    }
}