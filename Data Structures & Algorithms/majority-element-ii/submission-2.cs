public class Solution {
    public List<int> MajorityElement(int[] nums) {
        HashSet<int> res = new HashSet<int>();
        int n = nums.Length;

        foreach (int num in nums) {
            int count = nums.Count(x => x == num);
            if (count > n / 3) {
                res.Add(num);
            }
        }

        return res.ToList();
    }
}