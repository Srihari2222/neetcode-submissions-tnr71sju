class Segment_tree {
public:
    int n;
    vector<int> A;
    vector<int> tree;
    const int NEG_INF = -1e9;

    Segment_tree(int N, vector<int>& a) {
        this->n = N;
        this->A = a;
        while (__builtin_popcount(n) != 1) {
            A.push_back(NEG_INF);
            n++;
        }
        tree.resize(2 * n);
        build();
    }

    void build() {
        for (int i = 0; i < n; i++) {
            tree[n + i] = A[i];
        }
        for (int i = n - 1; i > 0; --i) {
            tree[i] = max(tree[i << 1], tree[i << 1 | 1]);
        }
    }

    void update(int i, int val) {
        tree[n + i] = val;
        for (int j = (n + i) >> 1; j >= 1; j >>= 1) {
            tree[j] = max(tree[j << 1], tree[j << 1 | 1]);
        }
    }

    int query(int l, int r) {
        int res = NEG_INF;
        for (l += n, r += n + 1; l < r; l >>= 1, r >>= 1) {
            if (l & 1) res = max(res, tree[l++]);
            if (r & 1) res = max(res, tree[--r]);
        }
        return res;
    }
};

class Solution {
public:
    vector<int> maxSlidingWindow(vector<int>& nums, int k) {
        int n = nums.size();
        Segment_tree segTree(n, nums);
        vector<int> output;
        for (int i = 0; i <= n - k; i++) {
            output.push_back(segTree.query(i, i + k - 1));
        }
        return output;
    }
};