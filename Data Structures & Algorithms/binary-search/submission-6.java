public class Solution {
    public int binary_search(int l, int r, List<Integer> nums, int target) {
        if (l > r) return -1;
        int m = l + (r - l) / 2;
        
        if (nums.get(m) == target) return m;
        return (nums.get(m) < target) ? 
            binary_search(m + 1, r, nums, target) : 
            binary_search(l, m - 1, nums, target);
    }

    public int search(List<Integer> nums, int target) {
        return binary_search(0, nums.size() - 1, nums, target);
    }
}