public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        return dfs(0, 0, 0, s1, s2, s3);
    }
    
    private bool dfs(int i, int j, int k, string s1, string s2, string s3) {
        if (k == s3.Length) {
            return (i == s1.Length) && (j == s2.Length);
        }
        
        if (i < s1.Length && s1[i] == s3[k]) {
            if (dfs(i + 1, j, k + 1, s1, s2, s3)) {
                return true;
            }
        }
        
        if (j < s2.Length && s2[j] == s3[k]) {
            if (dfs(i, j + 1, k + 1, s1, s2, s3)) {
                return true;
            }
        }
        
        return false;
    }
}