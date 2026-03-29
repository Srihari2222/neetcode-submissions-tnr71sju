class Solution {
    /**
     * @param {number} n
     * @return {boolean}
     */
    isHappy(n) {
        let slow = n;
        let fast = this.sumOfSquares(n);

        while (slow !== fast) {
            fast = this.sumOfSquares(fast);
            fast = this.sumOfSquares(fast);
            slow = this.sumOfSquares(slow);
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