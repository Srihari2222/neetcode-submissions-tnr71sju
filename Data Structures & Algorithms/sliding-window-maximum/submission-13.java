public class SegmentTree {
    int n;
    int[] A;
    int[] tree;
    final int NEG_INF = Integer.MIN_VALUE;

    SegmentTree(int N, int[] a) {
        this.n = N;
        this.A = a.clone();
        while (Integer.bitCount(n) != 1) {
            A = java.util.Arrays.copyOf(A, n + 1);
            A[n++] = NEG_INF;
        }
        tree = new int[2 * n];
        build();
    }

    void build() {
        for (int i = 0; i < n; i++) {
            tree[n + i] = A[i];
        }
        for (int i = n - 1; i > 0; --i) {
            tree[i] = Math.max(tree[i << 1], tree[i << 1 | 1]);
        }
    }

    void update(int i, int val) {
        tree[n + i] = val;
        for (int j = (n + i) >> 1; j >= 1; j >>= 1) {
            tree[j] = Math.max(tree[j << 1], tree[j << 1 | 1]);
        }
    }

    int query(int l, int r) {
        int res = NEG_INF;
        for (l += n, r += n + 1; l < r; l >>= 1, r >>= 1) {
            if ((l & 1) == 1) res = Math.max(res, tree[l++]);
            if ((r & 1) == 1) res = Math.max(res, tree[--r]);
        }
        return res;
    }
}

public class Solution {
    public int[] maxSlidingWindow(int[] nums, int k) {
        int n = nums.length;
        SegmentTree segTree = new SegmentTree(n, nums);
        int[] output = new int[n - k + 1];
        for (int i = 0; i <= n - k; i++) {
            output[i] = segTree.query(i, i + k - 1);
        }
        return output;
    }
}