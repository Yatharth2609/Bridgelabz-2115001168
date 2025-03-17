const num = parseInt(process.argv[2]);
let isPrime = true;

if (num < 2) {
    isPrime = false;
} else {
    for (let i = 2; i * i <= num; i++) {
        if (num % i === 0) {
            isPrime = false;
            break;
        }
    }
}

console.log(`${num} is ${isPrime ? "a Prime" : "not a Prime"} number.`);
