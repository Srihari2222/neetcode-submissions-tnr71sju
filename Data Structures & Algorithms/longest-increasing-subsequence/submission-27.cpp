class SegmentTree {
public:
    int n;
    vector<int> tree;

    SegmentTree(int N) {
        n = N;
        while (n & (n - 1)) {
            n++;
        }
        tree.resize(2 * n);
    }

    void update(int i, int val) {
        tree[n + i] = val;
        int j = (n + i) >> 1;
        while (j >= 1) {
            tree[j] = max(tree[j << 1], tree[j << 1 | 1]);
            j >>= 1;
        }
    }

    int query(int l, int r) {
        if (l > r) {
            return 0;
        }
        int res = INT_MIN;
        l += n;
        r += n + 1;
        while (l < r) {
            if (l & 1) {
                res = max(res, tree[l]);
                l++;
            }
            if (r & 1) {
                r--;
                res = max(res, tree[r]);
            }
            l >>= 1;
            r >>= 1;
        }
        return res;
    }
};

class Solution {
public:
    int lengthOfLIS(vector<int>& nums) {
        vector<int> sortedArr = nums;
        sort(sortedArr.begin(), sortedArr.end());
        sortedArr.erase(unique(sortedArr.begin(), 
                        sortedArr.end()), sortedArr.end());

        vector<int> order(nums.size());
        for (int i = 0; i < nums.size(); i++) {
            order[i] = lower_bound(sortedArr.begin(), sortedArr.end(),
                                   nums[i]) - sortedArr.begin();
        }

        int n = sortedArr.size();
        SegmentTree segTree(n);

        int LIS = 0;
        for (int num : order) {
            int curLIS = segTree.query(0, num - 1) + 1;
            segTree.update(num, curLIS);
            LIS = max(LIS, curLIS);
        }
        return LIS;
    }
};