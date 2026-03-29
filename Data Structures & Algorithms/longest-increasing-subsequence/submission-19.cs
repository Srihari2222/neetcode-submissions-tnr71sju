public class Solution {
    public int LengthOfLIS(int[] nums) {
        int n = nums.Length;
        int[,] memo = new int[n, n + 1];

        for (int i = 0; i < n; i++)
            for (int j = 0; j <= n; j++)
                memo[i, j] = -1;

        return DFS(nums, 0, -1, memo);
    }

    private int DFS(int[] nums, int i, int j, int[,] memo) {
        if (i == nums.Length) return 0; 
        if (memo[i, j + 1] != -1) {
            return memo[i, j + 1];
        }

        int LIS = DFS(nums, i + 1, j, memo);

        if (j == -1 || nums[j] < nums[i]) {
            LIS = Math.Max(LIS, 1 + DFS(nums, i + 1, i, memo));
        }

        memo[i, j + 1] = LIS;
        return LIS;
    }
}