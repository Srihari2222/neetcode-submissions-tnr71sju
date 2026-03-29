public class Solution {
    public int MaxSubArray(int[] nums) {
        int n = nums.Length, res = nums[0];
        for (int i = 0; i < n; i++) {
            int cur = 0;
            for (int j = i; j < n; j++) {
                cur += nums[j];
                res = Math.Max(res, cur);
            }
        }
        return res;
    }
}