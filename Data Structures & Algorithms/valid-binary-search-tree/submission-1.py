# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:
    left_check = staticmethod(lambda val, limit: val < limit) 
    right_check = staticmethod(lambda val, limit: val > limit) 

    def isValidBST(self, root: Optional[TreeNode]) -> bool:
        if not root:
            return True
        
        return (self.isValid(root.left, root.val, self.left_check) and
                self.isValid(root.right, root.val, self.right_check))

    def isValid(self, root: Optional[TreeNode], limit: int, check) -> bool:
        if not root:
            return True
        if not check(root.val, limit):
            return False
        return (self.isValid(root.left, limit, check) and
                self.isValid(root.right, limit, check))
