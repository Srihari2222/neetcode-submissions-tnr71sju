public class Solution {
    public int EvalRPN(string[] tokens) {
        List<string> tokenList = new List<string>(tokens);
        return DFS(tokenList);
    }

    public int DFS(List<string> tokens) {
        string token = tokens[tokens.Count - 1];
        tokens.RemoveAt(tokens.Count - 1);

        if (token != "+" && token != "-" &&
         token != "*" && token != "/") {
            return int.Parse(token);
        }

        int right = DFS(tokens);
        int left = DFS(tokens);

        if (token == "+") {
            return left + right;
        } else if (token == "-") {
            return left - right;
        } else if (token == "*") {
            return left * right;
        } else {
            return left / right;
        }
    }
}