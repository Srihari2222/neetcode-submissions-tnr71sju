public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        return Math.Min(Dfs(cost, 0), Dfs(cost, 1));
    }
    
    private int Dfs(int[] cost, int i) {
        if (i >= cost.Length) {
            return 0;
        }
        return cost[i] + Math.Min(Dfs(cost, i + 1),
                                  Dfs(cost, i + 2));
    }
}