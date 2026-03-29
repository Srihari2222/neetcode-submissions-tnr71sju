public class Solution {
    public bool CanJump(int[] nums) {
        var memo = new Dictionary<int, bool>();
        return Dfs(nums, 0, memo);
    }

    private bool Dfs(int[] nums, int i, Dictionary<int, bool> memo) {
        if (memo.ContainsKey(i)) {
            return memo[i];
        }
        if (i >= nums.Length - 1) {
            return true;
        }
        if (nums[i] == 0) {
            return false;
        }
        
        int end = Math.Min(nums.Length, i + nums[i] + 1);
        for (int j = i + 1; j < end; j++) {
            if (Dfs(nums, j, memo)) {
                memo[i] = true;
                return true;
            }
        }
        memo[i] = false;
        return false;
    }
}