public class Solution {
    public int MaxProfit(int[] prices) {
        int res = 0;
        for (int i = 0; i < prices.Length; i++) {
            int buy = prices[i];
            for (int j = i + 1; j < prices.Length; j++) {
                int sell = prices[j];
                res = Math.Max(res, sell - buy);
            }
        }
        return res;
    }
}