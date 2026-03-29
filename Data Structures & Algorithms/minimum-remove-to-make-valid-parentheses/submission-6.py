class Solution:
    def minRemoveToMakeValid(self, s: str) -> str:
        stack_dict = dict()
        ignore_index_edge = []
        for i in range(len(s)):
            #Edge case must be a open bracket cannot be a close for the first bracket.
            if len(stack_dict) == 0 and s[i] == ")":
                ignore_index_edge.append(i)
                continue
            if s[i] == "(" or s[i] == ")":
                stack_dict[i] = s[i]
        
        stack = []
        index_val = []
        sorted_dict = dict(sorted(stack_dict.items()))
        #Now use stack to determine the correctness. 
        for key,value in sorted_dict.items():
            if value == "(":
                stack.append(value)
                index_val.append(key)
            elif value == ")" and len(stack)>0:
                stack.pop()
                index_val.pop()
            elif  value == ")":
                stack.append(value)
                index_val.append(key)



        final_removable_index = sorted(set([*index_val, *ignore_index_edge]), reverse = True)
        print(index_val)
        temp_s = list(s)
        for i in final_removable_index:
            del temp_s[i]
        print(final_removable_index)
        print(stack_dict)
        return "".join(temp_s)

