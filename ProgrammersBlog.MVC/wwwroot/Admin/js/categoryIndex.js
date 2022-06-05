$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[6, "desc"]],
        buttons: [
            {
                text: 'Add',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Resfresh',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/admin/category/getallcategories/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#categoriesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const categoryListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(categoryListDto);
                            if (categoryListDto.ResultStatus === 0) {
                                $.each(categoryListDto.Categories.$values,
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
                                <button class="btn btn-primary btn-sm btn-update" data-id="${category.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${category.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#categoriesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${categoryListDto.Message}`, 'Operation Failed!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#categoriesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Error!');
                        }
                    });
                }
            }
        ]
    });

    /* DataTables end here */

    /* Ajax GET / Getting the _CategoryAddPartial as Modal Form starts from here. */

    $(function () {
        const url = '/admin/category/add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _CategoryAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as CategoryAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-category-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const categoryAddAjaxModel = jQuery.parseJSON(data);
                    console.log(categoryAddAjaxModel);
                    const newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = dataTable.row.add([
                            categoryAddAjaxModel.CategoryDto.Category.Id,
                            categoryAddAjaxModel.CategoryDto.Category.Name,
                            categoryAddAjaxModel.CategoryDto.Category.Description,
                            categoryAddAjaxModel.CategoryDto.Category.IsActive ? "Yes" : "No",
                            categoryAddAjaxModel.CategoryDto.Category.IsDeleted ? "Yes" : "No",
                            categoryAddAjaxModel.CategoryDto.Category.Note,
                            convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate),
                            categoryAddAjaxModel.CategoryDto.Category.CreatedByName,
                            convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate),
                            categoryAddAjaxModel.CategoryDto.Category.ModifiedByName,
                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                        ]).node();
                        const jqueryTableRow = $(newTableRow);
                        jqueryTableRow.attr('name', `${categoryAddAjaxModel.CategoryDto.Category.Id}`);
                        dataTable.draw();
                        toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, 'Operation Failed!');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText += `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */

    /* Ajax POST / Deleting a Category starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const categoryName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `"${categoryName}" category will be deleted!`,
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
                        url: '/admin/category/delete/',
                        success: function (data) {
                            const categoryDto = jQuery.parseJSON(data);
                            if (categoryDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    `"${categoryDto.Category.Name}" category has been deleted.`,
                                    'success'
                                );
                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Operation Failed!',
                                    text: `${categoryDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Error!")
                        }
                    });
                }
            });
        });

    /* Ajax GET / Getting the _CategoryUpdatePartial as Modal Form starts from here. */

    $(function () {
        const url = '/admin/category/update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { categoryId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("An error occured.");
                });
            });

        /* Ajax POST / Updating a Category starts from here */

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();

                const form = $('#form-category-update');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    const categoryUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(categoryUpdateAjaxModel);
                    const newFormBody = $('.modal-body', categoryUpdateAjaxModel.CategoryUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        const id = categoryUpdateAjaxModel.CategoryDto.Category.Id;
                        const tableRow = $(`[name="${id}"]`);
                        placeHolderDiv.find('.modal').modal('hide');
                        dataTable.row(tableRow).data([
                            categoryUpdateAjaxModel.CategoryDto.Category.Id,
                            categoryUpdateAjaxModel.CategoryDto.Category.Name,
                            categoryUpdateAjaxModel.CategoryDto.Category.Description,
                            categoryUpdateAjaxModel.CategoryDto.Category.IsActive ? "Yes" : "No",
                            categoryUpdateAjaxModel.CategoryDto.Category.IsDeleted ? "Yes" : "No",
                            categoryUpdateAjaxModel.CategoryDto.Category.Note,
                            convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.CreatedDate),
                            categoryUpdateAjaxModel.CategoryDto.Category.CreatedByName,
                            convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.ModifiedDate),
                            categoryUpdateAjaxModel.CategoryDto.Category.ModifiedByName,
                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${categoryUpdateAjaxModel
                                .CategoryDto.Category.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryUpdateAjaxModel
                                .CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                        ]);
                        tableRow.attr("name", `${id}`);
                        dataTable.row(tableRow).invalidate();
                        toastr.success(`${categoryUpdateAjaxModel.CategoryDto.Message}`, "Operation Failed!");
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                }).fail(function (response) {
                    console.log(response);
                });
            });

    });
});