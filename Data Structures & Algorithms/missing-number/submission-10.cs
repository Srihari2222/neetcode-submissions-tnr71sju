public class Solution {
    public int MissingNumber(int[] nums) {
        HashSet<int> numSet = new HashSet<int>(nums);
        int n = nums.Length;
        for (int i = 0; i <= n; i++) {
            if (!numSet.Contains(i)) {
                return i;
            }
        }
        return -1;
    }
}