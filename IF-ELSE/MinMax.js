let numbers = [];
for (let i = 0; i < 5; i++) {
    numbers[i] = Math.floor(Math.random() * 900) + 100;
}
console.log("Numbers:", numbers);
console.log("Minimum:", Math.min(...numbers));
console.log("Maximum:", Math.max(...numbers));
