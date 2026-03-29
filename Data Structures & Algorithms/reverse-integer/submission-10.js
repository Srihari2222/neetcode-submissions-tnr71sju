class Solution {
    /**
     * @param {number} x
     * @return {number}
     */
    reverse(x) {
        const org = x;
        x = Math.abs(x);
        let res = parseInt(x.toString().split('').reverse().join(''));
        if (org < 0) {
            res *= -1;
        }
        if (res < -(2 ** 31) || res > (2 ** 31) - 1) {
            return 0;
        }
        return res;
    }
}