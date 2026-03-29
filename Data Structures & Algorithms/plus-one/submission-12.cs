class Solution {
    /**
     * @param {number[]} digits
     * @return {number[]}
     */
    plusOne(digits) {
        let one = 1;
        let i = 0;
        digits.reverse();

        while (one) {
            if (i < digits.length) {
                if (digits[i] === 9) {
                    digits[i] = 0;
                } else {
                    digits[i] += 1;
                    one = 0;
                }
            } else {
                digits.push(one);
                one = 0;
            }
            i++;
        }
        digits.reverse();
        return digits;
    }
}