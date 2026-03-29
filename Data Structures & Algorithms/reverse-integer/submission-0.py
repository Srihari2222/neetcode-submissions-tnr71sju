class Solution:
    def reverse(self, x: int) -> int:
        digits = []
        num = x
        x = abs(x)
        while x:
            digits.append(x % 10);
            x //= 10
        res = 0
        for d in digits:
            res *= 10
            res += d
        
        res = -res if num < 0 else res
        if res < (-(1 << 31)) or res > (1 << 31):
            res = 0
        return res