class Solution {
    /**
     * @param {string} num1
     * @param {string} num2
     * @return {string}
     */
    multiply(num1, num2) {
        if (num1 === "0" || num2 === "0") return "0";

        if (num1.length < num2.length) {
            return this.multiply(num2, num1);
        }
        
        let res = "";
        let zero = 0;
        for (let i = num2.length - 1; i >= 0; i--) {
            const cur = this.mul(num1, num2[i], zero);
            res = this.add(res, cur);
            zero++;
        }
        
        return res;
    }
    
    /**
     * @param {string} s
     * @param {Character} d
     * @param {number} zero
     * @return {string}
     */
    mul(s, d, zero) {
        let i = s.length - 1;
        let carry = 0;
        const digit = Number(d);
        let cur = "";

        while (i >= 0 || carry) {
            const n = i >= 0 ? Number(s[i]) : 0;
            const prod = n * digit + carry;
            cur = (prod % 10) + cur;
            carry = Math.floor(prod / 10);
            i--;
        }
        
        return cur + "0".repeat(zero);
    }

    /**
     * @param {string} num1
     * @param {string} num2
     * @return {string}
     */
    add(num1, num2) {
        let i = num1.length - 1, j = num2.length - 1, carry = 0;
        let res = "";

        while (i >= 0 || j >= 0 || carry) {
            const n1 = i >= 0 ? Number(num1[i]) : 0;
            const n2 = j >= 0 ? Number(num2[j]) : 0;
            const total = n1 + n2 + carry;
            res = (total % 10) + res;
            carry = Math.floor(total / 10);
            i--;
            j--;
        }
        
        return res;
    }
}