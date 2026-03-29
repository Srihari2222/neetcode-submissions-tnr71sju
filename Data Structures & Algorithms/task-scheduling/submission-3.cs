public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (char task in tasks) {
            count[task - 'A']++;
        }
        
        List<int[]> arr = new List<int[]>();
        for (int i = 0; i < 26; i++) {
            if (count[i] > 0) {
                arr.Add(new int[] { count[i], i });
            }
        }

        int time = 0;
        List<int> processed = new List<int>();
        while (arr.Count > 0) {
            int maxi = -1;
            for (int i = 0; i < arr.Count; i++) {
                bool ok = true;
                for (int j = Math.Max(0, time - n); j < time; j++) {
                    if (j < processed.Count && processed[j] == arr[i][1]) {
                        ok = false;
                        break;
                    }
                }
                if (!ok) continue;
                if (maxi == -1 || arr[maxi][0] < arr[i][0]) {
                    maxi = i;
                }
            }
            
            time++;
            int cur = -1;
            if (maxi != -1) {
                cur = arr[maxi][1];
                arr[maxi][0]--;
                if (arr[maxi][0] == 0) {
                    arr.RemoveAt(maxi);
                }
            }
            processed.Add(cur);
        }
        return time;
    }
}