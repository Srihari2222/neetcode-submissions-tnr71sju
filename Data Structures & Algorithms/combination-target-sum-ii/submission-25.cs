public class Solution {
    private static List<List<int>> res = new List<List<int>>();

    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        res.Clear();
        Array.Sort(candidates);

        dfs(0, new List<int>(), 0, candidates, target);
        return res;
    }

    private void dfs(int idx, List<int> path, int cur, int[] candidates, int target) {
        if (cur == target) {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = idx; i < candidates.Length; i++) {
            if (i > idx && candidates[i] == candidates[i - 1]) {
                continue;
            }
            if (cur + candidates[i] > target) {
                break;
            }

            path.Add(candidates[i]);
            dfs(i + 1, path, cur + candidates[i], candidates, target);
            path.RemoveAt(path.Count - 1);
        }
    }
}