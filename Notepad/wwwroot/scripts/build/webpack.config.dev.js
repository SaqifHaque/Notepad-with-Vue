'use strict'
const { VueLoaderPlugin } = require('vue-loader')
const path = require('path')
module.exports = {
    mode: 'development',
    entry: [
        './src/app.js'
    ],
    module: {
        rules: [{
            test: /\.vue$/,
            use: 'vue-loader'
        }]
    },
    plugins: [
        new VueLoaderPlugin()
    ]
}