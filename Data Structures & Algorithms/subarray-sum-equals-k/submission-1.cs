public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int res = 0;
        for (int i = 0; i < nums.Length; i++) {
            int sum = 0;
            for (int j = i; j < nums.Length; j++) {
                sum += nums[j];
                if (sum == k) {
                    res++;
                }
            }
        }
        return res;
    }
}