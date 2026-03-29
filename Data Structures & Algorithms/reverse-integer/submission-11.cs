public class Solution {
    public int Reverse(int x) {
        int org = x;
        x = Math.Abs(x);
        char[] arr = x.ToString().ToCharArray();
        Array.Reverse(arr);
        
        long res = long.Parse(new string(arr)); 
        if (org < 0) {
            res *= -1; 
        }
        
        if (res < int.MinValue || res > int.MaxValue) {
            return 0; 
        }
        return (int)res; 
    }
}