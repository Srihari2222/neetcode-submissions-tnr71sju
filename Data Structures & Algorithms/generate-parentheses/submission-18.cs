public class Solution {
    public List<string> GenerateParenthesis(int n) {
        List<List<string>> res = new List<List<string>>();
        for (int i = 0; i <= n; i++) {
            res.Add(new List<string>());
        }
        res[0].Add("");

        for (int k = 0; k <= n; k++) {
            for (int i = 0; i < k; i++) {
                foreach (string left in res[i]) {
                    foreach (string right in res[k - i - 1]) {
                        res[k].Add("(" + left + ")" + right);
                    }
                }
            }
        }

        return res[n];
    }
}