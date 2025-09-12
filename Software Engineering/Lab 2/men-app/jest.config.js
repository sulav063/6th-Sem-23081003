/** @type {import('jest').Config} */
const config = {
  clearMocks: true,
  collectCoverage: true,
  coverageDirectory: "coverage",
  coverageProvider: "v8",
  testEnvironment: "node",
  rootDir: "./",
  setupFilesAfterEnv: ["<rootDir>/src/tests/setup.ts"],
  testMatch: [
    "<rootDir>/src/tests/**/*.test.ts",
    "<rootDir>/src/tests/**/*.spec.ts"
  ],
  moduleFileExtensions: ["ts", "js", "json", "node"],
  transform: {
    "^.+\\.ts$": "ts-jest"
  }
};

module.exports = config;
