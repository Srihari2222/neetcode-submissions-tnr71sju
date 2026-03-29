class Solution {
    /**
     * @param {string[]} words
     * @returns {string}
     */
    foreignDictionary(words) {
        let adj = {};
        words.forEach(word => {
            for (let char of word) {
                adj[char] = new Set();
            }
        });

        for (let i = 0; i < words.length - 1; i++) {
            let w1 = words[i],
                w2 = words[i + 1];
            let minLen = Math.min(w1.length, w2.length);
            if (
                w1.length > w2.length &&
                w1.substring(0, minLen) === w2.substring(0, minLen)
            ) {
                return '';
            }
            for (let j = 0; j < minLen; j++) {
                if (w1[j] !== w2[j]) {
                    adj[w1[j]].add(w2[j]);
                    break;
                }
            }
        }

        let state = {}; // 0 = unvisited, 1 = visiting, 2 = visited
        let res = [];

        /**
         * @param {string} char
         * @returns {boolean}
         */
        function dfs(char) {
            if (state[char] === 1) {
                // Node is being visited, found a cycle
                return true;
            }
            if (state[char] === 2) {
                // Node has already been visited, no need to visit again
                return false;
            }

            state[char] = 1; // Mark as visiting
            for (let neighChar of adj[char]) {
                if (dfs(neighChar)) {
                    return true;
                }
            }
            state[char] = 2; // Mark as visited
            res.push(char);
            return false;
        }

        for (let char in adj) {
            if (!state[char] && dfs(char)) {
                return '';
            }
        }

        res.reverse();
        return res.join('');
    }
}