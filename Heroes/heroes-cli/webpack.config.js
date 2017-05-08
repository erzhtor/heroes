var path = require('path');

module.exports = {
    entry: './src/main.ts',
    output: {
        filename: 'build.js',
        path: path.resolve(__dirname, '')
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                loader: 'ts-loader',
                exclude: /node_modules|vue/,
                options: {
                    appendTsSuffixTo: [/\.vue$/]
                }
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    esModule: true
                }
            },
            {
                test: /\.html$/,
                loader: 'html-loader',
                options: {
                    minimize: true
                }
            }
        ]
    },
    resolve: {
        extensions: [".tsx", ".ts", ".js", "vue"],
        alias: {
            'vue$': 'vue/dist/vue'
        }
    },
    devtool: 'source-map',
    devServer: {
        proxy: {
            '/api': {
                target: 'http://localhost:2114/',
                secure: false
            }
        },
        historyApiFallback: true,
        contentBase: './',
        watchOptions: {
            aggregateTimeout: 300,
            poll: 1000
        },
    }
};
