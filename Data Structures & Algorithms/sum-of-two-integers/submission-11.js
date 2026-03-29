class Solution {
    /**
     * @param {number} a
     * @param {number} b
     * @return {number}
     */
    getSum(a, b) {
        let carry = 0, res = 0, mask = 0xFFFFFFFF;

        for (let i = 0; i < 32; i++) {
            let a_bit = (a >> i) & 1;
            let b_bit = (b >> i) & 1;
            let cur_bit = a_bit ^ b_bit ^ carry;
            carry = (a_bit + b_bit + carry) >= 2 ? 1 : 0;
            if (cur_bit) {
                res |= (1 << i);
            }
        }

        if (res > 0x7FFFFFFF) {
            res = ~(res ^ mask);
        }
        
        return res;
    }
}