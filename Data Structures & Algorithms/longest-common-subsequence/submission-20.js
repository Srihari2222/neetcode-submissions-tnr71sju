class Solution {
    /**
     * @param {string} text1
     * @param {string} text2
     * @return {number}
     */
    longestCommonSubsequence(text1, text2) {
        if (text1.length < text2.length) {
            [text1, text2] = [text2, text1];
        }

        let prev = new Array(text2.length + 1).fill(0);
        let curr = new Array(text2.length + 1).fill(0);

        for (let i = text1.length - 1; i >= 0; i--) {
            for (let j = text2.length - 1; j >= 0; j--) {
                if (text1[i] === text2[j]) {
                    curr[j] = 1 + prev[j + 1];
                } else {
                    curr[j] = Math.max(curr[j + 1], prev[j]);
                }
            }
            [prev, curr] = [curr, prev];
        }

        return prev[0];
    }
}