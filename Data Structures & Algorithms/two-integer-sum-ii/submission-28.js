class Solution {
/**
* @param {number[]} numbers
* @param {number} target
* @return {number[]}
*/
twoSum(numbers, target) {
let left = 0, right = (numbers.length - 1), returnData = [];

    while(left < right) {
        console.log("Here");
        let sum = numbers[left] + numbers[right];
        if (sum === target) {
            console.log("Here 1");
            returnData = [numbers[left], numbers[right]];
            break;
        } else if (sum < target) {
            console.log("Here 2");
            left++;
        } else {
            console.log("Here 3");
            right--;
        }
    }

    return returnData;
}
}