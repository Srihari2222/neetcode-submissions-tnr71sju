class Solution {
    public List<String> generateParenthesis(int n) {
        List<String> res = new ArrayList<>();

        boolean valid(String s) {
            int open = 0;
            for (char c : s.toCharArray()) {
                open += c == '(' ? 1 : -1;
                if (open < 0) return false;
            }
            return open == 0;
        }

        void dfs(String s) {
            if (n * 2 == s.length()) {
                if (valid(s)) res.add(s);
                return;
            }
            dfs(s + '(');
            dfs(s + ')');
        }

        dfs("");
        return res;
    }
}