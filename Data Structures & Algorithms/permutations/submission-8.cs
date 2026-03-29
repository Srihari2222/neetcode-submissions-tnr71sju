public class Solution {
    public List<List<int>> Permute(int[] nums) {
        if (nums.Length == 0) {
            return new List<List<int>> { new List<int>() };
        }
        
        var perms = Permute(nums[1..]);
        var res = new List<List<int>>();
        foreach (var p in perms) {
            for (int i = 0; i <= p.Count; i++) {
                var p_copy = new List<int>(p);
                p_copy.Insert(i, nums[0]);
                res.Add(p_copy);
            }
        }
        return res;
    }
}