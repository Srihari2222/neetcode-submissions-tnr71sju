func containsNearbyDuplicate(nums []int, k int) bool {
if (len(nums) < 1 ) {
return false
}
var mapOfNum = map[int]int{};
for i, val := range nums {
if i > k {
delete(mapOfNum, nums[i - k - 1])
}
_ , isExist := mapOfNum[val];
if (!isExist) {
mapOfNum[val] = i
} else {
if i - mapOfNum[val] <= k {
return true
}
mapOfNum[val] = i
}
}
return false
}