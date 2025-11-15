Initialize the Project
mkdir lab
cd lab
npm init -y
npm install zod
Update package.json
  "scripts": {
    "dev": "node index.js",
  },
  "type": "module",

  ---
  
WAP that sums two number. Add validation for input.
Create file (index.js)
import { z } from "zod";

const addNumbersSchema = z.object({
  a: z.number().min(1).max(100),
  b: z.number().min(1).max(100),
});

function addNumbers(a, b) {
  const result = addNumbersSchema.safeParse({ a, b });

  if (!result.success) {
    throw new Error(
      `Invalid input: ${result.error.issues.map((e) => e.message).join(", ")}`
    );
  }

  return result.data.a + result.data.b;
}

try {
  console.log(addNumbers(1, 2));
  // console.log(addNumbers("1", 2));
  // console.log(addNumbers(150, 2));
} catch (error) {
  console.log(error.message);
}
  npm run dev

  ---
  
WAP that concats firstName, lastName and email. Add validation for input.
firstName cannot be empty
lastName cannot be empty
email should be valid
Should return in merged sentence like "Email of Bidur Sapkota is bidur@gamil.com"
Create file (index.js)
import { z } from "zod";
// const z = require("zod");

const userInfoSchema = z.object({
  firstName: z.string().min(1, "First name cannot be empty"),
  lastName: z.string().min(1, "Last name cannot be empty"),
  email: z.email("Invalid email format"),
});

function createUserSentence(firstName, lastName, email) {
  const result = userInfoSchema.safeParse({ firstName, lastName, email });

  if (!result.success) {
    throw new Error(
      `Invalid input: ${result.error.issues.map((e) => e.message).join(", ")}`
    );
  }

  return `Email of ${firstName} ${lastName} is ${email}`;
}

try {
  console.log(createUserSentence("John", "Doe", "john.doe@example.com"));
  console.log(createUserSentence("", "Doe", "invalid-email"));
} catch (error) {
  console.error(error.message);
}
  npm run dev

  ---
  ---
  
For Testing
npm install jest
Update package.json
  "scripts": {
    "test": "jest",
  },
  "type": "commonjs",
  
  ---
  
WAP that divides two number. Also add proper test cases.
success should be true for valid numbers with result
success should be false for divide by zero with proper message
Create file (index.js)
function divideNumbers(a, b) {
  if (b == 0) return { success: false, message: "Division by zero error" };

  return { success: true, result: a / b };
}

module.exports = divideNumbers;
Create file (index.test.js)
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

---

  npm run test
---

WAP that calculates factorial of given number. Also add proper test cases.
success should be true for positive numbers with result
success should be false for factorial of negative number with proper message
Create file (index.js)
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
Create file (index.test.js)
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
