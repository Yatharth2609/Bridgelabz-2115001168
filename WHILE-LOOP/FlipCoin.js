let headsCount = 0, tailsCount = 0;

while (headsCount < 11 && tailsCount < 11) {
    let flip = Math.random() < 0.5 ? "Heads" : "Tails";
    
    if (flip === "Heads") headsCount++;
    else tailsCount++;
    
    console.log(flip);
}

console.log(`Game Over! ${headsCount === 11 ? "Heads" : "Tails"} wins 11 times.`);
