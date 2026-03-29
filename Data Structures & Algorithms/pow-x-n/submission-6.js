class Solution {
    /**
     * @param {number} x
     * @param {number} n
     * @return {number}
     */
    myPow(x, n) {
        if (x === 0) {
            return 0;
        }
        if (n === 0) {
            return 1;
        }

        let res = 1;
        for (let i = 0; i < Math.abs(n); i++) {
            res *= x;
        }
        return n >= 0 ? res : 1 / res;
    }
}