public class Solution {
    public int[] CountBits(int n) {
        int[] res = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            res[i] = Convert.ToString(i, 2).Count(c => c == '1');
        }
        return res;
    }
}