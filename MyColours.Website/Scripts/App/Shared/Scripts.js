$(document).ready(function () {

    $(".js-dataTable").DataTable();

    $(".js-datepicker-default")
        .datepicker({
            dateFormat: 'yy-mm-dd'
        });

    $(".js-datepicker-upToday")
        .datepicker({
            dateFormat: 'yy-mm-dd',
            maxDate: '0'
        });

});