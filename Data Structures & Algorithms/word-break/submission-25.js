class Solution {
    /**
     * @param {string} s
     * @param {string[]} wordDict
     * @return {boolean}
     */
    wordBreak(s, wordDict) {
        const wordSet = new Set(wordDict);
        const dfs = (i) => {
            if (i === s.length) {
                return true;
            }

            for (let j = i; j < s.length; j++) {
                if (wordSet.has(s.substring(i, j + 1))) {
                    if (dfs(j + 1)) {
                        return true;
                    }
                }
            }
            return false;
        }

        return dfs(0);
    }
}