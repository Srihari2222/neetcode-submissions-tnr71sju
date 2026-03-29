/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        if (root == null) return "N";
        var res = new List<string>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (node == null) {
                res.Add("N");
            } else {
                res.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }
        return string.Join(",", res);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        var vals = data.Split(',');
        if (vals[0] == "N") return null;
        var root = new TreeNode(int.Parse(vals[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (vals[index] != "N") {
                node.left = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.left);
            }
            index++;
            if (vals[index] != "N") {
                node.right = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.right);
            }
            index++;
        }
        return root;
    }
}