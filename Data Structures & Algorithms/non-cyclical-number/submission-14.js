class Solution {
    /**
     * @param {number} n
     * @return {boolean}
     */
    isHappy(n) {
        let slow = n;
        let fast = this.sumOfSquares(n);
        let power = 1, lam = 1;

        while (slow !== fast) {
            if (power === lam) {
                slow = fast;
                power *= 2;
                lam = 0;
            }
            lam++;
            fast = this.sumOfSquares(fast);
        }

        return fast === 1;
    }

    /**
     * @param {number} n
     * @return {number}
     */
    sumOfSquares(n) {
        let output = 0;
        while (n !== 0) {
            output += (n % 10) ** 2;
            n = Math.floor(n / 10);
        }
        return output;
    }
}