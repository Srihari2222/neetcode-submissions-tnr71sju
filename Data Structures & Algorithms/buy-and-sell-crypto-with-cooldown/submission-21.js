class Solution {
    /**
     * @param {number[]} prices
     * @return {number}
     */
    maxProfit(prices) {
        const n = prices.length;
        let dp1_buy = 0, dp1_sell = 0;
        let dp2_buy = 0;

        for (let i = n - 1; i >= 0; i--) {
            let dp_buy = Math.max(dp1_sell - prices[i], dp1_buy);
            let dp_sell = Math.max(dp2_buy + prices[i], dp1_sell);
            dp2_buy = dp1_buy;
            dp1_sell = dp1_sell;
            dp1_buy = dp_buy;
            dp1_sell = dp_sell;
        }

        return dp1_buy;
    }
}