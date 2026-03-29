public class Solution {
    public int maxSubArray(int[] nums) {
        return dfs(nums, 0, false);
    }

    private int dfs(int[] nums, int i, boolean flag) {
        if (i == nums.length) {
            return flag ? 0 : (int) -1e6;
        }
        if (flag) {
            return Math.max(0, nums[i] + dfs(nums, i + 1, true));
        }
        return Math.max(dfs(nums, i + 1, false), nums[i] + dfs(nums, i + 1, true));
    }
}