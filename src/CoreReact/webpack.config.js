"use strict";

module.exports = {
    entry: "./Scripts/React/playerProfileModel.jsx",
    output: {
        filename: "./wwwroot/js/playerProfileModel.js"
    },
    devServer: {
        contentBase: ".",
        host: "localhost",
        port: 9000
    },
    module: {
        loaders: [
          { test: /\.js$/, loader: 'babel-loader', exclude: /node_modules/ },
          { test: /\.jsx$/, loader: 'babel-loader', exclude: /node_modules/ }
        ]
    }
};