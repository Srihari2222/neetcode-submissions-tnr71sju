class Solution {
    /**
     * @param {string[]} tokens
     * @return {number}
     */
    evalRPN(tokens) {
        const dfs = () => {
            const token = tokens.pop();
            if (!"+-*/".includes(token)) {
                return parseInt(token);
            }

            const right = dfs();
            const left = dfs();

            if (token === '+') {
                return left + right;
            } else if (token === '-') {
                return left - right;
            } else if (token === '*') {
                return left * right;
            } else {
                return Math.trunc(left / right);
            }
        };

        return dfs();
    }
}
