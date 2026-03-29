class Solution:
    def minRemoveToMakeValid(self, s: str) -> str:
        res = []
        cnt = 0  # extra ( parentheses
        for c in s:
            if c == "(":
                res.append(c)
                cnt += 1
            elif c == ")" and cnt > 0:
                res.append(c)
                cnt -= 1
            elif c != ")":
                res.append(c)

        filtered = []
        for c in reversed(res):
            if c == "(" and cnt > 0:
                cnt -= 1
            else:
                filtered.append(c)
        return "".join(reversed(filtered))