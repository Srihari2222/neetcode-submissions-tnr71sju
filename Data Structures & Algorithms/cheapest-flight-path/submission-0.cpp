const int INF = 0x3f3f3f3f;
#define ff first
#define ss second
class Solution {
public:
    int dist[101][110];
    Solution(){
        memset(dist,INF,sizeof(dist));
    }
    int findCheapestPrice(int n, vector<vector<int>>& flights, int src, int dst, int k) {
        vector<vector<pair<int,int>>> adj(n);
        for(auto& it:flights){
            adj[it[0]].push_back({it[1],it[2]});
        }
        dist[src][0]=0;
        priority_queue<array<int,3>,vector<array<int,3>>,greater<array<int,3>>> pq;
        pq.push({0,-1,src});
        int sz=1;
        while(sz){
            sz--;
            auto node=pq.top();pq.pop();
            if(node[2]==dst)return node[0];
            if(node[1]==k || dist[node[2]][node[1]+1]<node[0])continue;
            for(auto& [nei,p]:adj[node[2]]){
                int cst=node[0]+p;
                int cnt=1+node[1];
                if(dist[nei][cnt+1]>cst){
                    dist[nei][cnt+1]=cst;
                    sz++;
                    pq.push({cst,cnt,nei});
                }
            }
        }
        return -1;
    }
};