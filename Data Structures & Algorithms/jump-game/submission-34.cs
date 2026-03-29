public class Solution {
    public bool CanJump(int[] nums) {
        int n = nums.Length;
        bool[] dp = new bool[n];
        dp[n - 1] = true;

        for (int i = n - 2; i >= 0; i--) {
            int end = Math.Min(nums.Length, i + nums[i] + 1);
            for (int j = i + 1; j < end; j++) {
                if (dp[j]) {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[0];
    }
}