public class Solution {
    public int SingleNumber(int[] nums) {
        Array.Sort(nums);
        int i = 0;
        while (i < nums.Length - 1) {
            if (nums[i] == nums[i + 1]) {
                i += 2;
            } else {
                return nums[i];
            }
        }
        return nums[i];
    }
}