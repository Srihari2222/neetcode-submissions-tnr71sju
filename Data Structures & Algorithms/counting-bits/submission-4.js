class Solution {
    /**
     * @param {number} n
     * @return {number[]}
     */
    countBits(n) {
        let res = [];
        for (let num = 0; num <= n; num++) {
            let one = 0;
            for (let i = 0; i < 32; i++) {
                if ((num & (1 << i)) != 0) {
                    one++;
                }
            }
            res.push(one);
        }
        return res;
    }
}