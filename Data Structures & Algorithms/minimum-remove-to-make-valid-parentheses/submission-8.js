class Solution {
    /**
     * @param {string} s
     * @return {string}
     */
    minRemoveToMakeValid(s) {
        let res = [];
        let cnt = 0;

        for (let c of s) {
            if (c === '(') {
                res.push(c);
                cnt++;
            } else if (c === ')' && cnt > 0) {
                res.push(c);
                cnt--;
            } else if (c !== ')') {
                res.push(c);
            }
        }

        let filtered = [];
        for (let i = res.length - 1; i >= 0; i--) {
            let c = res[i];
            if (c === '(' && cnt > 0) {
                cnt--;
            } else {
                filtered.push(c);
            }
        }
        return filtered.reverse().join('');
    }
}