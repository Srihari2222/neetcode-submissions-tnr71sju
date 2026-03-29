class Solution {
    /**
     * @param {number} x
     * @param {number} n
     * @return {number}
     */
    myPow(x, n) {
        if (x === 0) return 0;
        if (n === 0) return 1;

        let res = 1;
        let power = Math.abs(n);

        while (power > 0) {
            if (power & 1) {
                res *= x;
            }
            x *= x;
            power >>= 1;
        }

        return n >= 0 ? res : 1 / res;
    }
}