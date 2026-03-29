public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        return Backtrack(0, 0, nums, target);
    }

    private int Backtrack(int i, int total, int[] nums, int target) {
        if (i == nums.Length) {
            return total == target ? 1 : 0;
        }
        return Backtrack(i + 1, total + nums[i], nums, target) + 
               Backtrack(i + 1, total - nums[i], nums, target);
    }
}