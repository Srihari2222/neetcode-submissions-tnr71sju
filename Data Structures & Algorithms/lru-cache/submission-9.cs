public class LRUCache {
    private List<KeyValuePair<int, int>> cache;
    private int capacity;

    public LRUCache(int capacity) {
        this.cache = new List<KeyValuePair<int, int>>();
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        for (int i = 0; i < cache.Count; i++) {
            if (cache[i].Key == key) {
                var tmp = cache[i];
                cache.RemoveAt(i);
                cache.Add(tmp);
                return tmp.Value;
            }
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        for (int i = 0; i < cache.Count; i++) {
            if (cache[i].Key == key) {
                cache.RemoveAt(i);
                cache.Add(new KeyValuePair<int, int>(key, value));
                return;
            }
        }

        if (cache.Count == capacity) {
            cache.RemoveAt(0);
        }

        cache.Add(new KeyValuePair<int, int>(key, value));
    }
}