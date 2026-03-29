class Solution {
    /**
     * @param {string} text
     * @return {number}
     */
    maxNumberOfBalloons(text) {
        const countText = {};
        for (const c of text) {
            countText[c] = (countText[c] || 0) + 1;
        }

        const balloon = { b: 1, a: 1, l: 2, o: 2, n: 1 };

        let res = text.length;
        for (const c in balloon) {
            res = Math.min(res, Math.floor((countText[c] || 0) / balloon[c]));
        }
        return res;
    }
}