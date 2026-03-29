class Solution {
    /**
     * @param {string} s
     * @param {string} t
     * @return {number}
     */
    numDistinct(s, t) {
        if (t.length > s.length) {
            return 0;
        }
        
        const dfs = (i, j) => {
            if (j === t.length) {
                return 1;
            }
            if (i === s.length) {
                return 0;
            }

            let res = dfs(i + 1, j);
            if (s[i] === t[j]) {
                res += dfs(i + 1, j + 1);
            }
            return res;
        }

        return dfs(0, 0);
    }
}