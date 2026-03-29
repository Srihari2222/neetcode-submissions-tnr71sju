public class Solution {
    public int Change(int amount, int[] coins) {
        Array.Sort(coins);
        return Dfs(coins, 0, amount);
    }

    private int Dfs(int[] coins, int i, int a) {
        if (a == 0) {
            return 1;
        }
        if (i >= coins.Length) {
            return 0;
        }

        int res = 0;
        if (a >= coins[i]) {
            res = Dfs(coins, i + 1, a);
            res += Dfs(coins, i, a - coins[i]);
        }
        return res;
    }
}