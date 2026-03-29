public class Solution {
    private Dictionary<string, List<string>> adj;
    private List<string> res = new List<string>();
    
    public List<string> FindItinerary(List<List<string>> tickets) {
        adj = new Dictionary<string, List<string>>();
        var sortedTickets = tickets.OrderByDescending(t => t[1]).ToList();
        foreach (var ticket in sortedTickets) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }
        
        Dfs("JFK");
        res.Reverse();
        return res;
    }
    
    private void Dfs(string src) {
        while (adj.ContainsKey(src) && adj[src].Count > 0) {
            var dst = adj[src][adj[src].Count - 1];
            adj[src].RemoveAt(adj[src].Count - 1);
            Dfs(dst);
        }
        res.Add(src);
    }
}