public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums);
        for (int i = 0; i < n; i++) {
            if (nums[i] != i) {
                return i;
            }
        }
        return n;
    }
}