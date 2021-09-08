$(function() {
    $(".checkjob").click(function(e) {
        $(".checkjob").not(this).prop("checked", false);
    });


});

//$(function () {
//    $('.category_check').click(function (e) {
//        $('.category_check').not(this).prop('checked', false);
//    });
//});