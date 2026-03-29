public class Solution {
    public int MaxSubArray(int[] nums) {
        return Dfs(nums, 0, false);
    }

    private int Dfs(int[] nums, int i, bool flag) {
        if (i == nums.Length) return flag ? 0 : (int)-1e6;
        if (flag) return Math.Max(0, nums[i] + Dfs(nums, i + 1, true));
        return Math.Max(Dfs(nums, i + 1, false), 
                        nums[i] + Dfs(nums, i + 1, true));
    }
}