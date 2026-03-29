public class Solution {
    public int MajorityElement(int[] nums) {
        int n = nums.Length;
        foreach (int num in nums) {
            int count = 0;
            foreach (int i in nums) {
                if (i == num) {
                    count++;
                }
            }
            if (count > n / 2) {
                return num;
            }
        }
        return -1;
    }
}