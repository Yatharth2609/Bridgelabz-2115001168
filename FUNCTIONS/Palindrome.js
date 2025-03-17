const isPalindrome = num => {
    let strNum = num.toString();
    return strNum === strNum.split('').reverse().join('');
};

console.log(isPalindrome(121));
console.log(isPalindrome(123)); 
