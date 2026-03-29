public class Solution {
    public int SingleNumber(int[] nums) {
        var seen = new HashSet<int>();
        foreach (int num in nums) {
            if (seen.Contains(num)) {
                seen.Remove(num);
            } else {
                seen.Add(num);
            }
        }
        foreach (int num in seen) {
            return num; 
        }
        return -1; 
    }
}