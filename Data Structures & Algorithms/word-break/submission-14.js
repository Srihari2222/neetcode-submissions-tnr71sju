class Solution {
    /**
     * @param {string} s
     * @param {string[]} wordDict
     * @return {boolean}
     */
    wordBreak(s, wordDict) {
        this.wordSet = new Set(wordDict);
        this.memo = new Array(s.length).fill(null);
        return this.dfs(s, 0);
    }

    /**
     * @param {string} s
     * @param {number} i
     * @return {boolean}
     */
    dfs(s, i) {
        if (i === s.length) {
            return true;
        }
        if (this.memo[i] !== null) {
            return this.memo[i];
        }

        for (let j = i; j < s.length; j++) {
            if (this.wordSet.has(s.substring(i, j + 1))) {
                if (this.dfs(s, j + 1)) {
                    this.memo[i] = true;
                    return true;
                }
            }
        }
        this.memo[i] = false;
        return false;
    }
}