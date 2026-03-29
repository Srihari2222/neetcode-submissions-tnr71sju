class Solution {
    /**
     * @param {number[][]} times
     * @param {number} n
     * @param {number} k
     * @return {number}
     */
    networkDelayTime(times, n, k) {
        const adj = {};
        for (let i = 1; i <= n; i++) adj[i] = [];
        for (const [u, v, w] of times) {
            adj[u].push([v, w]);
        }

        const dist = {};
        for (let i = 1; i <= n; i++) dist[i] = Infinity;
        dist[k] = 0;

        const q = new Queue([[k, 0]]);

        while (!q.isEmpty()) {
            const [node, time] = q.pop();
            for (const [nei, w] of adj[node]) {
                if (time + w < dist[nei]) {
                    dist[nei] = time + w;
                    q.push([nei, time + w]);
                }
            }
        }

        let res = Math.max(...Object.values(dist));
        return res === Infinity ? -1 : res;
    }
}