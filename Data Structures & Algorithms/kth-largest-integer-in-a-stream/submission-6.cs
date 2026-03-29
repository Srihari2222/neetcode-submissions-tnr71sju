public class KthLargest {
    private List<int> arr;
    private int K;

    public KthLargest(int k, int[] nums) {
        arr = new List<int>(nums);
        K = k;
    }

    public int Add(int val) {
        arr.Add(val);
        arr.Sort();
        return arr[arr.Count - K];
    }
}