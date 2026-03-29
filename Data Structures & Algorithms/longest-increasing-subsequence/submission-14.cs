public class Solution {
    public int LengthOfLIS(int[] nums) {
        return Dfs(nums, 0, -1);
    }

    private int Dfs(int[] nums, int i, int j) {
        if (i == nums.Length) {
            return 0;
        }

        int LIS = Dfs(nums, i + 1, j); // not include

        if (j == -1 || nums[j] < nums[i]) {
            LIS = Math.Max(LIS, 1 + Dfs(nums, i + 1, i)); // include
        }

        return LIS;
    }
}