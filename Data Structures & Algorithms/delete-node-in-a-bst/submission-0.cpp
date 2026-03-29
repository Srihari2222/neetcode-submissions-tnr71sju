/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    TreeNode* getSuccessor(TreeNode* root) {
        // assuming root and root->right are not null
        TreeNode* cur = root->right;
        while(cur->left) {
            cur = cur->left;
        }
        return cur;
    }

    TreeNode* deleteNode(TreeNode* root, int key) {
        if(root == nullptr) return root;

        if(key < root->val) {
            root->left = deleteNode(root->left, key);
        }
        else if(key > root->val) {
            root->right = deleteNode(root->right, key);
        }
        else {
            if(root->right) {
                // Incorrect code, orphans a section of the tree
                TreeNode* newRoot = getSuccessor(root);
                newRoot->left = root->left;
                delete root;
                root = newRoot;

                // == Should be ==
                // TreeNode* suc = getSuccessor(root);
                // TreeNode* right = root->right;
                // suc->left = root->left;
                // delete root;
                // root = right;
            }
            else {
                TreeNode* newRoot = root->left;
                delete root;
                root = newRoot;
            }
        }

        return root;
    }
};