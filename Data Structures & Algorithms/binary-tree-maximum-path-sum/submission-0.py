# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:
    def maxPathSum(self, root: Optional[TreeNode]) -> int:
        if not root:
            return 0

        left = self.getMax(root.left)
        right = self.getMax(root.right)
        cur = max(0, root.val + left + right)
        res = max(self.maxPathSum(root.left), self.maxPathSum(root.right))
        return max(res, cur)
            
    def getMax(self, root: Optional[TreeNode]) -> int:
        if not root:
            return 0
        
        left = self.getMax(root.left)
        right = self.getMax(root.right)
        path = root.val + max(left, right)
        return max(0, path)