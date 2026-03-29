class Solution {
public:
    int networkDelayTime(vector<vector<int>>& times, int n, int k) {
        int inf = INT_MAX / 2;
        vector<vector<int>> dist(n, vector<int>(n, inf));
        
        for (int i = 0; i < n; i++)
            dist[i][i] = 0;
        
        for (auto& time : times) {
            int u = time[0] - 1, v = time[1] - 1, w = time[2];
            dist[u][v] = w;
        }
        
        for (int mid = 0; mid < n; mid++)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dist[i][j] = min(dist[i][j], 
                                     dist[i][mid] + dist[mid][j]);
        
        int res = *max_element(dist[k-1].begin(), dist[k-1].end());
        return res == inf ? -1 : res;
    }
};