$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#deletedCategoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Refresh',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/admin/category/getalldeletedcategories/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#deletedCategoriesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const deletedCategories = jQuery.parseJSON(data);
                            dataTable.clear();
                            //console.log(deletedCategories);
                            if (deletedCategories.ResultStatus === 0) {
                                $.each(deletedCategories.Categories.$values,
                                    function (index, category) {
                                        const newTableRow = dataTable.row.add([
                                            category.Id,
                                            category.Name,
                                            category.Description,
                                            category.IsActive ? "Yes" : "No",
                                            category.IsDeleted ? "Yes" : "No",
                                            category.Note,
                                            convertToShortDate(category.CreatedDate),
                                            category.CreatedByName,
                                            convertToShortDate(category.ModifiedDate),
                                            category.ModifiedByName,
                                            `
                                <button class="btn btn-warning btn-sm btn-undo" data-id="${category.Id}"><span class="fas fa-undo"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span></button>
                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${category.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#deletedCategoriesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${deletedCategories.Categories.Message}`, 'Operation Failed!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#deletedCategoriesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Error!');
                        }
                    });
                }
            }
        ]
    });

    /* DataTables end here */

    /* Undo Deleting Category starts from here */

    $(document).on('click',
        '.btn-undo',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let categoryName = tableRow.find('td:eq(1)').text();
            //categoryName = categoryName.length > 75 ? categoryName.substring(0, 75) : categoryName;
            Swal.fire({
                title: 'Are you sure to recover?',
                text: `"${categoryName}" category will be recovered!`,
                icon: 'question',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, Recover',
                cancelButtonText: 'Cancel'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { categoryId: id },
                        url: '/admin/category/undodelete/',
                        success: function (data) {
                            const categoryResult = jQuery.parseJSON(data);
                            //console.log(categoryResult);
                            if (categoryResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Recovered!',
                                    `${categoryResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Operation Failed!',
                                    text: `${categoryResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Error!");
                        }
                    });
                }
            });
        });

    /* Undo Deleting Category ends here */

    /* Hard Deleting Category starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let categoryName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Are you sure to delete from DB?',
                text: `"${categoryName}" category will be deleted from DB!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, Delete',
                cancelButtonText: 'Cancel'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { categoryId: id },
                        url: '/admin/category/harddelete/',
                        success: function (data) {
                            const hardDeleteResult = jQuery.parseJSON(data);
                            //console.log(categoryResult);
                            if (hardDeleteResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    `${hardDeleteResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Operation Failed!',
                                    text: `${hardDeleteResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Error!");
                        }
                    });
                }
            });
        });

    /* Hard Deleting Category ends here */

    function getButtonsForDataTable(category) {
        return `<button class="btn btn-warning btn-sm btn-undo" data-id="${category.Id}"><span class="fas fa-undo"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span></button>`


    }
});