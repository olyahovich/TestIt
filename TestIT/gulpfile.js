/// <binding BeforeBuild='build' />
"use strict";

var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    htmlmin = require("gulp-htmlmin"),
    uglify = require("gulp-uglify"),
    merge = require("merge-stream"),
    del = require("del"),
    sass = require('gulp-sass'),
    bundleconfig = require("./bundleconfig.json");

var regex = {
    css: /\.css$/,
    html: /\.(html|htm)$/,
    js: /\.js$/
};

var lib = "./wwwroot/";

var paths = {
    npm: './node_modules/',
    jsVendors: lib + 'js',
    jsRxJSVendors: lib + 'js/rxjs',
    cssVendors: lib + 'css',
    imgVendors: lib + 'images',
    fontsVendors: lib + 'fonts'
};

gulp.task("build", ["min", "setup_fonts"]);

gulp.task("min", ["min:js", "min:css", "min:html"]);

gulp.task("min:js", function () {
    var tasks = getBundles(regex.js).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(uglify())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:css", function () {

    var scsstasks = gulp.src(['./styles/*.scss'])
        .pipe(sass().on('error', sass.logError))
        .pipe(concat('scss-files.scss'));

    var csstasks = getBundles(regex.css).map(function(bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat('css-files.css'));
    });

    var mergedstream = merge(scsstasks, csstasks)
        .pipe(concat('site.min.css'))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.cssVendors));
    return mergedstream;
});

gulp.task("min:html", function () {
    var tasks = getBundles(regex.html).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(htmlmin({ collapseWhitespace: true, minifyCSS: true, minifyJS: true }))
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("clean", function () {
    var files = bundleconfig.map(function (bundle) {
        return bundle.outputFileName;
    });

    return del(files);
});

gulp.task("setup_fonts",function (done) {
    gulp.src([
        'node_modules/material-design-icons/iconfont/MaterialIcons-Regular.eot',
        'node_modules/material-design-icons/iconfont/MaterialIcons-Regular.svg',
        'node_modules/material-design-icons/iconfont/MaterialIcons-Regular.ttf',
        'node_modules/material-design-icons/iconfont/MaterialIcons-Regular.woff',
        'node_modules/material-design-icons/iconfont/MaterialIcons-Regular.woff2'
    ]).pipe(gulp.dest(paths.fontsVendors));
});

gulp.task("watch", function () {
    getBundles(regex.js).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:js"]);
    });

    getBundles(regex.css).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:css"]);
    });

    getBundles(regex.html).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:html"]);
    });
});

function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}