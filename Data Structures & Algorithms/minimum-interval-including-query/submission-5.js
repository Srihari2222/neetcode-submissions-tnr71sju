class SegmentTree {
    constructor(N) {
        this.n = N;
        this.tree = new Array(4 * N).fill(Infinity);
        this.lazy = new Array(4 * N).fill(Infinity);
    }

    propagate(treeidx, lo, hi) {
        if (this.lazy[treeidx] !== Infinity) {
            this.tree[treeidx] = Math.min(this.tree[treeidx], this.lazy[treeidx]);
            if (lo !== hi) {
                this.lazy[2 * treeidx + 1] = Math.min(this.lazy[2 * treeidx + 1], this.lazy[treeidx]);
                this.lazy[2 * treeidx + 2] = Math.min(this.lazy[2 * treeidx + 2], this.lazy[treeidx]);
            }
            this.lazy[treeidx] = Infinity;
        }
    }

    update(treeidx, lo, hi, left, right, val) {
        this.propagate(treeidx, lo, hi);
        if (lo > right || hi < left) return;
        if (lo >= left && hi <= right) {
            this.lazy[treeidx] = Math.min(this.lazy[treeidx], val);
            this.propagate(treeidx, lo, hi);
            return;
        }
        const mid = Math.floor((lo + hi) / 2);
        this.update(2 * treeidx + 1, lo, mid, left, right, val);
        this.update(2 * treeidx + 2, mid + 1, hi, left, right, val);
        this.tree[treeidx] = Math.min(this.tree[2 * treeidx + 1], this.tree[2 * treeidx + 2]);
    }

    query(treeidx, lo, hi, idx) {
        this.propagate(treeidx, lo, hi);
        if (lo === hi) return this.tree[treeidx];
        const mid = Math.floor((lo + hi) / 2);
        if (idx <= mid) return this.query(2 * treeidx + 1, lo, mid, idx);
        else return this.query(2 * treeidx + 2, mid + 1, hi, idx);
    }

    updateRange(left, right, val) {
        this.update(0, 0, this.n - 1, left, right, val);
    }

    queryPoint(idx) {
        return this.query(0, 0, this.n - 1, idx);
    }
}

class Solution {
    /**
     * @param {number[][]} intervals
     * @param {number[]} queries
     * @return {number[]}
     */
    minInterval(intervals, queries) {
        const points = [];
        for (const interval of intervals) {
            points.push(interval[0]);
            points.push(interval[1]);
        }
        for (const q of queries) {
            points.push(q);
        }
        const uniquePoints = [...new Set(points)].sort((a, b) => a - b);
        const compress = new Map();
        uniquePoints.forEach((point, idx) => {
            compress.set(point, idx);
        });
        const segTree = new SegmentTree(uniquePoints.length);
        for (const interval of intervals) {
            const start = compress.get(interval[0]);
            const end = compress.get(interval[1]);
            const length = interval[1] - interval[0] + 1;
            segTree.updateRange(start, end, length);
        }
        const ans = [];
        for (const q of queries) {
            const idx = compress.get(q);
            const res = segTree.queryPoint(idx);
            ans.push(res === Infinity ? -1 : res);
        }
        return ans;
    }
}