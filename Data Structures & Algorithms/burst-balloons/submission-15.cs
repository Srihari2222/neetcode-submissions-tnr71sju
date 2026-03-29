public class Solution {
    public int MaxCoins(int[] nums) {
        int n = nums.Length;
        int[] newNums = new int[n + 2];
        newNums[0] = newNums[n + 1] = 1;
        for (int i = 0; i < n; i++) {
            newNums[i + 1] = nums[i];
        }

        int[,] dp = new int[n + 2, n + 2];
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= n; j++) {
                dp[i, j] = -1;
            }
        }

        return Dfs(newNums, 1, newNums.Length - 2, dp);
    }

    public int Dfs(int[] nums, int l, int r, int[,] dp) {
        if (l > r) return 0;
        if (dp[l, r] != -1) return dp[l, r];

        dp[l, r] = 0;
        for (int i = l; i <= r; i++) {
            int coins = nums[l - 1] * nums[i] * nums[r + 1];
            coins += Dfs(nums, l, i - 1, dp) + Dfs(nums, i + 1, r, dp);
            dp[l, r] = Math.Max(dp[l, r], coins);
        }
        return dp[l, r];
    }
}