class Solution {
    /**
     * @param {number[]} prices
     * @return {number}
     */
    maxProfit(prices) {

        const dfs = (i, buying) => {
            if (i >= prices.length) {
                return 0;
            }

            let cooldown = dfs(i + 1, buying);
            if (buying) {
                let buy = dfs(i + 1, false) - prices[i];
                return Math.max(buy, cooldown);
            } else {
                let sell = dfs(i + 2, true) + prices[i];
                return Math.max(sell, cooldown);
            }
        }
        
        return dfs(0, true);
    }
}