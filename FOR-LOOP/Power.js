const n = parseInt(process.argv[2]);

console.log(`Powers of 2 up to 2^${n}:`);
for (let i = 0; i <= n; i++) {
    console.log(`2^${i} = ${2 ** i}`);
}
