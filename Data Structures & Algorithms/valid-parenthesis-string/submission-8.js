class Solution {
    /**
     * @param {string} s
     * @return {boolean}
     */
    checkValidString(s) {
        function dfs(i, open) {
            if (open < 0) return false;
            if (i === s.length) return open === 0;

            if (s[i] === '(') {
                return dfs(i + 1, open + 1);
            } else if (s[i] === ')') {
                return dfs(i + 1, open - 1);
            } else {
                return dfs(i + 1, open) || 
                    dfs(i + 1, open + 1) || 
                    dfs(i + 1, open - 1);
            }
        }

        return dfs(0, 0);
    }
}