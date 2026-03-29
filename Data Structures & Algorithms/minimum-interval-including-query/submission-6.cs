public class SegmentTree {
    public int n;
    public int[] tree;
    public int[] lazy;

    public SegmentTree(int N) {
        this.n = N;
        tree = new int[4 * N];
        lazy = new int[4 * N];
        Array.Fill(tree, int.MaxValue);
        Array.Fill(lazy, int.MaxValue);
    }

    public void Propagate(int treeidx, int lo, int hi) {
        if (lazy[treeidx] != int.MaxValue) {
            tree[treeidx] = Math.Min(tree[treeidx], lazy[treeidx]);
            if (lo != hi) {
                lazy[2 * treeidx + 1] = Math.Min(lazy[2 * treeidx + 1], lazy[treeidx]);
                lazy[2 * treeidx + 2] = Math.Min(lazy[2 * treeidx + 2], lazy[treeidx]);
            }
            lazy[treeidx] = int.MaxValue;
        }
    }

    public void Update(int treeidx, int lo, int hi, int left, int right, int val) {
        Propagate(treeidx, lo, hi);
        if (lo > right || hi < left) return;
        if (lo >= left && hi <= right) {
            lazy[treeidx] = Math.Min(lazy[treeidx], val);
            Propagate(treeidx, lo, hi);
            return;
        }
        int mid = (lo + hi) / 2;
        Update(2 * treeidx + 1, lo, mid, left, right, val);
        Update(2 * treeidx + 2, mid + 1, hi, left, right, val);
        tree[treeidx] = Math.Min(tree[2 * treeidx + 1], tree[2 * treeidx + 2]);
    }

    public int Query(int treeidx, int lo, int hi, int idx) {
        Propagate(treeidx, lo, hi);
        if (lo == hi) return tree[treeidx];
        int mid = (lo + hi) / 2;
        if (idx <= mid) return Query(2 * treeidx + 1, lo, mid, idx);
        else return Query(2 * treeidx + 2, mid + 1, hi, idx);
    }

    public void Update(int left, int right, int val) {
        Update(0, 0, n - 1, left, right, val);
    }

    public int Query(int idx) {
        return Query(0, 0, n - 1, idx);
    }
}

public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        List<int> points = new List<int>();
        foreach (var interval in intervals) {
            points.Add(interval[0]);
            points.Add(interval[1]);
        }
        foreach (var q in queries) {
            points.Add(q);
        }
        points.Sort();
        points = new List<int>(new HashSet<int>(points));
        Dictionary<int, int> compress = new Dictionary<int, int>();
        for (int i = 0; i < points.Count; i++) {
            compress[points[i]] = i;
        }
        SegmentTree segTree = new SegmentTree(points.Count);
        foreach (var interval in intervals) {
            int start = compress[interval[0]];
            int end = compress[interval[1]];
            int length = interval[1] - interval[0] + 1;
            segTree.Update(start, end, length);
        }
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            int idx = compress[queries[i]];
            int res = segTree.Query(idx);
            ans[i] = (res == int.MaxValue) ? -1 : res;
        }
        return ans;
    }
}