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
//  npm run dev