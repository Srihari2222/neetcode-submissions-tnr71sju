public class Solution {
    private int[][] memo;

    public int maxSubArray(int[] nums) {
        memo = new int[nums.length + 1][2];
        for (int[] row : memo) Arrays.fill(row, Integer.MIN_VALUE);
        return dfs(nums, 0, false);
    }

    private int dfs(int[] nums, int i, boolean flag) {
        if (i == nums.length) return flag ? 0 : (int) -1e6;
        int f = flag ? 1 : 0;
        if (memo[i][f] != Integer.MIN_VALUE) return memo[i][f];
        memo[i][f] = flag ? Math.max(0, nums[i] + dfs(nums, i + 1, true))
                          : Math.max(dfs(nums, i + 1, false), 
                                     nums[i] + dfs(nums, i + 1, true));
        return memo[i][f];
    }
}