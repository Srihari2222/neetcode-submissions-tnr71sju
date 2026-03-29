class Solution {
    /**
     * @param {number[]} hand
     * @param {number} groupSize
     * @return {boolean}
     */
    isNStraightHand(hand, groupSize) {
        if (hand.length % groupSize !== 0) return false;

        let count = new Map();
        hand.forEach(num => count.set(num, (count.get(num) || 0) + 1));

        let q = new Queue();
        let lastNum = -1, openGroups = 0;

        Array.from(count.keys()).sort((a, b) => a - b).forEach(num => {
            if ((openGroups > 0 && num > lastNum + 1) || 
                 openGroups > count.get(num)) {
                return false;
            }

            q.push(count.get(num) - openGroups);
            lastNum = num;
            openGroups = count.get(num);

            if (q.size() === groupSize) {
                openGroups -= q.pop();
            }
        });

        return openGroups === 0;
    }
}