public class Solution {
    private int[] memo;

    public int LengthOfLIS(int[] nums) {
        int n = nums.Length;
        memo = new int[n];
        Array.Fill(memo, -1);

        int maxLIS = 1;
        for (int i = 0; i < n; i++) {
            maxLIS = Math.Max(maxLIS, Dfs(nums, i));
        }
        return maxLIS;
    }

    private int Dfs(int[] nums, int i) {
        if (memo[i] != -1) {
            return memo[i];
        }

        int LIS = 1;
        for (int j = i + 1; j < nums.Length; j++) {
            if (nums[i] < nums[j]) {
                LIS = Math.Max(LIS, 1 + Dfs(nums, j));
            }
        }

        memo[i] = LIS;
        return LIS;
    }
}