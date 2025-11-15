const divideNumbers = require("./index");

describe("divideNumbers", () => {
  it("should divide two valid numbers correctly", () => {
    const response = divideNumbers(10, 2);
    expect(response.success).toBe(true);
    expect(response.result).toBe(5);
  });
  it("should fail for divide by 0", () => {
    const response = divideNumbers(10, 0);
    expect(response.success).toBe(false);
    expect(response.message).toBe("Division by zero error");
    expect(response.result).toBe(undefined);
  });
});

//  npm run test