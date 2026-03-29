public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;

        for (int i = 0; i <= k; i++) {
            int[] tmpPrices = (int[])prices.Clone();

            foreach (var flight in flights) {
                int s = flight[0];
                int d = flight[1];
                int p = flight[2];

                if (prices[s] == int.MaxValue)
                    continue;

                if (prices[s] + p < tmpPrices[d])
                    tmpPrices[d] = prices[s] + p;
            }

            prices = tmpPrices;
        }

        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}