public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (!count.ContainsKey(num)) {
                count[num] = 0;
            }
            count[num]++;
        }

        List<List<int>> res = new List<List<int>>();
        for (int i = 0; i < nums.Length; i++) {
            count[nums[i]]--;
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < nums.Length; j++) {
                count[nums[j]]--;
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                int target = -(nums[i] + nums[j]);
                if (count.ContainsKey(target) && count[target] > 0) {
                    res.Add(new List<int> { nums[i], nums[j], target });
                }
            }

            for (int j = i + 1; j < nums.Length; j++) {
                count[nums[j]]++;
            }
        }

        return res;
    }
}