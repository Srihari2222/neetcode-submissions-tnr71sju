public class Solution {
    List<List<int>> res = new List<List<int>>();

    public List<List<int>> Permute(int[] nums) {
        Backtrack(new List<int>(), nums, 0);
        return res;
    }

    private void Backtrack(List<int> perm, int[] nums, int mask) {
        if (perm.Count == nums.Length) {
            res.Add(new List<int>(perm));
            return;
        }
        for (int i = 0; i < nums.Length; i++) {
            if ((mask & (1 << i)) == 0) {
                perm.Add(nums[i]);
                Backtrack(perm, nums, mask | (1 << i));
                perm.RemoveAt(perm.Count - 1);
            }
        }
    }
}