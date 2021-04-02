// In the JavaScript file, write a program to perform a GET request on the route https://coderbyte.com/api/challenges/json/age-counting
// which contains a data key and the value is a string which contains items in the format: key=STRING, age=INTEGER. Your goal is to count
// how many items exist that have an age equal to or greater than 50, and print this final value.

// Example Input
// {"data":"key=IAfpK, age=58, key=WNVdi, age=64, key=jp9zt, age=47"}

// Example Output
// 2

const https = require('https');

const getAges = (str) => {
  let regex = /age=(\d\d)/gm;
  let res = str.match(regex);
  res = res.map((el) => {
    return parseInt(el.slice(el.length - 2));
  });
  return res;
};

https.get('https://coderbyte.com/api/challenges/json/age-counting', (resp) => {
  let data = '';
  resp.on('data', (chunk) => {
    data += chunk;
  });

  resp.on('end', () => {
    data = JSON.parse(data);
    let res = getAges(data.data);
    // res = res.reduce((a,c) => {if (c > 50){a= a +1}},0)
    let num = 0;
    for (item of res) {
      if (item >= 50) {
        num++;
      }
    }
    console.log(num);
  });
});