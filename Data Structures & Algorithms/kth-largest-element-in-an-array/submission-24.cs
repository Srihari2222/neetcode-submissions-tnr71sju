public class Solution {
    
    public int FindKthLargest(int[] nums, int k) {
        k = nums.Length - k;
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int pivot = Partition(nums, left, right);
            if (pivot < k)
                left = pivot + 1;
            else if (pivot > k)
                right = pivot - 1;
            else
                break;
        }
        return nums[k];
    }

    private int Partition(int[] nums, int left, int right) {
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