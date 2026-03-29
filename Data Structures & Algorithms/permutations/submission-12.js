class Solution {
    /**
     * @param {number[]} nums
     * @return {number[][]}
     */
    permute(nums) {
        let perms = [[]];
        for (let num of nums) {
            let new_perms = [];
            for (let p of perms) {
                for (let i = 0; i <= p.length; i++) {
                    let p_copy = p.slice();
                    p_copy.splice(i, 0, num);
                    new_perms.push(p_copy);
                }
            }
            perms = new_perms;
        }
        return perms;
    }
}