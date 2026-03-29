class Solution {
    /**
     * @param {number[]} nums
     * @param {number} k
     * @return {number[]}
     */
    maxSlidingWindow(nums, k) {
        const n = nums.length;
        const output = new Array(n - k + 1);
        const q = new Deque();
        let l = 0, r = 0;

        while (r < n) {
            while (q.length && nums[q[q.length - 1]] < nums[r]) {
                q.popBack();
            }
            q.pushBack(r);

            if (l > q[0]) {
                q.popFront();
            }

            if ((r + 1) >= k) {
                output[l] = nums[q[0]];
                l++;
            }
            r++;
        }

        return output;
    }
}