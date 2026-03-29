public class Solution {
    public bool CanJump(int[] nums) {
        return Dfs(nums, 0);
    }

    private bool Dfs(int[] nums, int i) {
        if (i == nums.Length - 1) {
            return true;
        }
        int end = Math.Min(nums.Length - 1, i + nums[i]);
        for (int j = i + 1; j <= end; j++) {
            if (Dfs(nums, j)) {
                return true;
            }
        }
        return false;
    }
}