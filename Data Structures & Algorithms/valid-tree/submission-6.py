class Solution:
    def validTree(self, n: int, edges: List[List[int]]) -> bool:
        if len(edges) > n - 1:
            return False
        
        adj = [[] for _ in range(n)]
        for u, v in edges:
            adj[u].append(v)
            adj[v].append(u)
        
        visit = set()
        q = deque([0])
        visit.add(0)
        
        while q:
            node = q.popleft()
            for nei in adj[node]:
                if nei in visit:
                    continue
                visit.add(nei)
                adj[nei].remove(node)
                q.append(nei)
        
        return len(visit) == n