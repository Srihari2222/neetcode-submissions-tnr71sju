public class Solution {
    public uint ReverseBits(uint n) {
        string binary = "";
        for (int i = 0; i < 32; i++) {
            if ((n & (1 << i)) != 0) {
                binary += "1";
            } else {
                binary += "0";
            }
        }
        
        uint res = 0;
        for (int i = 0; i < 32; i++) {
            if (binary[31 - i] == '1') { 
                res |= (1u << i);
            }
        }
        
        return res;
    }
}