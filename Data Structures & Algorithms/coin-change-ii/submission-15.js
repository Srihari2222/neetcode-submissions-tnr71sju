class Solution {
    /**
     * @param {number} amount
     * @param {number[]} coins
     * @return {number}
     */
    change(amount, coins) {
        coins.sort((a, b) => a - b);
    
        const dfs = (i, a) => {
            if (a === 0) return 1;
            if (i >= coins.length) return 0;

            let res = 0;
            if (a >= coins[i]) {
                res = dfs(i + 1, a);
                res += dfs(i, a - coins[i]);
            }
            return res;
        };

        return dfs(0, amount);
    }
}