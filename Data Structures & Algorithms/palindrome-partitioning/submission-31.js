class Solution {
    /**
     * @param {string} s
     * @return {string[][]}
     */
    partition(s) {
        const n = s.length;
        const dp = Array.from({ length: n }, () => Array(n).fill(false));
        for (let l = 1; l <= n; l++) {
            for (let i = 0; i <= n - l; i++) {
                dp[i][i + l - 1] = (s[i] === s[i + l - 1] && 
                                    (i + 1 > (i + l - 2) || 
                                    dp[i + 1][i + l - 2]));
            }
        }
        
        const dfs = (i) => {
            if (i >= s.length) {
                return [[]];
            }

            const ret = [];
            for (let j = i; j < s.length; j++) {
                if (dp[i][j]) {
                    const nxt = dfs(j + 1);
                    for (const part of nxt) {
                        const cur = [s.slice(i, j + 1), ...part];
                        ret.push(cur);
                    }
                }
            }
            return ret;
        };

        return dfs(0);
    }
}