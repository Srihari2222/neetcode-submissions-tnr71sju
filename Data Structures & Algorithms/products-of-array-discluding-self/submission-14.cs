public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int prod = 1, zeroCount = 0;
        foreach (int num in nums) {
            if (num != 0) {
                prod *= num;
            } else {
                zeroCount++;
            }
        }

        if (zeroCount > 1) {
            return new int[nums.Length]; 
        }

        int[] res = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            if (zeroCount > 0) {
                res[i] = (nums[i] == 0) ? prod : 0;
            } else {
                res[i] = prod / nums[i];
            }
        }
        return res;
    }
}
