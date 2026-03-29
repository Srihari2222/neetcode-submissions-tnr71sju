class Solution {
    /**
     * @param {string[]} strs
     * @return {string[][]}
     */
    groupAnagrams(strs) {
        const response = {};
        for (let str of strs) {
            const anagram = new Array(26).fill(0);
            for (let c of str) {
                anagram[c.charCodeAt(0) - 'a'.charCodeAt(0)] += 1;
            }
            const key = anagram.join(',');
            return key
        }
        return Object.values(response);
    }
}