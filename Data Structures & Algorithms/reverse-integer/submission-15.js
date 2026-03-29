class Solution {
    /**
     * @param {number} x
     * @return {number}
     */
    reverse(x) {
        let res = this.rec(Math.abs(x), 0) * (x < 0 ? -1 : 1);
        if (res < -(2 ** 31) || res > (2 ** 31) - 1) {
            return 0;
        }
        return res;
    }

    /**
     * @param {number} n
     * @param {number} rev
     * @return {number}
     */
    rec(n, rev) {
        if (n === 0) {
            return rev;
        }
        rev = rev * 10 + n % 10;
        return this.rec(Math.floor(n / 10), rev);
    }
}