class Solution {
    /**
     * @param {number[]} digits
     * @return {number[]}
     */
    plusOne(digits) {
        if (digits.length === 0) {
            return [1];
        }

        if (digits[digits.length - 1] < 9) {
            digits[digits.length - 1] += 1;
            return digits;
        } else {
            return [...this.plusOne(digits.slice(0, digits.length - 1)), 0];
        }
    }
}