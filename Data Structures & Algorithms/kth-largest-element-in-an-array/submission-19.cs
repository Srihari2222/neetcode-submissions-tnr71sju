public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        k = nums.Length - k;
        return QuickSelect(nums, 0, nums.Length - 1, k);
    }

    private int QuickSelect(int[] nums, int left, int right, int k) {
        int pivot = nums[right];
        int p = left;

        for (int i = left; i < right; i++) {
            if (nums[i] <= pivot) {
                int temp = nums[p];
                nums[p] = nums[i];
                nums[i] = temp;
                p++;
            }
        }

        int tmp = nums[p];
        nums[p] = nums[right];
        nums[right] = tmp;

        if (p > k) {
            return QuickSelect(nums, left, p - 1, k);
        } else if (p < k) {
            return QuickSelect(nums, p + 1, right, k);
        } else {
            return nums[p];
        }
    }
}