public class Solution {
    private int[,] memo;

    public int MaxSubArray(int[] nums) {
        memo = new int[nums.Length + 1, 2];
        for (int i = 0; i <= nums.Length; i++) {
            memo[i, 0] = memo[i, 1] = int.MinValue;
        }
        return Dfs(nums, 0, false);
    }

    private int Dfs(int[] nums, int i, bool flag) {
        if (i == nums.Length) return flag ? 0 : -1000000;
        int f = flag ? 1 : 0;
        if (memo[i, f] != int.MinValue) return memo[i, f];
        memo[i, f] = flag ? Math.Max(0, nums[i] + Dfs(nums, i + 1, true))
                          : Math.Max(Dfs(nums, i + 1, false), 
                                     nums[i] + Dfs(nums, i + 1, true));
        return memo[i, f];
    }
}