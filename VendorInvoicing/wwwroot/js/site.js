$(document).ready(function () {
    //select all datime input fileds & cal the datepicker method on them:
    $('input[type=datetime]').datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: '-100: +100'
    });
});