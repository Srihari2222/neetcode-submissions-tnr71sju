class Solution {
    /**
     * @param {number[]} coins
     * @param {number} amount
     * @return {number}
     */
    coinChange(coins, amount) {
        if (amount === 0) return 0;

        const q = new Queue([0]);
        const seen = new Array(amount + 1).fill(false);
        seen[0] = true;
        let res = 0;

        while (!q.isEmpty()) {
            res++;
            const size = q.size();
            for (let i = 0; i < size; i++) {
                const cur = q.pop();
                for (const coin of coins) {
                    const nxt = cur + coin;
                    if (nxt === amount) return res;
                    if (nxt > amount || seen[nxt]) continue;
                    seen[nxt] = true;
                    q.push(nxt);
                }
            }
        }

        return -1;
    }
}