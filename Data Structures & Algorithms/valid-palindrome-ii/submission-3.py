class Solution:
    def validPalindrome(self, s: str) -> bool:
        p1, p2 = 0, len(s)-1
        removed = False

        while p1<p2:
            if s[p1] != s[p2]:
                if removed:
                    return False
                if s[p1+1]==s[p2]:
                    removed=True
                    p1+=1
                elif s[p1]==s[p2-1]:
                    removed=True
                    p2-=1
                else: return False
            p1 += 1
            p2 -= 1
        return True