public class Solution {
    public int Dfs(int[] coins, int amount) {
        if (amount == 0) return 0;

        int res = (int)1e9;
        foreach (var coin in coins) {
            if (amount - coin >= 0) {
                res = Math.Min(res, 
                      1 + Dfs(coins, amount - coin));
            }
        }
        return res;
    }

    public int CoinChange(int[] coins, int amount) {
        int minCoins = Dfs(coins, amount);
        return (minCoins >= 1e9) ? -1 : minCoins;
    }
}