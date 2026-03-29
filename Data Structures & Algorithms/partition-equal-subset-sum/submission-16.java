public class Solution {
    public boolean canPartition(int[] nums) {
        int total = 0;
        for (int num : nums) {
            total += num;
        }
        if (total % 2 != 0) {
            return false;
        }

        int target = total / 2;
        int dp = 1;

        for (int num : nums) {
            dp |= dp << num;
        }

        return (dp & (1 << target)) != 0;
    }
}
