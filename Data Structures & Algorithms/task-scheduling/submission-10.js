class Solution {
    /**
     * @param {character[]} tasks
     * @param {number} n
     * @return {number}
     */
    leastInterval(tasks, n) {
        const count = new Array(26).fill(0);
        for (const task of tasks) {
            count[task.charCodeAt(0) - 'A'.charCodeAt(0)]++;
        }
        
        const arr = [];
        for (let i = 0; i < 26; i++) {
            if (count[i] > 0) {
                arr.push([count[i], i]);
            }
        }

        let time = 0;
        const processed = [];
        while (arr.length > 0) {
            let maxi = -1;
            for (let i = 0; i < arr.length; i++) {
                let ok = true;
                for (let j = Math.max(0, time - n); j < time; j++) {
                    if (j < processed.length && processed[j] === arr[i][1]) {
                        ok = false;
                        break;
                    }
                }
                if (!ok) continue;
                if (maxi === -1 || arr[maxi][0] < arr[i][0]) {
                    maxi = i;
                }
            }
            
            time++;
            let cur = -1;
            if (maxi !== -1) {
                cur = arr[maxi][1];
                arr[maxi][0]--;
                if (arr[maxi][0] === 0) {
                    arr.splice(maxi, 1);
                }
            }
            processed.push(cur);
        }
        return time;
    }
}