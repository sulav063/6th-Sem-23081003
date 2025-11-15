const factorial = require("./index");

describe("factorial", () => {
  it("should calculate factorial correctly", () => {
    const response = factorial(5);
    expect(response.success).toBe(true);
    expect(response.result).toBe(120);
  });

  it("should fail for negative numbers", () => {
    const response = factorial(-1);
    expect(response.success).toBe(false);
    expect(response.message).toBe("Factorial not defined for negative numbers");
    expect(response.result).toBe(undefined);
  });
});