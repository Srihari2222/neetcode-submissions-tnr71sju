public class Solution {
    public int LongestConsecutive(int[] nums) {
        Dictionary<int, int> mp = new Dictionary<int, int>();
        int res = 0;

        foreach (int num in nums) {
            if (!mp.ContainsKey(num)) {
                mp[num] = (mp.ContainsKey(num - 1) ? mp[num - 1] : 0) + 
                          (mp.ContainsKey(num + 1) ? mp[num + 1] : 0) + 1;

                mp[num - (mp.ContainsKey(num - 1) ? mp[num - 1] : 0)] = mp[num];
                mp[num + (mp.ContainsKey(num + 1) ? mp[num + 1] : 0)] = mp[num];

                res = Math.Max(res, mp[num]);
            }
        }
        return res;  
    }
}
