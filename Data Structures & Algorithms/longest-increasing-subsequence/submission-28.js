class SegmentTree {
    constructor(N, a) {
        this.n = N;
        while ((this.n & (this.n - 1)) !== 0) {
            this.n++;
        }
        this.tree = new Array(2 * this.n).fill(0);
    }

    /**
     * @param {number} i
     * @param {number} val
     */
    update(i, val) {
        this.tree[this.n + i] = val;
        let j = (this.n + i) >> 1;
        while (j >= 1) {
            this.tree[j] = Math.max(this.tree[j << 1], this.tree[j << 1 | 1]);
            j >>= 1;
        }
    }

    /**
     * @param {number} l
     * @param {number} r
     * @return {number}
     */
    query(l, r) {
        if (l > r) {
            return 0;
        }
        let res = -Infinity;
        l += this.n;
        r += this.n + 1;
        while (l < r) {
            if (l & 1) {
                res = Math.max(res, this.tree[l]);
                l++;
            }
            if (r & 1) {
                r--;
                res = Math.max(res, this.tree[r]);
            }
            l >>= 1;
            r >>= 1;
        }
        return res;
    }
}

class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    lengthOfLIS(nums) {
        const sortedArr = Array.from(new Set(nums)).sort((a, b) => a - b);
        const map = new Map();
        
        sortedArr.forEach((num, index) => {
            map.set(num, index);
        });
        
        const order = nums.map(num => map.get(num));
        const n = sortedArr.length;
        const segTree = new SegmentTree(n, order);

        let LIS = 0;
        for (const num of order) {
            const curLIS = segTree.query(0, num - 1) + 1;
            segTree.update(num, curLIS);
            LIS = Math.max(LIS, curLIS);
        }
        return LIS;
    }
}