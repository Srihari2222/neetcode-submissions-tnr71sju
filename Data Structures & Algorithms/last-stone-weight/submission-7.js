class Solution {
    /**
     * @param {number[]} stones
     * @return {number}
     */
    lastStoneWeight(stones) {
        while (stones.length > 1) {
            stones.sort((a, b) => a - b);
            let cur = stones.pop() - stones.pop();
            if (cur) {
                stones.push(cur);
            }
        }
        return stones.length ? stones[0] : 0;
    }
}