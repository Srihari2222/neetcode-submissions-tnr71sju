public class Solution {
    public int FindDuplicate(int[] nums) {
        int[] seen = new int[nums.Length];
        foreach (int num in nums) {
            if (seen[num - 1] == 1) {
                return num;
            }
            seen[num - 1] = 1;
        }
        return -1;
    }
}