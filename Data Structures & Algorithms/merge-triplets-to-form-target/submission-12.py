class Solution:
    def mergeTriplets(self, A: List[List[int]], B: List[int]) -> bool:
        if len(A) == 1:
            return A[0] == B

        for i in range(3):
            found = False
            minVal = float("inf")
            for j in range(len(A)):
                minVal = min(minVal, A[j][i])
                if B[i] == A[j][i]:
                    found = True
                
            if not found:
                return False

            if B[i] == minVal:
                return False

        return True