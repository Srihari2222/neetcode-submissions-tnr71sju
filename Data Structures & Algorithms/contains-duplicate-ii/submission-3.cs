public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        for (int L = 0; L < nums.Length; L++) {
            for (int R = L + 1; R < Math.Min(nums.Length, L + k + 1); R++) {
                if (nums[L] == nums[R]) {
                    return true;
                }
            }
        }
        return false;
    }
}