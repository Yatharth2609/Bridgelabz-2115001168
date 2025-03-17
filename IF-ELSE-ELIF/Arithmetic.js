const a = parseFloat(process.argv[2]);
const b = parseFloat(process.argv[3]);
const c = parseFloat(process.argv[4]);

const results = [
    { operation: "a + b * c", value: a + b * c },
    { operation: "a % b + c", value: a % b + c },
    { operation: "c + a / b", value: c + a / b },
    { operation: "a * b + c", value: a * b + c }
];

const maxResult = results.reduce((max, current) => (current.value > max.value ? current : max));
const minResult = results.reduce((min, current) => (current.value < min.value ? current : min));

console.log("Results:");
results.forEach(res => console.log(`${res.operation} = ${res.value}`));
console.log(`Maximum: ${maxResult.operation} = ${maxResult.value}`);
console.log(`Minimum: ${minResult.operation} = ${minResult.value}`);
