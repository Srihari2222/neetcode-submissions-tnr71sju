public class Solution {
    public bool CanPartition(int[] nums) {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }
        if (sum % 2 != 0) {
            return false;
        }
        
        return Dfs(nums, 0, sum / 2);
    }

    public bool Dfs(int[] nums, int i, int target) {
        if (i == nums.Length) {
            return target == 0;
        }
        if (target < 0) {
            return false;
        }

        return Dfs(nums, i + 1, target) || 
               Dfs(nums, i + 1, target - nums[i]);
    }
}