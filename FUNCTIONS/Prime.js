const isPrime = num => {
    if (num < 2) return false;
    for (let i = 2; i * i <= num; i++) {
        if (num % i === 0) return false;
    }
    return true;
};

const getPalindrome = num => parseInt(num.toString().split('').reverse().join(''));

const checkPalindromePrime = num => {
    if (!isPrime(num)) return `${num} is not a prime number.`;
    
    let palindromeNum = getPalindrome(num);
    return isPrime(palindromeNum) 
        ? `${num} and its palindrome ${palindromeNum} are both prime!` 
        : `${num} is prime, but its palindrome ${palindromeNum} is not.`;
};

console.log(checkPalindromePrime(13));  
console.log(checkPalindromePrime(23));

