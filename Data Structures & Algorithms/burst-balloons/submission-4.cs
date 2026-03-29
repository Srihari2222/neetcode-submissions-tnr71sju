public class Solution {
    public int MaxCoins(int[] nums) {
        List<int> newNums = new List<int> {1};
        newNums.AddRange(nums);
        newNums.Add(1);

        return Dfs(newNums);
    }

    public int Dfs(List<int> nums) {
        if (nums.Count == 2) return 0;

        int maxCoins = 0;
        for (int i = 1; i < nums.Count - 1; i++) {
            int coins = nums[i - 1] * nums[i] * nums[i + 1];
            List<int> newNums = new List<int>(nums);
            newNums.RemoveAt(i);
            coins += Dfs(newNums);
            maxCoins = Math.Max(maxCoins, coins);
        }
        return maxCoins;
    }
}