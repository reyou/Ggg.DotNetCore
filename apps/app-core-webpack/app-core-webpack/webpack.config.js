var path = require("path");
var webpack = require("webpack");

module.exports = function (env) {
    env = env || {};
    var isProd = env.NODE_ENV === "production";

    // Setup base config for all environments
    var config = {
        target: "node",
        entry: {
            main: "./Client/js/main.js"
        },
        output: {
            path: path.join(__dirname, "wwwroot/dist"),
            filename: "[name].js"
        },
        /*This option controls if and how source maps are generated.
    Use the SourceMapDevToolPlugin for a more fine grained configuration. 
    See the source-map-loader to deal with existing source maps.*/
        // https://webpack.js.org/configuration/devtool/
        /*Choose a style of source mapping to enhance the debugging process.
             These values can affect build and rebuild speed dramatically.*/
        devtool: "eval-source-map",
        /**These options change how modules are resolved. webpack provides
             reasonable defaults, but it is possible to change the resolving in
             detail. Have a look at Module Resolution for more explanation of
             how the resolver works.*/
        // https://webpack.js.org/configuration/resolve/
        resolve: {
            extensions: [".ts", ".tsx", ".js", ".jsx"]
        },
        // https://github.com/webpack-contrib/css-loader/issues/447
        node: {
            fs: "empty"
        },
        // https://webpack.js.org/plugins/provide-plugin/
        // https://webpack.js.org/plugins/provide-plugin/#usage-jquery
        //ProvidePlugin: Automatically load modules instead of having to import or require them everywhere.
        plugins: [
            new webpack.ProvidePlugin({
                $: "jquery",
                jQuery: "jquery"
            })
        ],
        // https://webpack.js.org/concepts/modules/
        /*webpack supports modules written in a variety of languages and preprocessors,
             via loaders. Loaders describe to webpack how to process non-JavaScript modules 
             and include these dependencies into your bundles. The webpack community has 
             built loaders for a wide variety of popular languages and language processors, 
             including:*/
        module: {
            rules: [
                {
                    test: /\.css?$/,
                    use: ["style-loader", "css-loader"]
                },
                {
                    test: /\.(png|jpg|jpeg|gif|svg)$/,
                    use: "url-loader?limit=25000"
                },
                {
                    test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/,
                    use: "url-loader?limit=100000"
                }
            ]
        }
    };

    // Alter config for prod environment
    if (isProd) {
        // https://webpack.js.org/configuration/devtool/
        config.devtool = "source-map";
        // https://github.com/webpack-contrib/uglifyjs-webpack-plugin
        config.plugins = config.plugins.concat([
            new webpack.optimize.UglifyJsPlugin({
                sourceMap: true
            })
        ]);
    }

    return config;
};
