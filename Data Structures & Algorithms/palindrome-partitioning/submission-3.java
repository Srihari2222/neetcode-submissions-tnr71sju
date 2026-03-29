class Solution {
    
    public List<List<String>> partition(String s) {
        return dfs(s, 0);
    }

    private List<List<String>> dfs(String s, int i) {
        if (i >= s.length()) {
            List<List<String>> base = new ArrayList<>();
            base.add(new ArrayList<>());
            return base;
        }

        List<List<String>> ret = new ArrayList<>();
        for (int j = i; j < s.length(); j++) {
            if (isPali(s, i, j)) {
                List<List<String>> nxt = dfs(s, j + 1);
                for (List<String> part : nxt) {
                    List<String> cur = new ArrayList<>();
                    cur.add(s.substring(i, j + 1));
                    cur.addAll(part);
                    ret.add(cur);
                }
            }
        }
        return ret;
    }

    private boolean isPali(String s, int l, int r) {
        while (l < r) {
            if (s.charAt(l) != s.charAt(r)) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}