class TrieNode {
    constructor() {
        this.children = {};
        this.isWord = false;
    }
}

class Trie {
    constructor() {
        this.root = new TrieNode();
    }

    /**
     * @param {string} word
     * @return {void}
     */
    insert(word) {
        let node = this.root;
        for (let char of word) {
            if (!node.children[char]) {
                node.children[char] = new TrieNode();
            }
            node = node.children[char];
        }
        node.isWord = true;
    }

    /**
     * @param {string} s
     * @param {number} i
     * @param {number} j
     * @return {boolean}
     */
    search(s, i, j) {
        let node = this.root;
        for (let idx = i; idx <= j; idx++) {
            if (!node.children[s[idx]]) {
                return false;
            }
            node = node.children[s[idx]];
        }
        return node.isWord;
    }
}

class Solution {
    /**
     * @param {string} s
     * @param {string[]} wordDict
     * @return {boolean}
     */
    wordBreak(s, wordDict) {
        const trie = new Trie();
        for (let word of wordDict) {
            trie.insert(word);
        }

        const dp = new Array(s.length + 1).fill(false);
        dp[s.length] = true;

        let maxLen = 0;
        for (let w of wordDict) {
            maxLen = Math.max(maxLen, w.length);
        }

        for (let i = s.length - 1; i >= 0; i--) {
            for (let j = i; j < Math.min(s.length, i + maxLen); j++) {
                if (trie.search(s, i, j)) {
                    dp[i] = dp[j + 1];
                    if (dp[i]) break;
                }
            }
        }

        return dp[0];
    }
}