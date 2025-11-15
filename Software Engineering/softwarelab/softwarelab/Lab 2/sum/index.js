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

//  npm run dev