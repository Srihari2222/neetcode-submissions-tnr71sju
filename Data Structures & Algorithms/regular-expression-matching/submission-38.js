class Solution {
    /**
     * @param {string} s
     * @param {string} p
     * @return {boolean}
     */
    isMatch(s, p) {
        let m = s.length, n = p.length;

        const dfs = (i, j) => {
            if (j === n) {
                return i === m;
            }

            let match = i < m && (s[i] === p[j] || p[j] === '.');
            if (j + 1 < n && p[j + 1] === '*') {
                return dfs(i, j + 2) || 
                       (match && dfs(i + 1, j));
            }

            if (match) {
                return dfs(i + 1, j + 1);
            }

            return false;
        }

        return dfs(0, 0);
    }
}