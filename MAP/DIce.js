function rollDie() {
    return Math.floor(Math.random() * 6) + 1;
}

function simulateDiceRolls() {
    let diceMap = new Map(); 

    for (let i = 1; i <= 6; i++) {
        diceMap.set(i, 0);
    }

    let maxRolls = 10;
    let reachedMax = false;

    while (!reachedMax) {
        let roll = rollDie();
        diceMap.set(roll, diceMap.get(roll) + 1);

        if (diceMap.get(roll) === maxRolls) {
            reachedMax = true;
        }
    }

    let maxNum = [...diceMap.entries()].reduce((a, b) => (a[1] > b[1] ? a : b));
    let minNum = [...diceMap.entries()].reduce((a, b) => (a[1] < b[1] ? a : b));

    console.log("Dice Rolls Frequency:", Object.fromEntries(diceMap));
    console.log(`Max Rolled Number: ${maxNum[0]} (Rolled ${maxNum[1]} times)`);
    console.log(`Min Rolled Number: ${minNum[0]} (Rolled ${minNum[1]} times)`);
}

simulateDiceRolls();
