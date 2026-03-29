class Solution {
public:
    vector<string> findItinerary(vector<vector<string>>& tickets) {
        for(auto& ticket : tickets) graph[ticket[0]].push_back(ticket[1]);
        for(auto& kv : graph) {sort(kv.second.begin(), kv.second.end());}
        totalLen = tickets.size()+1;
        helper("JFK");
        return path;
    }
private:
    int totalLen{0};
    vector<string> path;
    unordered_map<string, vector<string>> graph;
    unordered_map<string, unordered_set<int>> visited;
    bool helper(string curr) {
        path.push_back(curr);
        if(path.size() == totalLen) {return true;}
        for(int i=0; i<graph[curr].size(); i++) {
            if(visited[curr].find(i) != visited[curr].end()) continue;
            visited[curr].insert(i);
            bool tmp = helper(graph[curr][i]);
            if(tmp) return true;
            visited[curr].erase(i);
        }
        path.pop_back();
        return false;
    }
};