public class SegmentTree {
    public int n;
    public int[] A;
    public int[] tree;
    public const int NEG_INF = int.MinValue;

    public SegmentTree(int N, int[] a) {
        this.n = N;
        while (System.Numerics.BitOperations.PopCount((uint)n) != 1) {
            n++;
        }
        A = new int[n];
        for (int i = 0; i < N; i++) {
            A[i] = a[i];
        }
        for (int i = N; i < n; i++) {
            A[i] = NEG_INF;
        }
        tree = new int[2 * n];
        Build();
    }

    public void Build() {
        for (int i = 0; i < n; i++) {
            tree[n + i] = A[i];
        }
        for (int i = n - 1; i > 0; --i) {
            tree[i] = Math.Max(tree[i << 1], tree[i << 1 | 1]);
        }
    }

    public void Update(int i, int val) {
        tree[n + i] = val;
        for (int j = (n + i) >> 1; j >= 1; j >>= 1) {
            tree[j] = Math.Max(tree[j << 1], tree[j << 1 | 1]);
        }
    }

    public int Query(int l, int r) {
        int res = NEG_INF;
        l += n;
        r += n + 1;
        while (l < r) {
            if ((l & 1) == 1) res = Math.Max(res, tree[l++]);
            if ((r & 1) == 1) res = Math.Max(res, tree[--r]);
            l >>= 1;
            r >>= 1;
        }
        return res;
    }
}

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        SegmentTree segTree = new SegmentTree(n, nums);
        int[] output = new int[n - k + 1];
        for (int i = 0; i <= n - k; i++) {
            output[i] = segTree.Query(i, i + k - 1);
        }
        return output;
    }
}