class Solution {
    constructor() {
        this.memo = {};
    }

    /**
     * @param {string} s
     * @param {string[]} wordDict
     * @return {boolean}
     */
    wordBreak(s, wordDict) {
        this.memo = { [s.length]: true };
        return this.dfs(s, wordDict, 0);
    }

    /**
     * @param {string} s
     * @param {string[]} wordDict
     * @param {number} i
     * @return {boolean}
     */
    dfs(s, wordDict, i) {
        if (i in this.memo) {
            return this.memo[i];
        }

        for (let w of wordDict) {
            if (i + w.length <= s.length && 
                s.substring(i, i + w.length) === w) {
                if (this.dfs(s, wordDict, i + w.length)) {
                    this.memo[i] = true;
                    return true;
                }
            }
        }
        this.memo[i] = false;
        return false;
    }
}