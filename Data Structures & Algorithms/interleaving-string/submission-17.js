class Solution {
    /**
     * @param {string} s1
     * @param {string} s2
     * @param {string} s3
     * @return {boolean}
     */
    isInterleave(s1, s2, s3) {
    
        const dfs = (i, j, k) => {
            if (k === s3.length) {
                return (i === s1.length) && (j === s2.length);
            }
            
            if (i < s1.length && s1[i] === s3[k]) {
                if (dfs(i + 1, j, k + 1)) {
                    return true;
                }
            }
            
            if (j < s2.length && s2[j] === s3[k]) {
                if (dfs(i, j + 1, k + 1)) {
                    return true;
                }
            }
            
            return false;
        }

        return dfs(0, 0, 0);
    }
}