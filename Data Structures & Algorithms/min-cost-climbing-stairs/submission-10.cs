public class Solution {
    int[] memo;
    
    public int MinCostClimbingStairs(int[] cost) {
        memo = new int[cost.Length];
        Array.Fill(memo, -1);
        return Math.Min(Dfs(cost, 0), Dfs(cost, 1));
    }
    
    private int Dfs(int[] cost, int i) {
        if (i >= cost.Length) {
            return 0;
        }
        if (memo[i] != -1) {
            return memo[i];
        }
        memo[i] = cost[i] + Math.Min(Dfs(cost, i + 1),
                                     Dfs(cost, i + 2));
        return memo[i];
    }
}