public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        Dictionary<int, int> mp = new Dictionary<int, int>();
        for (int i = 0; i < numbers.Length; i++) {
            int tmp = target - numbers[i];
            if (mp.ContainsKey(tmp)) {
                return new int[] { mp[tmp], i + 1 };
            }
            mp[numbers[i]] = i + 1;
        }
        return new int[0];
    }
}