import { defineConfig } from 'vitest/config';

export default defineConfig({
  test: {
    setupFiles: ['./scripts/test-setup.mjs'],
    reporters: ['verbose'],
    coverage: {
      reporter: ['text', 'cobertura', 'html']
    }
  }
});
