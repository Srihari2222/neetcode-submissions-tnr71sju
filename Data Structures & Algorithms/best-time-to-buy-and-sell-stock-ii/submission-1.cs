public class Solution {
    public int MaxProfit(int[] prices) {
        return Rec(prices, 0, false);
    }

    private int Rec(int[] prices, int i, bool bought) {
        if (i == prices.Length) {
            return 0;
        }

        int res = Rec(prices, i + 1, bought);

        if (bought) {
            res = Math.Max(res, prices[i] + Rec(prices, i + 1, false));
        } else {
            res = Math.Max(res, -prices[i] + Rec(prices, i + 1, true));
        }

        return res;
    }
}