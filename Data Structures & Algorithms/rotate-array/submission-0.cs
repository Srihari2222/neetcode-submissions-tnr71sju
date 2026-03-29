public class Solution {
    public void Rotate(int[] nums, int k) {
        int n = nums.Length;
        k %= n;

        while (k > 0) {
            int tmp = nums[n - 1];
            for (int i = n - 1; i > 0; i--) {
                nums[i] = nums[i - 1];
            }
            nums[0] = tmp;
            k--;
        }
    }
}