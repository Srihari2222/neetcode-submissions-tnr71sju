class Solution {
public:
    int reverse(int x) {
        int org = x;
        x = abs(x);
        string strX = to_string(x);
        std::reverse(strX.begin(), strX.end());
        long long res = stoll(strX); 
        if (org < 0) {
            res *= -1;
        }
        if (res < -(1LL << 31) || res > (1LL << 31) - 1) {
            return 0;
        }
        return static_cast<int>(res);
    }
};