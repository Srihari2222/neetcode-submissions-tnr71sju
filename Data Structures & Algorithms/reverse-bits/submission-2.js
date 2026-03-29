class Solution {
    /**
     * @param {number} n - a positive integer
     * @return {number} - a positive integer
     */
    reverseBits(n) {
        let binary = "";
        for (let i = 0; i < 32; i++) {
            if (n & (1 << i)) {
                binary += "1";
            } else {
                binary += "0";
            }
        }
        
        let res = 0;
        for (let i = 0; i < 32; i++) {
            if (binary[31 - i] === "1") { 
                res |= (1 << i);
            }
        }
        
        return res >>> 0;
    }
}