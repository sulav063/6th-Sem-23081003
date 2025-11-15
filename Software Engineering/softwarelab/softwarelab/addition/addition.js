import {z} from 'zod';
const addschema = z.object({
    n1: z.number().int().min(1).max(100),
    n2: z.number().int().min(1).max(100),
});
export function addNumbers(n1,n2){
    const result = addschema.safeParse({n1,n2});
    if(!result.success){
        throw new Error("Invalid input");
    }
    return result.data.n1 + result.data.n2;
}

//
console.log("=== ADDING ===");
try {
  console.log("10 + 20 =", addNumbers(10, 20));     // Works
  console.log("0 + 20 =", addNumbers(0, 20));       // Throws error
  console.log("150 + 20 =", addNumbers(150, 20));   // Throws error
} catch (e) {
  console.log("Error:", e.message);
}