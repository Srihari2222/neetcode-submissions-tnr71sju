public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int n = nums.Length;
        int res = int.MaxValue;

        for (int i = 0; i < n; i++) {
            int curSum = 0;
            for (int j = i; j < n; j++) {
                curSum += nums[j];
                if (curSum >= target) {
                    res = Math.Min(res, j - i + 1);
                    break;
                }
            }
        }

        return res == int.MaxValue ? 0 : res;
    }
}