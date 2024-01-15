import { defineConfig } from 'vitest/config';

export default defineConfig({
  test: {
    globals: true,
    setupFiles: ['./scripts/test-setup.mjs'],
    reporters: ['verbose'],
    coverage: {
      reporter: ['text', 'cobertura', 'html']
    }
  }
});
