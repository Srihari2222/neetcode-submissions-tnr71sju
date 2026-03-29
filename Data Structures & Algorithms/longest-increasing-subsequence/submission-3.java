public class SegmentTree {
    int n;
    int[] A;
    int[] tree;

    public SegmentTree(int N, int[] a) {
        n = N;
        while ((n & (n - 1)) != 0) {
            n++;
        }
        A = new int[n];
        tree = new int[2 * n];
        build();
    }

    void build() {
        for (int i = 0; i < A.length; i++) {
            tree[n + i] = A[i];
        }
        for (int i = n - 1; i >= 1; i--) {
            tree[i] = Math.max(tree[i << 1], tree[i << 1 | 1]);
        }
    }

    void update(int i, int val) {
        tree[n + i] = val;
        int j = (n + i) >> 1;
        while (j >= 1) {
            tree[j] = Math.max(tree[j << 1], tree[j << 1 | 1]);
            j >>= 1;
        }
    }

    int query(int l, int r) {
        if (l > r) {
            return 0;
        }
        int res = Integer.MIN_VALUE;
        l += n;
        r += n + 1;
        while (l < r) {
            if ((l & 1) != 0) {
                res = Math.max(res, tree[l]);
                l++;
            }
            if ((r & 1) != 0) {
                r--;
                res = Math.max(res, tree[r]);
            }
            l >>= 1;
            r >>= 1;
        }
        return res;
    }
}

public class Solution {
    public int lengthOfLIS(int[] nums) {
        int[] sortedArr = Arrays.stream(nums).distinct().sorted().toArray();
        int[] order = new int[nums.length];
        for (int i = 0; i < nums.length; i++) {
            order[i] = Arrays.binarySearch(sortedArr, nums[i]);
        }
        int n = sortedArr.length;
        SegmentTree segTree = new SegmentTree(n, order);

        int LIS = 0;
        for (int num : order) {
            int curLIS = segTree.query(0, num - 1) + 1;
            segTree.update(num, curLIS);
            LIS = Math.max(LIS, curLIS);
        }
        return LIS;
    }
}