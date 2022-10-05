(function($) {
    "use strict"
    // Daterange picker
    $('.input-daterange-datepicker').daterangepicker({
        format: 'jYYYY/jMM/jDD',
        jalaali: true,
        opens: 'left',
        startDate: moment(),
        endDate: moment().add(10,'day'),
        buttonClasses: ['btn', 'btn-sm'],
        applyClass: 'btn-danger',
        cancelClass: 'btn-inverse'
    });
    $('.input-daterange-timepicker').daterangepicker({
        timePicker: true,
        timePicker12Hour: true,
        startDate: moment().startOf('hour'),
        endDate: moment().startOf('hour').add(48, 'hour'),
        jalaali: true,
        opens: 'left',
        locale: {
            format: 'M/DD hh:mm A',
            separator: ' - '
        }
    });
    $('.input-limit-datepicker').daterangepicker({
        format: 'jYYYY/jMM/jDD',
        jalaali: true,
        opens: 'left',
        minDate: '1400/01/01',
        maxDate: '1400/12/29',
        buttonClasses: ['btn', 'btn-sm'],
        applyClass: 'btn-danger',
        cancelClass: 'btn-inverse',
        dateLimit: {
            days: 6
        }
    });
})(jQuery);