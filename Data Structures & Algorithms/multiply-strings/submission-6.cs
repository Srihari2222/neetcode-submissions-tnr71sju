public class Solution {
    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0") return "0";

        if (num1.Length < num2.Length) {
            return Multiply(num2, num1);
        }
        
        string res = "";
        int zero = 0;
        for (int i = num2.Length - 1; i >= 0; i--) {
            string cur = Mul(num1, num2[i], zero);
            res = Add(res, cur);
            zero++;
        }
        
        return res;
    }
    
    private string Mul(string s, char d, int zero) {
        int i = s.Length - 1, carry = 0;
        int digit = d - '0';
        var cur = new List<char>();

        while (i >= 0 || carry > 0) {
            int n = (i >= 0) ? s[i] - '0' : 0;
            int prod = n * digit + carry;
            cur.Add((char)('0' + (prod % 10)));
            carry = prod / 10;
            i--;
        }
        
        cur.Reverse();
        return new string(cur.ToArray()) + new string('0', zero);
    }

    private string Add(string num1, string num2) {
        int i = num1.Length - 1, j = num2.Length - 1, carry = 0;
        var res = new List<char>();

        while (i >= 0 || j >= 0 || carry > 0) {
            int n1 = (i >= 0) ? num1[i] - '0' : 0;
            int n2 = (j >= 0) ? num2[j] - '0' : 0;
            int total = n1 + n2 + carry;
            res.Add((char)('0' + (total % 10)));
            carry = total / 10;
            i--;
            j--;
        }
        
        res.Reverse();
        return new string(res.ToArray());
    }
}