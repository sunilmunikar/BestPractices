var gulp = require('gulp');
var browserSync = require('browser-sync');


// Static server
// gulp.task('browser-sync', function () {
    // browserSync({
        // server: {
            // baseDir: "./"
        // }
    // });
// });

// or...

gulp.task('browser-sync', function () {
   browserSync({
       proxy: "http://localhost:56205/"
   });
});


// use default task to launch BrowserSync and watch JS files
gulp.task('default', ['browser-sync'], function () {

    // add browserSync.reload to the tasks array to make
    // all browsers reload after tasks are complete.
    gulp.watch("./app/**/*.*").on("change", browserSync.reload);

});
