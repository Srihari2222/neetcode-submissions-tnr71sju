class Solution {
    /**
     * @param {string} s
     * @param {string[]} wordDict
     * @return {boolean}
     */
    wordBreak(s, wordDict) {
        return this.dfs(s, wordDict, 0);
    }

    /**
     * @param {string} s
     * @param {string[]} wordDict
     * @param {number} i
     * @return {boolean}
     */
    dfs(s, wordDict, i) {
        if (i === s.length) {
            return true;
        }

        for (let w of wordDict) {
            if (i + w.length <= s.length && 
                s.substring(i, i + w.length) === w) {
                if (this.dfs(s, wordDict, i + w.length)) {
                    return true;
                }
            }
        }
        return false;
    }
}