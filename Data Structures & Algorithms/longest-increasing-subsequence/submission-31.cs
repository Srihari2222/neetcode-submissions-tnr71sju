public class SegmentTree {
    private int n;
    private int[] tree;

    public SegmentTree(int N) {
        n = N;
        tree = new int[2 * n];
        Array.Fill(tree, 0);
    }

    public void Update(int i, int val) {
        tree[n + i] = val;
        int j = (n + i) >> 1;
        while (j >= 1) {
            tree[j] = Math.Max(tree[2 * j], tree[2 * j + 1]);
            j >>= 1;
        }
    }

    public int Query(int l, int r) {
        if (l > r) {
            return 0;
        }
        int res = int.MinValue;
        l += n;
        r += n + 1;
        while (l < r) {
            if ((l & 1) == 1) {
                res = Math.Max(res, tree[l]);
                l++;
            }
            if ((r & 1) == 1) {
                r--;
                res = Math.Max(res, tree[r]);
            }
            l >>= 1;
            r >>= 1;
        }
        return res;
    }
}

public class Solution {
    public int LengthOfLIS(int[] nums) {
        var sortedArr = nums.Distinct().OrderBy(x => x).ToArray();
        var map = new Dictionary<int, int>();
        
        for (int i = 0; i < sortedArr.Length; i++) {
            map[sortedArr[i]] = i;
        }
        
        int n = sortedArr.Length;
        var segTree = new SegmentTree(n);
        
        int LIS = 0;
        foreach (var num in nums) {
            int compressedIndex = map[num];
            int curLIS = segTree.Query(0, compressedIndex - 1) + 1;
            segTree.Update(compressedIndex, curLIS);
            LIS = Math.Max(LIS, curLIS);
        }
        return LIS;
    }
}