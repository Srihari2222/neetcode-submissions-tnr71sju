class Solution {
    /**
     * @param {string} s
     * @param {string} p
     * @return {boolean}
     */
    isMatch(s, p) {
        let dp = new Array(p.length + 1).fill(false);
        dp[p.length] = true;

        for (let i = s.length; i >= 0; i--) {
            let dp1 = dp[p.length];
            dp[p.length] = (i == s.length);

            for (let j = p.length - 1; j >= 0; j--) {
                const match = i < s.length && 
                              (s[i] === p[j] || p[j] === ".");
                let res = false;
                if (j + 1 < p.length && p[j + 1] === "*") {
                    res = dp[j + 2];
                    if (match) {
                        res = res || dp[j];
                    }
                } else if (match) {
                    res = dp1;
                }
                dp1 = dp[j];
                dp[j] = res;
            }
        }

        return dp[0];
    }
}