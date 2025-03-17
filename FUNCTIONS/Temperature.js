const readline = require("readline").createInterface({
    input: process.stdin,
    output: process.stdout
});

const convertTemperature = (choice, temp) => {
    switch (choice) {
        case "CtoF":
            if (temp < 0 || temp > 100) return "Temperature out of valid range (0C - 100C)";
            return `${temp}C = ${(temp * 9/5 + 32).toFixed(2)}F`;
        case "FtoC":
            if (temp < 32 || temp > 212) return "Temperature out of valid range (32F - 212F)";
            return `${temp}F = ${((temp - 32) * 5/9).toFixed(2)}C`;
        default:
            return "Invalid choice! Use 'CtoF' or 'FtoC'";
    }
};

readline.question("Enter conversion type (CtoF or FtoC): ", (choice) => {
    readline.question("Enter temperature: ", (temp) => {
        console.log(convertTemperature(choice, parseFloat(temp)));
        readline.close();
    });
});
