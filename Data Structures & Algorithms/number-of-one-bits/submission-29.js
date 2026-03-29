class Solution {
    /**
     * @param {number} n - a positive integer
     * @return {number}
     */
    hammingWeight(n) {
        return n.toString(2).split('0').join('').length;
    }
}