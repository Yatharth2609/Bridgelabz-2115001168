let money = 100;
let goal = 200;
let bets = 0;
let wins = 0;

while (money > 0 && money < goal) {
    bets++;
    let betResult = Math.random() < 0.5;
    
    if (betResult) {
        money++;
        wins++;
    } else {
        money--;
    }
}

console.log(`Game Over! Final Money: Rs ${money}`);
console.log(`Total Bets Made: ${bets}`);
console.log(`Total Wins: ${wins}`);
