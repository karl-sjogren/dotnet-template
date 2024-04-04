/* global __dirname, process */
import { resolve } from 'node:path';
import { defineConfig } from 'vite';
import mkcert from 'vite-plugin-mkcert';
import browserslist from 'browserslist';
import { resolveToEsbuildTarget } from 'esbuild-plugin-browserslist';
import copy from 'rollup-plugin-copy';
import { visualizer } from 'rollup-plugin-visualizer'; // eslint-disable-line no-unused-vars
import { codecovVitePlugin } from '@codecov/vite-plugin';

const esBuildTarget = resolveToEsbuildTarget(browserslist(), {
  printUnknownTargets: false
});

export default defineConfig({
  plugins: [
    mkcert(),
    copy({
      hook: 'buildStart',
      targets: [
        { src: 'static/**/*', dest: resolve(__dirname, '../BASE_NAME.Web/wwwroot/static') }
      ]
    }),
    codecovVitePlugin({
      enableBundleAnalysis: process.env.CODECOV_TOKEN !== undefined,
      bundleName: 'script-bundle',
      uploadToken: process.env.CODECOV_TOKEN
    })
  ],
  build: {
    target: esBuildTarget,
    cssCodeSplit: false,
    outDir: resolve(__dirname, '../BASE_NAME.Web/wwwroot//'),
    emptyOutDir: false,
    assetsDir: 'assets',
    reportCompressedSize: true,
    manifest: true,
    sourcemap: true,
    modulePreload: {
      polyfill: false
    },
    rollupOptions: {
      input: resolve(__dirname, 'scripts/index.mjs'),
      plugins: [
        /*visualizer({
          emitFile: true
        })*/
      ]
    }
  },
  server: {
    port: 5010,
    origin: `https://127.0.0.1:5010`,
    https: true,
    strictPort: true
  }
});
