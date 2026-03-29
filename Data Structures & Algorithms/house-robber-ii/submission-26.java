public class Solution {
    
    public int rob(int[] nums) {
        return Math.max(nums[0], 
               Math.max(helper(Arrays.copyOfRange(nums, 1, nums.length)), 
               helper(Arrays.copyOfRange(nums, 0, nums.length - 1))));
    }

    private int helper(int[] nums) {
        int rob1 = 0, rob2 = 0;

        for (int n : nums) {
            int newRob = Math.max(rob1 + n, rob2);
            rob1 = rob2;
            rob2 = newRob;
        }
        return rob2;
    }
}