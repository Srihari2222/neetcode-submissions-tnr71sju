public class Solution {
    public int EvalRPN(string[] tokens) {
        List<string> tokenList = new List<string>(tokens);
        
        while (tokenList.Count > 1) {
            for (int i = 0; i < tokenList.Count; i++) {
                if ("+-*/".Contains(tokenList[i])) {
                    int a = int.Parse(tokenList[i - 2]);
                    int b = int.Parse(tokenList[i - 1]);
                    int result = 0;
                    switch (tokenList[i]) {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "*":
                            result = a * b;
                            break;
                        case "/":
                            result = a / b;
                            break;
                    }
                    tokenList.RemoveRange(i - 2, 3);
                    tokenList.Insert(i - 2, result.ToString());
                    break;
                }
            }
        }
        return int.Parse(tokenList[0]);
    }
}