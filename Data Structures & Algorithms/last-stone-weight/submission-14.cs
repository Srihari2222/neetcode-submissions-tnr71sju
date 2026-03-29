public class Solution {
    public int LastStoneWeight(int[] stones) {
        Array.Sort(stones);
        int n = stones.Length;

        while (n > 1) {
            int cur = stones[n - 1] - stones[n - 2];
            n -= 2;
            if (cur > 0) {
                int l = 0, r = n;
                while (l < r) {
                    int mid = (l + r) / 2;
                    if (stones[mid] < cur) {
                        l = mid + 1;
                    } else {
                        r = mid;
                    }
                }
                int pos = l;
                Array.Resize(ref stones, n + 1);
                for (int i = n; i > pos; i--) {
                    stones[i] = stones[i - 1];
                }
                stones[pos] = cur;
                n++;
            }
        }
        return n > 0 ? stones[0] : 0;
    }
}