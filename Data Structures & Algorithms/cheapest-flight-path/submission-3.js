class Solution {
    /**
     * @param {number} n
     * @param {number[][]} flights
     * @param {number} src
     * @param {number} dst
     * @param {number} k
     * @return {number}
     */
    findCheapestPrice(n, flights, src, dst, k) {
        const INF = Infinity;
        const adj = Array.from({ length: n }, () => []);
        const dist = Array.from({ length: n }, () => 
                     Array(k + 5).fill(INF));
        
        for (let [u, v, cst] of flights) {
            adj[u].push([v, cst]);
        }
        
        dist[src][0] = 0;
        const minHeap = new MinPriorityQueue(); // cost, node, stops
        minHeap.push([0, src, -1]);
        while (!minHeap.isEmpty()) {
            const [cst, node, stops] = minHeap.pop();
            if (node === dst) return cst;
            if (stops === k || dist[node][stops + 1] < cst) continue;
            for (let [nei, w] of adj[node]) {
                const nextCst = cst + w;
                const nextStops = stops + 1;
                if (dist[nei][nextStops + 1] > nextCst) {
                    dist[nei][nextStops + 1] = nextCst;
                    minHeap.push([nextCst, nei, nextStops]);
                }
            }
        }
        return -1;
    }
}
