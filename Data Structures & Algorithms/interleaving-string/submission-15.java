public class Solution {
    public boolean isInterleave(String s1, String s2, String s3) {
        
        return dfs(0, 0, 0, s1, s2, s3);
    }
    
    private boolean dfs(int i, int j, int k, String s1, String s2, String s3) {
        if (k == s3.length()) {
            return (i == s1.length()) && (j == s2.length());
        }
        
        if (i < s1.length() && s1.charAt(i) == s3.charAt(k)) {
            if (dfs(i + 1, j, k + 1, s1, s2, s3)) {
                return true;
            }
        }
        
        if (j < s2.length() && s2.charAt(j) == s3.charAt(k)) {
            if (dfs(i, j + 1, k + 1, s1, s2, s3)) {
                return true;
            }
        }
        
        return false;
    }
}