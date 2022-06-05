$(document).ready(function(){

    // Trumbowjy Text Editor

    $('#text-editor').trumbowyg({
        btns: [
            ['viewHTML'],
            ['undo', 'redo'], // Only supported in Blink browsers
            ['formatting'],
            ['strong', 'em', 'del'],
            ['superscript', 'subscript'],
            ['link'],
            ['insertImage'],
            ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
            ['unorderedList', 'orderedList'],
            ['horizontalRule'],
            ['removeformat'],
            ['fullscreen'],
            ['foreColor', 'backColor'],
            ['emoji'],
            ['fontfamily'],
            ['fontsize']
        ]
    });

    // Select2
    $('#categoryList').select2({
        theme: 'bootstrap4',
        placeholder: "Select a category",
        allowClear: true
    });

    // jQuery UI - Datepicker
    $(function () {
        $("#datepicker").datepicker({
            duration: 1000,
            showAnim: "drop",
            showOptions: {
                direction: "down"
            },
            minDate: -3,
            maxDate: +3,
            dateFormat: "dd/mm/yy"
        });
    });
});
