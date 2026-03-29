public class Solution {
    public int Rob(int[] nums) {
        return Dfs(nums, 0);
    }

    private int Dfs(int[] nums, int i) {
        if (i >= nums.Length) {
            return 0;
        }
        return Math.Max(Dfs(nums, i + 1),
               nums[i] + Dfs(nums, i + 2));
    }
}