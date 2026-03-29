class Solution {
    /**
     * @param {string} s
     * @return {string[][]}
     */
    partition(s) {

        const dfs = (j, i) => {
            if (i >= s.length) {
                return [[]];
            }

            const ret = [];
            for (let j = i; j < s.length; j++) {
                if (this.isPali(s, i, j)) {
                    const nxt = dfs(s, j + 1);
                    for (const part of nxt) {
                        const cur = [s.slice(i, j + 1), ...part];
                        ret.push(cur);
                    }
                }
            }
            return ret;
        };

        return dfs(0, 0);
    }

    /**
     * @param {string} s
     * @param {number} l
     * @param {number} r
     * @return {boolean}
     */
    isPali(s, l, r) {
        while (l < r) {
            if (s[l] !== s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}