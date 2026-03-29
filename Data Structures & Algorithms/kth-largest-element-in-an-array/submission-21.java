public class Solution {  
    public int findKthLargest(int[] nums, int k) {
        k = nums.length - k;
        int left = 0, right = nums.length - 1;
        while (left < right) {
            int pivot = partition(nums, left, right);
            if (pivot < k)
                left = pivot + 1;
            else if (pivot > k)
                right = pivot - 1;
            else
                break;
        }
        return nums[k];
    }

    private int partition(int[] nums, int left, int right) {
        int pivot = nums[right], fill = left;
        for (int i = left; i < right; i++) {
            if (nums[i] <= pivot) {
                int temp = nums[fill];
                nums[fill++] = nums[i];
                nums[i] = temp;
            }
        }
        nums[right] = nums[fill];
        nums[fill] = pivot;
        return fill;
    }
}