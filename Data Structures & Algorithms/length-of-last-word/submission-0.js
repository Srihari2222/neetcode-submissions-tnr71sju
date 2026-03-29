class Solution {
    /**
     * @param {string} s
     * @return {number}
     */
    lengthOfLastWord(s) {
        let length = 0,
            i = 0;
        while (i < s.length) {
            if (s[i] === ' ') {
                while (i < s.length && s[i] === ' ') {
                    i++;
                }
                if (i === s.length) {
                    return length;
                }
                length = 0;
            } else {
                length++;
                i++;
            }
        }
        return length;
    }
}