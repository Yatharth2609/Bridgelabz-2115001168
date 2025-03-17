const number = parseInt(process.argv[2]);

const unitMap = {
    1: "Unit",
    10: "Ten",
    100: "Hundred",
    1000: "Thousand",
    10000: "Ten Thousand",
    100000: "Lakh",
    1000000: "Ten Lakh",
    10000000: "Crore"
};

console.log(unitMap[number] || "Invalid input. Enter numbers like 1, 10, 100, 1000, etc.");
