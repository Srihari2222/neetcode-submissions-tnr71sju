public class Solution {
    public int FindDuplicate(IList<int> nums) {
        int n = nums.Count;
        int res = 0;
        for (int b = 0; b < 32; b++) {
            int x = 0, y = 0;
            int mask = 1 << b;
            foreach (int num in nums) {
                if ((num & mask) != 0) {
                    x++;
                }
            }
            for (int num = 1; num < n; num++) {
                if ((num & mask) != 0) {
                    y++;
                }
            }
            if (x > y) {
                res |= mask;
            }
        }
        return res;
    }
}