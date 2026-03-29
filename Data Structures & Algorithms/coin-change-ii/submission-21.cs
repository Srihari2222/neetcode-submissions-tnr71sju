public class Solution {
    public int Change(int amount, int[] coins) {
        Array.Sort(coins);
        int[,] memo = new int[coins.Length + 1, amount + 1];
        for (int i = 0; i <= coins.Length; i++) {
            for (int j = 0; j <= amount; j++) {
                memo[i, j] = -1;
            }
        }

        return Dfs(0, amount, coins, memo);
    }

    private int Dfs(int i, int a, int[] coins, int[,] memo) {
        if (a == 0) return 1;
        if (i >= coins.Length) return 0;
        if (memo[i, a] != -1) return memo[i, a];

        int res = 0;
        if (a >= coins[i]) {
            res = Dfs(i + 1, a, coins, memo);
            res += Dfs(i, a - coins[i], coins, memo);
        }
        memo[i, a] = res;
        return res;
    }
}