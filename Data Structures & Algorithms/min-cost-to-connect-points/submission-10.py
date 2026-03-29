class Solution:
    def minCostConnectPoints(self, points: List[List[int]]) -> int:
        n, node = len(points), 0
        dist = [100000000] * n
        edges, res = 1, 0

        while edges < n:
            dist[node] = float('inf')
            nextNode = node
            for i in range(n):
                if i == node:
                    continue
                curDist = (abs(points[i][0] - points[node][0]) + 
                       abs(points[i][1] - points[node][1]))
                dist[i] = min(dist[i], curDist)
                if dist[i] < dist[nextNode]:
                    nextNode = i
            res += dist[nextNode]
            node = nextNode
            edges += 1
        return res