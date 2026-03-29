class MaxHeap {
    constructor(k) {
        this.heap = [Infinity];
        this.size = 0;
    }

    percolateUp() {
        let i = this.heap.length - 1;
        while (i > 1 && this.heap[Math.floor(i / 2)].val < this.heap[i].val) {
            const parent = Math.floor(i / 2);
            const temp = this.heap[i];
            this.heap[i] = this.heap[parent];
            this.heap[parent] = temp;
            i = parent;
        }
    }

    percolateDown() {
        let i = 1;
        while (2 * i < this.heap.length) {
            const l = 2 * i;
            const r = 2 * i + 1;
            if (
                r < this.heap.length && 
                this.heap[r].val > this.heap[l].val && 
                this.heap[r].val > this.heap[i].val) {
                    const temp = this.heap[i];
                    this.heap[i] = this.heap[r];
                    this.heap[r] = temp;
                    i = r;
            } else if (this.heap[l].val > this.heap[i].val) {
                const temp = this.heap[i];
                this.heap[i] = this.heap[l];
                this.heap[l] = temp;
                i = l;
            } else {
                break;
            }
        }
    }

    values() {
        return this.heap;
    }

    push(obj) {
        this.heap.push(obj);
        this.percolateUp();
        this.size++;
    }

    pop() {
        if (this.heap.length <= 2) return this.heap[1] || -Infinity;
        const res = this.heap[1];
        this.heap[1] = this.heap.pop();
        this.percolateDown();
        this.size--;
        return res;
    }

    peek() { return this.heap[1]; }
}

class Solution {
    /**
     * @param {number[][]} points
     * @param {number} k
     * @return {number[][]}
     */
    kClosest(points, k) {
        const heap = new MaxHeap(k);
        for (const p of points) {
            const distance = Math.pow(p[1], 2) + Math.pow(p[0], 2);
            
            heap.push({key: p.join(','), val: distance});
            if (heap.size === k + 1) heap.pop();
        }

        const res = [];
        for (let i = 0; i < k; i++) {
            const key = heap.pop()?.key;
            if (!key) continue;

            res.push(key.split(','));
        }
        return res;
    }
}