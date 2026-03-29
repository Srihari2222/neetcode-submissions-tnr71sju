public class Solution {
    public int ClimbStairs(int n) {     
        return Dfs(n, 0);
    }

    public int Dfs(int n, int i) {
        if (i >= n) return i == n ? 1 : 0;
        return Dfs(n, i + 1) + Dfs(n, i + 2);
    }
}