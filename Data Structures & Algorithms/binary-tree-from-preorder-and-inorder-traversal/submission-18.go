/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
func buildTree(preorder []int, inorder []int) *TreeNode {
    head := &TreeNode{}
    curr := head
    i, j, n := 0, 0, len(preorder)

    for i < n && j < n {
        curr.Right = &TreeNode{Val: preorder[i], Right: curr.Right}
        curr = curr.Right
        i++
        for i < n && curr.Val != inorder[j] {
            curr.Left = &TreeNode{Val: preorder[i], Right: curr}
            curr = curr.Left
            i++
        }
        j++
        for curr.Right != nil && j < n && curr.Right.Val == inorder[j] {
            prev := curr.Right
            curr.Right = nil
            curr = prev
            j++
        }
    }
    return head.Right
}