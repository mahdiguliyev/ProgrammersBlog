$(document).ready(function(){
    // Select2
    $('#categoryList').select2({
        theme: 'bootstrap4',
        placeholder: "Select a category",
        allowClear: true
    });

    $('#filterByList').select2({
        theme: 'bootstrap4',
        placeholder: "Select a Filter Type",
        allowClear: true
    });
    
    $('#orderByList').select2({
        theme: 'bootstrap4',
        placeholder: "Select a Order Type",
        allowClear: true
    });

    $('#isAscendingList').select2({
        theme: 'bootstrap4',
        placeholder: "Select a Order(Asc/Desc) Type",
        allowClear: true
    });

    // jQuery UI - Datepicker
    $(function () {
        $("#startAtDatePicker").datepicker({
            duration: 1000,
            showAnim: "drop",
            showOptions: {
                direction: "down"
            },
            //minDate: -3,
            maxDate: 0,
            dateFormat: "dd/mm/yy"
        });

        $("#endAtDatePicker").datepicker({
            duration: 1000,
            showAnim: "drop",
            showOptions: {
                direction: "down"
            },
            //minDate: -3,
            maxDate: 0,
            dateFormat: "dd/mm/yy"
        });
    });
});
