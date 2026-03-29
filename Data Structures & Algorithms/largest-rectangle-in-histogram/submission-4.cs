public class MinIdx_Segtree {
    private int n;
    private readonly int INF = (int)1e9;
    private int[] A, tree;

    public MinIdx_Segtree(int N, int[] heights) {
        this.n = N;
        this.A = new int[heights.Length];
        heights.CopyTo(this.A, 0);
        while ((n & (n - 1)) != 0) {
            Array.Resize(ref A, n + 1);
            A[n] = INF;
            n++;
        }
        tree = new int[2 * n];
        Build();
    }

    private void Build() {
        for (int i = 0; i < n; i++) {
            tree[n + i] = i;
        }
        for (int j = n - 1; j >= 1; j--) {
            int a = tree[j << 1];
            int b = tree[(j << 1) + 1];
            tree[j] = A[a] <= A[b] ? a : b;
        }
    }

    public int Query(int ql, int qh) {
        return Query(1, 0, n - 1, ql, qh);
    }

    private int Query(int node, int l, int h, int ql, int qh) {
        if (ql > h || qh < l) return INF;
        if (l >= ql && h <= qh) return tree[node];
        int a = Query(node << 1, l, (l + h) >> 1, ql, qh);
        int b = Query((node << 1) + 1, ((l + h) >> 1) + 1, h, ql, qh);
        if (a == INF) return b;
        if (b == INF) return a;
        return A[a] <= A[b] ? a : b;
    }
}

public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        MinIdx_Segtree st = new MinIdx_Segtree(n, heights);
        return GetMaxArea(heights, 0, n - 1, st);
    }

    private int GetMaxArea(int[] heights, int l, int r, MinIdx_Segtree st) {
        if (l > r) return 0;
        if (l == r) return heights[l];

        int minIdx = st.Query(l, r);
        return Math.Max(
            Math.Max(GetMaxArea(heights, l, minIdx - 1, st), 
                    GetMaxArea(heights, minIdx + 1, r, st)),
                    (r - l + 1) * heights[minIdx]);
    }
}
