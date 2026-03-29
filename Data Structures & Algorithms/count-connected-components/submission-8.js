class Solution {
    /**
     * @param {number} n
     * @param {number[][]} edges
     * @returns {number}
     */
    countComponents(n, edges) {
        const adj = Array.from({ length: n }, () => []);
        const visit = Array(n).fill(false);

        for (const [u, v] of edges) {
            adj[u].push(v);
            adj[v].push(u);
        }

        const bfs = (node) => {
            const q = new Queue([node]);
            visit[node] = true;
            while (!q.isEmpty()) {
                const cur = q.pop();
                for (const nei of adj[cur]) {
                    if (!visit[nei]) {
                        visit[nei] = true;
                        q.push(nei);
                    }
                }
            }
        };

        let res = 0;
        for (let node = 0; node < n; node++) {
            if (!visit[node]) {
                bfs(node);
                res++;
            }
        }
        return res;
    }
}