const start = parseInt(process.argv[2]);
const end = parseInt(process.argv[3]);

console.log(`Prime numbers between ${start} and ${end}:`);
for (let num = start; num <= end; num++) {
    let isPrime = true;
    if (num < 2) continue;

    for (let i = 2; i * i <= num; i++) {
        if (num % i === 0) {
            isPrime = false;
            break;
        }
    }
    if (isPrime) console.log(num);
}
