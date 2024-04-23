
import js from '@eslint/js';
import globals from 'globals';
import jsdoc from 'eslint-plugin-jsdoc';
import testingLibrary from 'eslint-plugin-testing-library';
import compat from 'eslint-plugin-compat';
import stylisticJs from '@stylistic/eslint-plugin-js';
import vitest from 'eslint-plugin-vitest';

/** @type {import('eslint').Linter.FlatConfig} */
const ignorePatterns = {
  ignores: ['node_modules/', '**/.*', '.eslintcache'],
};

/** @type {import('eslint').Linter.FlatConfig} */
const baseConfig = {
  files: ['scripts/*.{js,mjs}', '*.{js,mjs}'],
  languageOptions: {
    ecmaVersion: 'latest',
    sourceType: 'module',
    globals: {
      ...globals.browser
    }
  },
  plugins: {
    jsdoc,
    compat,
    '@stylistic/js': stylisticJs
  },
  rules: {
    ...js.configs.recommended.rules,
    ...jsdoc.configs.recommended.rules,
    ...compat.configs.recommended.rules,
    'eqeqeq': 'error',
    'no-extra-boolean-cast': 'off',
    'no-var': 'error',
    '@stylistic/js/indent': ['error', 2, { 'SwitchCase': 1 }],
    '@stylistic/js/linebreak-style': ['error', 'windows'],
    '@stylistic/js/quotes': ['error', 'single', { 'allowTemplateLiterals': true }],
    '@stylistic/js/semi': ['error', 'always'],
    '@stylistic/js/no-trailing-spaces': 'error',
    '@stylistic/js/no-multi-spaces': 'error',
    '@stylistic/js/space-infix-ops': 'error',
    '@stylistic/js/space-before-function-paren': ['error', 'never'],
    '@stylistic/js/space-in-parens': ['error', 'never'],
    '@stylistic/js/keyword-spacing' : ['error', {
      'after': true,
      'overrides': {
        'if': { 'after': false },
        'for': { 'after': false },
        'catch': { 'after': false },
        'while': { 'after': false }
      }
    }],
    '@stylistic/js/arrow-spacing': ['error', { 'before': true, 'after': true }],
    'jsdoc/require-param-description': 'off'
  }
};

const testConfig = {
  ...baseConfig,
  files: ['scripts/*.spec.{js,mjs}'],
  plugins: {
    ...baseConfig.plugins,
    'testing-library': testingLibrary,
    vitest
  },
  rules: {
    ...baseConfig.rules,
    ...vitest.configs.recommended.rules,
    ...testingLibrary.configs.dom.rules,
    'vitest/no-disabled-tests': 'off',
    'testing-library/no-wait-for-multiple-assertions': 'off',
    'testing-library/no-node-access': 'off'
  }
};

/** @type {import('eslint').Linter.FlatConfig[]} */
export default [
  ignorePatterns,
  baseConfig,
  testConfig
];
