public class Solution {
    public List<List<int>> res = new List<List<int>>();
    public Dictionary<int, int> count = new Dictionary<int, int>();

    public List<List<int>> CombinationSum2(int[] nums, int target) {
        List<int> cur = new List<int>();
        List<int> A = new List<int>();
        
        foreach (int num in nums) {
            if (!count.ContainsKey(num)) {
                A.Add(num);
            }
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
        }
        Backtrack(A, target, cur, 0);
        return res;
    }

    private void Backtrack(List<int> nums, int target, List<int> cur, int i) {
        if (target == 0) {
            res.Add(new List<int>(cur));
            return;
        }
        if (target < 0 || i >= nums.Count) {
            return;
        }

        if (count[nums[i]] > 0) {
            cur.Add(nums[i]);
            count[nums[i]]--;
            Backtrack(nums, target - nums[i], cur, i);
            count[nums[i]]++;
            cur.RemoveAt(cur.Count - 1);
        }

        Backtrack(nums, target, cur, i + 1);
    }
}