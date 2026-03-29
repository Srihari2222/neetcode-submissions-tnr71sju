class Solution {
    /**
     * @param {string} s
     * @return {number}
     */
    lengthOfLongestSubstring(s) {
        let res = 0;
        for (let i = 0; i < s.length; i++) {
            let charSet = new Set();
            for (let j = i; j < s.length; j++) {
                if (charSet.has(s[j])) {
                    break;
                }
                charSet.add(s[j]);
            }
            res = Math.max(res, charSet.size);
        }
        return res;
    }
}