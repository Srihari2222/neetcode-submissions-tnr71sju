public class Solution {
    public int maxProduct(int[] nums) {
        List<List<Integer>> A = new ArrayList<>();
        List<Integer> cur = new ArrayList<>();
        int res = Integer.MIN_VALUE;

        for (int num : nums) {
            res = Math.max(res, num);
            if (num == 0) {
                if (!cur.isEmpty()) A.add(cur);
                cur = new ArrayList<>();
            } else cur.add(num);
        }
        if (!cur.isEmpty()) A.add(cur);

        for (List<Integer> sub : A) {
            int negs = 0;
            for (int i : sub) {
                if (i < 0) negs++;
            }

            int prod = 1;
            int need = (negs % 2 == 0) ? negs : (negs - 1);
            negs = 0;
            for (int i = 0, j = 0; i < sub.size(); i++) {
                prod *= sub.get(i);
                if (sub.get(i) < 0) {
                    negs++;
                    while (negs > need) {
                        prod /= sub.get(j);
                        if (sub.get(j) < 0) negs--;
                        j++;
                    }
                }
                if (j <= i) res = Math.max(res, prod);
            }
        }
        return res;
    }
}