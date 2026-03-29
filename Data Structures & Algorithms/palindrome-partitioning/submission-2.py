class Solution:
    
    def partition(self, s: str) -> List[List[str]]:

        def dfs(i):
            if i >= len(s):
                return [[]]  
            
            ret = []
            for j in range(i, len(s)):
                if self.isPali(s, i, j):
                    nxt = dfs(j + 1)
                    for part in nxt:
                        cur = [s[i : j + 1]] + part  
                        ret.append(cur)
            return ret
        
        return dfs(0)

    def isPali(self, s, l, r):
        while l < r:
            if s[l] != s[r]:
                return False
            l, r = l + 1, r - 1
        return True