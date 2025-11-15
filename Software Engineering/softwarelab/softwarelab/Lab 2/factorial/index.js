function factorial(n) {
  if (n < 0) {
    return {
      success: false,
      message: "Factorial not defined for negative numbers",
    };
  }

  let result = 1;
  for (let i = 2; i <= n; i++) {
    result *= i;
  }

  return { success: true, result: result };
}

module.exports = factorial;