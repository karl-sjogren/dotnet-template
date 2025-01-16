import { defineConfig } from 'vitest/config';

export default defineConfig({
  test: {
    setupFiles: ['./scripts/test-setup.mjs'],
    reporters: ['dot'],
    environment: 'jsdom',
    isolate: false,
    coverage: {
      reporter: ['text', 'cobertura', 'html']
    }
  }
});
