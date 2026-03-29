class Solution {
    /**
     * @param {number[]} stones
     * @return {number}
     */
    lastStoneWeight(stones) {
        stones.sort((a, b) => a - b);
        let n = stones.length;

        while (n > 1) {
            let cur = stones.pop() - stones.pop();
            n -= 2;
            if (cur > 0) {
                let l = 0, r = n;
                while (l < r) {
                    let mid = Math.floor((l + r) / 2);
                    if (stones[mid] < cur) {
                        l = mid + 1;
                    } else {
                        r = mid;
                    }
                }
                let pos = l;
                n++;
                stones.push(0);
                for (let i = n - 1; i > pos; i--) {
                    stones[i] = stones[i - 1];
                }
                stones[pos] = cur;
            }
        }
        return n > 0 ? stones[0] : 0;
    }
}