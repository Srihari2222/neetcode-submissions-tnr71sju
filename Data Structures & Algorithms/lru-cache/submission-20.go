type LRUCache struct {
	capacity int
	cache    map[int]*list.Element
	list     *list.List
}

type entry struct {
	key, value int
}

func Constructor(capacity int) LRUCache {
	return LRUCache{
		capacity: capacity,
		cache:    make(map[int]*list.Element),
		list:     list.New(),
	}
}

func (this *LRUCache) Get(key int) int {
	if node, exists := this.cache[key]; exists {
		this.list.MoveToFront(node)
		return node.Value.(entry).value
	}
	return -1
}

func (this *LRUCache) Put(key int, value int) {
	if node, exists := this.cache[key]; exists {
		this.list.MoveToFront(node)
		node.Value = entry{key, value}
		return
	}

	if this.list.Len() == this.capacity {
		back := this.list.Back()
		this.list.Remove(back)
		delete(this.cache, back.Value.(entry).key)
	}

	node := this.list.PushFront(entry{key, value})
	this.cache[key] = node
}