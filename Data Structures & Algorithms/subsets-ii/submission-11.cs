public class Solution {
    HashSet<string> res = new HashSet<string>();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        Backtrack(nums, 0, new List<int>());
        List<List<int>> result = new List<List<int>>();
        result.Add(new List<int>());
        res.Remove("");
        foreach (string str in res) {
            List<int> subset = new List<int>();
            string[] arr = str.Split(',');
            foreach (string num in arr) {
                subset.Add(int.Parse(num));
            }
            result.Add(subset);
        }
        return result;
    }

    private void Backtrack(int[] nums, int i, List<int> subset) {
        if (i == nums.Length) {
            res.Add(string.Join(",", subset));
            return;
        }

        subset.Add(nums[i]);
        Backtrack(nums, i + 1, subset);
        subset.RemoveAt(subset.Count - 1);
        Backtrack(nums, i + 1, subset);
    }
}