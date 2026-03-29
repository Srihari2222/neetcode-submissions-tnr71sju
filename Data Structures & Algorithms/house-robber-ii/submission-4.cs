public class Solution {
    private int[][] memo;

    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];
        
        memo = new int[nums.Length][];
        for (int i = 0; i < nums.Length; i++) {
            memo[i] = new int[] { -1, -1 };
        }
        
        return Math.Max(Dfs(0, 1, nums), Dfs(1, 0, nums));
    }

    private int Dfs(int i, int flag, int[] nums) {
        if (i >= nums.Length || (flag == 1 && i == nums.Length - 1)) 
            return 0;
        if (memo[i][flag] != -1) 
            return memo[i][flag];
        memo[i][flag] = Math.Max(Dfs(i + 1, flag, nums), 
                        nums[i] + Dfs(i + 2, flag | (i == 0 ? 1 : 0), nums));
        return memo[i][flag];
    }
}