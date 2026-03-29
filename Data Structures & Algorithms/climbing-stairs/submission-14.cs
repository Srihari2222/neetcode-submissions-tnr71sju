public class Solution {
    int[] cache;
    public int ClimbStairs(int n) { 
        cache = new int[n];
        for (int i = 0; i < n; i++) {
            cache[i] = -1;
        }    
        return Dfs(n, 0);
    }

    public int Dfs(int n, int i) {
        if (i >= n) return i == n ? 1 : 0;
        if (cache[i] != -1) return cache[i];
        return cache[i] = Dfs(n, i + 1) + Dfs(n, i + 2);
    }
}