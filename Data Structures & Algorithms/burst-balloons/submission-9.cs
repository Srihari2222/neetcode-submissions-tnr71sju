public class Solution {
    public int MaxCoins(int[] nums) {
        int n = nums.Length;
        int[] newNums = new int[n + 2];
        newNums[0] = newNums[n + 1] = 1;
        for (int i = 0; i < n; i++) {
            newNums[i + 1] = nums[i];
        }

        return Dfs(newNums, 1, newNums.Length - 2);
    }

    public int Dfs(int[] nums, int l, int r) {
        if (l > r) return 0;

        int maxCoins = 0;
        for (int i = l; i <= r; i++) {
            int coins = nums[l - 1] * nums[i] * nums[r + 1];
            coins += Dfs(nums, l, i - 1) + Dfs(nums, i + 1, r);
            maxCoins = Math.Max(maxCoins, coins);
        }
        return maxCoins;
    }
}