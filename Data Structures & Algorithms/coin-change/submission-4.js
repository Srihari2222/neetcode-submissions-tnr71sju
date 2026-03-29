class Solution {
    /**
     * @param {number[]} coins
     * @param {number} amount
     * @return {number}
     */
    coinChange(coins, amount) {

        const dfs = (amount) => {
            if (amount === 0) return 0;

            let res = Infinity;
            for (let coin of coins) {
                if (amount - coin >= 0) {
                    res = Math.min(res, 
                          1 + dfs(amount - coin));
                }
            }
            return res;
        }

        const minCoins = dfs(amount);
        return minCoins === Infinity ? -1 : minCoins;
    }
}