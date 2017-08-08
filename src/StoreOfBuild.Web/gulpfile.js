var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');
var browserSync = require('browser-sync').create();

gulp.task('browser-sync', function(){

    browserSync.init({
        proxy: 'localhost:5000'
    });

    gulp.watch('./style/*.css', ['css']);
    gulp.watch('./js/*.js', ['js']);
});

gulp.task('js', function(){

   return gulp.src([
       './node_modules/bootstrap/dist/js/bootstrap.min.js',
       './node_modules/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.min.js',
       './node_modules/jquery/dist/jquery.min.js',
       './node_modules/jquery-validation/dist/jquery.validate.min.js',
       './node_modules/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js',
       './js/**/*.js',
       ])
       .pipe(gulp.dest('wwwroot/js/'))
       .pipe(browserSync.stream());
});

gulp.task('css', function(){

    return gulp.src([
        './style/site.css',
        './node_modules/bootstrap/dist/css/bootstrap.css',
    ])
    .pipe(concat('site.min.css'))
    .pipe(cssmin())
    .pipe(uncss({html: ['Views/**/*.cshtml']}))
    .pipe(gulp.dest('wwwroot/css'))
    .pipe(browserSync.stream());
});