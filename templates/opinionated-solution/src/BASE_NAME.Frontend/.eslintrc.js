// eslint-disable-next-line no-undef
module.exports = {
  'root': true,
  'env': {
    'browser': true,
    'es2021': true
  },
  'parserOptions': {
    'ecmaVersion': 'latest',
    'sourceType': 'module'
  },
  'plugins': ['testing-library', 'jsdoc', 'compat', '@stylistic/js'],
  'extends': ['eslint:recommended', 'plugin:jsdoc/recommended', 'plugin:compat/recommended'],
  'rules': {
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
  },
  'overrides': [
    {
      'plugins': ['vitest', 'testing-library'],
      'extends': ['plugin:vitest/recommended', 'plugin:testing-library/dom'],
      'files': ['scripts/**/*.spec.{js,mjs}'],
      'rules': {
        'vitest/no-disabled-tests': 'off',
        'testing-library/no-wait-for-multiple-assertions': 'off',
        'testing-library/no-node-access': 'off'
      }
    }
  ]
};
