class Solution:
    def minRemoveToMakeValid(self, s: str) -> str:
        #track positions of all parens, then find midpoint of each set
        #this dosen't work becusuase you could have (bbep)(ppe)
        #pair off each paren and you are left with any outliers
        invalid = set()
        res = ""
        stack = []

        for i, c in enumerate(s):
            if c == "(":
                stack.append(i)
            elif c == ")":
                if not stack:
                    invalid.add(i)
                else:
                    stack.pop()

        invalid.update(stack)
        
        result = []
        for i, char in enumerate(s):
            if i not in invalid:
                result.append(char)
        
        return ''.join(result)
        
        return res