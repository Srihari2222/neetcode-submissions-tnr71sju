public class Solution {
    public int LastStoneWeight(int[] stones) {
        List<int> stoneList = new List<int>(stones);
        while (stoneList.Count > 1) {
            stoneList.Sort();
            int cur = stoneList[stoneList.Count - 1] - stoneList[stoneList.Count - 2];
            stoneList.RemoveAt(stoneList.Count - 1); 
            stoneList.RemoveAt(stoneList.Count - 1); 
            if (cur != 0) {
                stoneList.Add(cur); 
            }
        }

        return stoneList.Count == 0 ? 0 : stoneList[0];
    }
}