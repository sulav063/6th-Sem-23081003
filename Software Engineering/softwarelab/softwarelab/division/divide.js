function divideNumbers(a, b) {
  if (b === 0) return { success: false, message: "Division by zero error" };
  return { success: true, result: a / b };
}

module.exports = { divideNumbers };
