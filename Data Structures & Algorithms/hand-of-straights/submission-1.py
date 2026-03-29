class Solution:
    def isNStraightHand(self, hand, groupSize):
        if len(hand) % groupSize != 0:
            return False
        count = Counter(hand)
        count = OrderedDict(sorted(count.items()))
        
        for num in count:
            while count[num] > 0:
                for i in range(num, num + groupSize):
                    if count.get(i, 0) == 0:
                        return False
                    count[i] -= 1
        return True