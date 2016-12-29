/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp");
var concat = require("gulp-concat")
var ts = require("gulp-typescript");
var tsProject = ts.createProject("tsconfig.json");

var webroot = "./src/Modular.Host/wwwroot/";

var paths = {
};


gulp.task("default", function () {

});