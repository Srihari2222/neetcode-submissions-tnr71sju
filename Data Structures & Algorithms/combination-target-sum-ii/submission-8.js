class Solution {
    constructor() {
        this.res = new Set();
    }

    /**
     * @param {number[]} candidates
     * @param {number} target
     * @return {number[][]}
     */
    combinationSum2(candidates, target) {
        this.res.clear();
        candidates.sort((a, b) => a - b);
        this.generateSubsets(candidates, target, 0, [], 0);
        return Array.from(this.res, subset => JSON.parse(subset));
    }

    /**
     * @param {number[]} candidates
     * @param {number} target
     * @param {number} i
     * @param {number[]} cur
     * @param {number} total
     * @return {void}
     */
    generateSubsets(candidates, target, i, cur, total) {
        if (total === target) {
            this.res.add(JSON.stringify([...cur]));
            return;
        }
        if (total > target || i === candidates.length) {
            return;
        }

        cur.push(candidates[i]);
        this.generateSubsets(candidates, target, i + 1, cur, total + candidates[i]);
        cur.pop();

        this.generateSubsets(candidates, target, i + 1, cur, total);
    }
}