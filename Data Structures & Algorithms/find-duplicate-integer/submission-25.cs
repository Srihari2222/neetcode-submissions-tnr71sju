public class Solution {
    public int FindDuplicate(int[] nums) {
        foreach (int num in nums) {
            int idx = Math.Abs(num) - 1;
            if (nums[idx] < 0) {
                return Math.Abs(num);
            }
            nums[idx] *= -1;
        }
        return -1;
    }
}