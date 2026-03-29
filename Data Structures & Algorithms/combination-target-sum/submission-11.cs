public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        var res = new List<List<int>>();
        Array.Sort(nums);
        dfs(0, new List<int>(), 0, nums, target, res);
        return res;
    }

    private void dfs(int i, List<int> cur, int total, int[] nums, int target, List<List<int>> res) {
        if (total == target) {
            res.Add(new List<int>(cur));
            return;
        }
        
        for (int j = i; j < nums.Length; j++) {
            if (total + nums[j] > target) {
                return;
            }
            cur.Add(nums[j]);
            dfs(j, cur, total + nums[j], nums, target, res);
            cur.RemoveAt(cur.Count - 1);
        }
    }
}