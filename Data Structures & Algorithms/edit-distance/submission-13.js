class Solution {
    /**
     * @param {string} word1
     * @param {string} word2
     * @return {number}
     */
    minDistance(word1, word2) {
        const m = word1.length, n = word2.length;

        const dfs = (i, j) => {
            if (i === m) return n - j;
            if (j === n) return m - i;
            if (word1[i] === word2[j]) {
                return dfs(i + 1, j + 1);
            }
            let res = Math.min(dfs(i + 1, j), dfs(i, j + 1));
            res = Math.min(res, dfs(i + 1, j + 1));
            return res + 1;
        };

        return dfs(0, 0);
    }
}