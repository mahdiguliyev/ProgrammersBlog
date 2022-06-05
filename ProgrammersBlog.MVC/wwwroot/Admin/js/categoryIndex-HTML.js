$(document).ready(function () {

    /* DataTables starts here */

    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
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
                text: 'Refresh',
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
                            //console.log(categoryListDto);
                            if (categoryListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(categoryListDto.Categories.$values,
                                    function (index, category) {
                                        tableBody += `
                                            <tr name="${category.Id}">
                                                <td>${category.Id}</td>
                                                <td>${category.Name}</td>
                                                <td>${category.Description}</td>
                                                <td>${category.IsActive ? "Yes" : "No"}</td>
                                                <td>${category.IsDeleted ? "Yes" : "No"}</td>
                                                <td>${category.Note}</td>
                                                <td>${convertToShortDate(category.CreatedDate)}</td>
                                                <td>${category.CreatedByName}</td>
                                                <td>${convertToShortDate(category.ModifiedDate)}</td>
                                                <td>${category.ModifiedByName}</td>
                                                <td>
                                                    <button class="btn btn-primary btn-sm btn-update" data-id="${category.Id}"><span class="fas fa-edit"></span></button>
                                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span></button>
                                                </td>
                                            </tr>`
                                    });
                                $('#categoriesTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#categoriesTable').fadeIn(1400);
                            } else {
                                $('.spinner-border').hide();
                                toastr.error(`${categoryListDto.Message}`, 'Operation Error!');
                            }
                        },
                        error: function (err) {
                            $('.spinner-border').hide();
                            $('#categoriesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Error!');
                        }
                    });
                }
            }
        ]
    });

    /* DataTables ends here */

    /* Ajax Get / Getting the _CategoryAddPartial as Modal Form starts from here */

    $(function () {
        const url = '/admin/category/add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax Get / Getting the _CategoryAddPartial as Modal Form ends here */

        /* Ajax Post / Posting the _CategoryAddPartial as Modal Form starts from here */

        placeHolderDiv.on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-category-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();

            $.post(actionUrl, dataToSend).done(function (data) {
                const categoryAddAjaxModel = jQuery.parseJSON(data);
                const newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';

                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                                <tr name="${categoryAddAjaxModel.CategoryDto.Category.Id}">
                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
                                    <td>${categoryAddAjaxModel.CategoryDto.Category.IsActive ? "Yes" : "No"}</td>
                                    <td>${categoryAddAjaxModel.CategoryDto.Category.IsDeleted ? "Yes" : "No"}</td>
                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Note}</td>
                                    <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                    <td>${categoryAddAjaxModel.CategoryDto.Category.CreatedByName}</td>
                                    <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                                    <td>${categoryAddAjaxModel.CategoryDto.Category.ModifiedByName}</td>
                                    <td>
                                        <button class="btn btn-primary btn-sm btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit"></span></button>
                                        <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button>
                                    </td>
                                </tr>`;
                    const newTableRowObject = $(newTableRow);
                    newTableRowObject.hide();
                    $('#categoriesTable').append(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, 'Success Operation!');
                } else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            });
        });

        /* Ajax Post / Posting the _CategoryAddPartial as Modal Form ends here */

    });

    /* Ajax Post / Deleting the a Category starts from here */

    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tableRow = $(`[name="${id}"]`);
        const categoryName = tableRow.find('td:eq(1)').text();
        Swal.fire({
            title: 'Are you sure?',
            text: `${categoryName} will be deleted!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
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
                                `${categoryDto.Category.Name} category is deleted successfully.`,
                                'success'
                            );

                            tableRow.fadeOut(2000);
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Failed Operation!',
                                text: `${categoryDto.Message}`
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

    /* Ajax Post / Deleting the a Category end here */


    /* Update Category */

    $(function () {
        const url = '/admin/category/update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            $.get(url, { categoryId: id }).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function () {
                toastr.error("An error occured!");
            });
        });

        /* Ajax Post / Updating a Category starts from here */

        placeHolderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();
            const form = $('#form-category-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();

            $.post(actionUrl, dataToSend).done(function (data) {
                const categoryAjaxUpdateModel = jQuery.parseJSON(data);
                console.log(categoryAjaxUpdateModel);
                const newFormBody = $('.modal-body', categoryAjaxUpdateModel.CategoryUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';

                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                                <tr name="${categoryAjaxUpdateModel.CategoryDto.Category.Id}">
                                    <td>${categoryAjaxUpdateModel.CategoryDto.Category.Id}</td>
                                    <td>${categoryAjaxUpdateModel.CategoryDto.Category.Name}</td>
                                    <td>${categoryAjaxUpdateModel.CategoryDto.Category.Description}</td>
                                    <td>${categoryAjaxUpdateModel.CategoryDto.Category.IsActive ? "Yes" : "No"}</td>
                                    <td>${categoryAjaxUpdateModel.CategoryDto.Category.IsDeleted ? "Yes" : "No"}</td>
                                    <td>${categoryAjaxUpdateModel.CategoryDto.Category.Note}</td>
                                    <td>${convertToShortDate(categoryAjaxUpdateModel.CategoryDto.Category.CreatedDate)}</td>
                                    <td>${categoryAjaxUpdateModel.CategoryDto.Category.CreatedByName}</td>
                                    <td>${convertToShortDate(categoryAjaxUpdateModel.CategoryDto.Category.ModifiedDate)}</td>
                                    <td>${categoryAjaxUpdateModel.CategoryDto.Category.ModifiedByName}</td>
                                    <td>
                                        <button class="btn btn-primary btn-sm btn-update" data-id="${categoryAjaxUpdateModel.CategoryDto.Category.Id}"><span class="fas fa-edit"></span></button>
                                        <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryAjaxUpdateModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button>
                                    </td>
                                </tr>`;
                    const newTableRowObject = $(newTableRow);
                    const categoryTableRow = $(`[name="${categoryAjaxUpdateModel.CategoryDto.Category.Id}"]`);
                    newTableRowObject.hide();
                    categoryTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${categoryAjaxUpdateModel.CategoryDto.Message}`, "Success Operation!");
                }
                else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function (response) {
                toastr.error(response);
            });
        });

        /* Ajax Post / Updating a Category ends here */
    });
});