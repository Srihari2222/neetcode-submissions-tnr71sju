public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) return 0;

        Queue<int> q = new Queue<int>();
        q.Enqueue(0);
        bool[] seen = new bool[amount + 1];
        seen[0] = true;
        int res = 0;

        while (q.Count > 0) {
            res++;
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                int cur = q.Dequeue();
                foreach (int coin in coins) {
                    int nxt = cur + coin;
                    if (nxt == amount) return res;
                    if (nxt > amount || seen[nxt]) continue;
                    seen[nxt] = true;
                    q.Enqueue(nxt);
                }
            }
        }

        return -1;
    }
}