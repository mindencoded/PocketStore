var config = require('./config.json');
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var jshint = require('gulp-jshint');
var imagemin = require('gulp-imagemin');
var connect = require('connect');
var serve = require('serve-static');
var browsersync = require('browser-sync');
var postcss = require('gulp-postcss');
var cssnext = require('postcss-cssnext');
var cssnano = require('cssnano');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var buffer = require('vinyl-buffer');
var plumber = require('gulp-plumber');
var beeper = require('beeper');
var del = require('del');

// Error Handler
function onError(err) {
    beeper();
    console.log('Name:', err.name);
    console.log('Reason:', err.reason);
    console.log('File:', err.file);
    console.log('Line:', err.line);
    console.log('Column:', err.column);
}

gulp.task('import-styles',
    function() {
        return gulp.src(config.vendor_files.css)
            .pipe(gulp.dest('app/css'));
    });

gulp.task('import-scripts',
    function() {
        return gulp.src(config.vendor_files.js)
            .pipe(gulp.dest('app/js'));
    });

gulp.task('import', gulp.parallel('import-scripts'));

// Process styles
gulp.task('styles',
    function() {
        return gulp.src(config.build_files.css)
            .pipe(plumber({
                errorHandler: onError
            }))
            .pipe(concat('all.css'))
            .pipe(postcss([
                cssnext(),
                cssnano({
                    autoprefixer: false
                })
            ]))
            .pipe(gulp.dest(config.build_dir));
    });

// Process scripts
gulp.task('scripts',
    function() {
        return gulp.src(config.build_files.js)
            .pipe(jshint())
            .pipe(jshint.reporter('default'))
            .pipe(concat('all.js'))
            .pipe(uglify())
            .pipe(gulp.dest(config.build_dir));
    });

// Process images
gulp.task('images',
    function() {
        return gulp.src('app/img/*')
            .pipe(imagemin())
            .pipe(gulp.dest(config.build_dir + '/img'));
    });

// Server Task
gulp.task('server',
    function() {
        var port = 8080;
        return connect().use(serve(__dirname))
            .listen(port)
            .on('listening',
                function() {
                    console.log('Server Running: View at http://localhost:' + port);
                });
    });

// BrowserSync Task
gulp.task('browsersync',
    function() {
        return browsersync({
            server: {
                baseDir: './'
            }
        });
    });

// Browserify Task
gulp.task('browserify',
    function() {
        return browserify('./app/js/app.js')
            .bundle()
            .pipe(source('bundle.js'))
            .pipe(buffer())
            .pipe(gulp.dest('dist'));
    });

// Clean Task
gulp.task('clean',
    function() {
        return del(['dist/*']);
    });

// Watch Task
gulp.task('watch',
    function() {
        gulp.watch('app/css/*.css', gulp.series('clean', 'styles', browsersync.reload));
        gulp.watch('app/js/*.js', gulp.series('clean', 'scripts', browsersync.reload));
        gulp.watch('app/img/*', gulp.series('clean', 'images', browsersync.reload));
    });

// Default Task
gulp.task('default', gulp.parallel('styles', 'scripts', 'images', 'browsersync', 'watch'));