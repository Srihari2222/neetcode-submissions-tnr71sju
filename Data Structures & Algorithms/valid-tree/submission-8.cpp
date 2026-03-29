class Solution {
public:
    bool validTree(int n, vector<vector<int>>& edges) {
        if (edges.size() > n - 1) {
            return false;
        }

        vector<vector<int>> adj(n);
        for (const auto& edge : edges) {
            adj[edge[0]].push_back(edge[1]);
            adj[edge[1]].push_back(edge[0]);
        }

        unordered_set<int> visit;
        queue<int> q;
        q.push(0);
        visit.insert(0);

        while (!q.empty()) {
            int node = q.front(); q.pop();
            for (int nei : adj[node]) {
                if (visit.count(nei)) {
                    continue;
                }
                visit.insert(nei);
                adj[nei].erase(remove(adj[nei].begin(), 
                                      adj[nei].end(), node), 
                               adj[nei].end());
                q.push(nei);
            }
        }

        return visit.size() == n;
    }
};