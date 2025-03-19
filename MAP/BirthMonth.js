function generateBirthdays() {
    let birthdayMap = new Map();

    for (let i = 1; i <= 12; i++) {
        birthdayMap.set(i, []);
    }

    for (let i = 1; i <= 50; i++) {
        let month = Math.floor(Math.random() * 12) + 1; 
        birthdayMap.get(month).push(`Person ${i}`);
    }

    console.log("Birthdays grouped by month:");
    for (let [month, people] of birthdayMap) {
        console.log(`Month ${month}: ${people.length} individuals`);
    }
}

generateBirthdays();
