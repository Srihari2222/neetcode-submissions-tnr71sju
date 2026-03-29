class Solution:
    def minRemoveToMakeValid(self, s: str) -> str:
        l = list(s)

        st = []

        for i in range(len(l)):
            if l[i] == '(':
                st.append(i)
            elif l[i] == ')':
                if st:
                    st.pop()
                else:
                    l[i] = ''

        while st:
            i = st.pop()
            l[i] = ''
        return ''.join(l)