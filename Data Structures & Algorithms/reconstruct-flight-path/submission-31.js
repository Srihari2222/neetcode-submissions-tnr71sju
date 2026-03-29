class Solution {
    /**
     * @param {string[][]} tickets
     * @return {string[]}
     */
    findItinerary(tickets) {
        const adj = new Map();
        tickets.sort().reverse().forEach(([src, dst]) => {
            if (!adj.has(src)) adj.set(src, []);
            adj.get(src).push(dst);
        });
        
        const res = [];
        const stack = ["JFK"];
        
        while (stack.length > 0) {
            let curr = stack[stack.length - 1];
            if (!adj.has(curr) || adj.get(curr).length === 0) {
                res.unshift(stack.pop());
            } else {
                stack.push(adj.get(curr).pop());
            }
        }
        
        return res;
    }
}