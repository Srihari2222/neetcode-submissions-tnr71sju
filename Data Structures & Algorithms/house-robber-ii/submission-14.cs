public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];
        return Math.Max(Dfs(0, true, nums), Dfs(1, false, nums));
    }
    
    private int Dfs(int i, bool flag, int[] nums) {
        if (i >= nums.Length || (flag && i == nums.Length - 1)) 
            return 0;

        return Math.Max(Dfs(i + 1, flag, nums), 
                        nums[i] + Dfs(i + 2, flag || i == 0, nums));
    }
}