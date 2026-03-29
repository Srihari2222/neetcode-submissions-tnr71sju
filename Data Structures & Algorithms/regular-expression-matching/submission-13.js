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
            let nextDp = new Array(p.length + 1).fill(false);
            nextDp[p.length] = i === s.length;

            for (let j = p.length - 1; j >= 0; j--) {
                const match = i < s.length && 
                              (s[i] === p[j] || p[j] === ".");

                if (j + 1 < p.length && p[j + 1] === "*") {
                    nextDp[j] = nextDp[j + 2];
                    if (match) {
                        nextDp[j] = nextDp[j] || dp[j];
                    }
                } else if (match) {
                    nextDp[j] = dp[j + 1];
                }
            }

            dp = nextDp;
        }

        return dp[0];
    }
}