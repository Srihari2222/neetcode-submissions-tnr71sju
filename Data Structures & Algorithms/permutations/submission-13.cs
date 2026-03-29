public class Solution {
    public List<List<int>> Permute(int[] nums) {
        var perms = new List<List<int>>() { new List<int>() };
        foreach (int num in nums) {
            var new_perms = new List<List<int>>();
            foreach (var p in perms) {
                for (int i = 0; i <= p.Count; i++) {
                    var p_copy = new List<int>(p);
                    p_copy.Insert(i, num);
                    new_perms.Add(p_copy);
                }
            }
            perms = new_perms;
        }
        return perms;
    }
}