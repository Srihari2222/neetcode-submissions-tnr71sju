public class Solution {
    private Dictionary<(int, bool), int> dp = 
                    new Dictionary<(int, bool), int>();

    public int MaxProfit(int[] prices) {
        return Dfs(0, true, prices);
    }

    private int Dfs(int i, bool buying, int[] prices) {
        if (i >= prices.Length) {
            return 0;
        }

        var key = (i, buying);
        if (dp.ContainsKey(key)) {
            return dp[key];
        }

        int cooldown = Dfs(i + 1, buying, prices);
        if (buying) {
            int buy = Dfs(i + 1, false, prices) - prices[i];
            dp[key] = Math.Max(buy, cooldown);
        } else {
            int sell = Dfs(i + 2, true, prices) + prices[i];
            dp[key] = Math.Max(sell, cooldown);
        }

        return dp[key];
    }
}