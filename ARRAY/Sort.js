function generateRandomNumbers() {
    let numbers = [];
    for (let i = 0; i < 10; i++) {
        numbers.push(Math.floor(Math.random() * 900) + 100);
    }
    return numbers;
}

var arr = generateRandomNumbers();
console.log(findSecondLargestAndSmallestSorted(arr))

function findSecondLargestAndSmallestSorted(arr) {
    arr.sort((a, b) => a - b);
    return { secondSmallest: arr[1], secondLargest: arr[arr.length - 2] };
}
