public class Solution {
    public int Jump(int[] nums) {
        return Dfs(nums, 0);
    }

    private int Dfs(int[] nums, int i) {
        if (i == nums.Length - 1) {
            return 0;
        }
        if (nums[i] == 0) return 1000000;
        int res = 1000000;
        int end = Math.Min(nums.Length - 1, i + nums[i]);
        for (int j = i + 1; j <= end; j++) {
            res = Math.Min(res, 1 + Dfs(nums, j));
        }
        return res;
    }
}