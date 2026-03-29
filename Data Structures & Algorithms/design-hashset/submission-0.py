class MyHashSet:

    def __init__(self):
        self.array = [Node(0) for _ in range(10**4)]

    def add(self, key: int) -> None:
        insertKey = key % 10**4
        if self.array[insertKey].next is None:
            self.array[insertKey].next = Node(key)
        else:
            currNode = self.array[insertKey].next
            while currNode != None:
                if currNode.value == key:
                    break
                else:
                    currNode = currNode.next

    def remove(self, key: int) -> None:
        insertKey = key % 10**4
        currNode = self.array[insertKey]
        while currNode.next:
            if currNode.next.value == key:
                currNode.next = currNode.next.next
                break
            else:
                currNode = currNode.next

    def contains(self, key: int) -> bool:
        insertKey = key % 10**4
        currNode = self.array[insertKey]
        while currNode.next:
            if currNode.next.value == key:
                return True
            else:
                currNode = currNode.next
        return False

class Node:

    def __init__(self, value):
        self.value = value
        self.next = None