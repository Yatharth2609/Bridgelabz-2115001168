const num = parseInt(process.argv[2]);
let factorial = 1;

for (let i = 1; i <= num; i++) {
    factorial *= i;
}

console.log(`${num}! = ${factorial}`);
