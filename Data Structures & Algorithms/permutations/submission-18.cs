public class Solution {
    List<List<int>> res;
    public List<List<int>> Permute(int[] nums) {
        res = new List<List<int>>();
        Backtrack(new List<int>(), nums, new bool[nums.Length]);
        return res;
    }

    private void Backtrack(List<int> perm, int[] nums, bool[] pick) {
        if (perm.Count == nums.Length) {
            res.Add(new List<int>(perm));
            return;
        }
        for (int i = 0; i < nums.Length; i++) {
            if (!pick[i]) {
                perm.Add(nums[i]);
                pick[i] = true;
                Backtrack(perm, nums, pick);
                perm.RemoveAt(perm.Count - 1);
                pick[i] = false;
            }
        }
    }
}