public class Solution {
    private int[] memo;

    public int Rob(int[] nums) {
        memo = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            memo[i] = -1;
        }
        return Dfs(nums, 0);
    }

    private int Dfs(int[] nums, int i) {
        if (i >= nums.Length) {
            return 0;
        }
        if (memo[i] != -1) {
            return memo[i];
        }
        memo[i] = Math.Max(Dfs(nums, i + 1),
                         nums[i] + Dfs(nums, i + 2));
        return memo[i];
    }
}