func majorityElement(nums []int) int {
n := len(nums)/2
mp := map[int]int{}
for _, num := range(nums) {
mp[num] += 1
if mp[num] > n {
return num
}
}
return -1
}