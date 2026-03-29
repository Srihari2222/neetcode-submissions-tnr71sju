public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int[] unique = nums.Distinct().OrderBy(x => x).ToArray();
        Array.Copy(unique, nums, unique.Length);
        return unique.Length;
    }
}