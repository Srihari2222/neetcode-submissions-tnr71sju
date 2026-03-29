public class Solution {
    public int LengthOfLIS(int[] nums) {
        int n = nums.Length;
        int[,] dp = new int[n + 1, n + 1];

        for (int i = n - 1; i >= 0; i--) {
            for (int j = i - 1; j >= -1; j--) {
                int LIS = dp[i + 1, j + 1]; // Not including nums[i]

                if (j == -1 || nums[j] < nums[i]) {
                    LIS = Math.Max(LIS, 1 + dp[i + 1, i + 1]); // Including nums[i]
                }

                dp[i, j + 1] = LIS;
            }
        }

        return dp[0, 0];
    }
}