class Solution:
    def minRemoveToMakeValid(self, s: str) -> str:
        count = 0
        stack = []

        to_remove = []

        for i, c in enumerate(s):
            if c == '(':
                count += 1
                stack.append(i)
            elif c == ')':
                count -= 1
                if count < 0:
                    count = 0
                    to_remove.append(i)
                else:
                    stack.pop()
        
        to_remove.extend(stack)
        res = []

        for i, c in enumerate(s):
            if i not in to_remove:
                res.append(s[i])

        return "".join(res)