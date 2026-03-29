public class Solution {
    public int SingleNumber(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            bool flag = true;
            for (int j = 0; j < nums.Length; j++) {
                if (i != j && nums[i] == nums[j]) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                return nums[i];
            }
        }
        return -1;
    }
}