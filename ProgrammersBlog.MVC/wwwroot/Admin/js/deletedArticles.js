﻿$(document).ready(function () {

    /* DataTables start here. */

   const dataTable = $('#deletedArticlesTable').DataTable({
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
                        url: '/admin/article/getalldeletedarticles/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#deletedArticlesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const articleResult = jQuery.parseJSON(data);
                            dataTable.clear();
                            //console.log(articleResult);
                            if (articleResult.Data.ResultStatus === 0) {
                                let categoriesArray = [];
                                $.each(articleResult.Data.Articles.$values,
                                    function (index, article) {
                                        const newArticle = getJsonNetObject(article, articleResult.Data.Articles.$values);
                                        let newCategory = getJsonNetObject(newArticle.Category, newArticle);
                                        if (newCategory !== null) {
                                            categoriesArray.push(newCategory);
                                        }
                                        if (newCategory === null) {
                                            newCategory = categoriesArray.find((category) => {
                                                return category.$id === newArticle.Category.$ref;
                                            });
                                        }
                                        const newTableRow = dataTable.row.add([
                                            newArticle.Id,
                                            newCategory.Name,
                                            newArticle.Title,
                                            `<img src="/img/${newArticle.Thumbnail}" alt="${newArticle.Title}" class="my-image-table" />`,
                                            `${convertToShortDate(newArticle.Date)}`,
                                            newArticle.ViewCount,
                                            newArticle.CommentCount,
                                            `${newArticle.IsActive ? "Yes" : "No"}`,
                                            `${newArticle.IsDeleted ? "Yes" : "No"}`,
                                            `${convertToShortDate(newArticle.CreatedDate)}`,
                                            newArticle.CreatedByName,
                                            `${convertToShortDate(newArticle.ModifiedDate)}`,
                                            newArticle.ModifiedByName,
                                            `
                                <button class="btn btn-primary btn-sm btn-undo" data-id="${newArticle.Id}"><span class="fas fa-undo"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${newArticle.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${newArticle.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#deletedArticlesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${articleResult.Data.Message}`, 'Operation Failed!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#deletedArticlesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Error!');
                        }
                    });
                }
            }
        ]
    });

    /* DataTables end here */

    /* Ajax POST / HardDeleting a Article starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const articleTitle = tableRow.find('td:eq(2)').text();
            Swal.fire({
                title: 'Are you sure to delete from DB?',
                text: `"${articleTitle}" article will be deleted from DB!`,
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
                        data: { articleId: id },
                        url: '/admin/article/harddelete/',
                        success: function (data) {
                            const articleResult = jQuery.parseJSON(data);
                            if (articleResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    `${articleResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Operation Failed!',
                                    text: `${articleResult.Message}`,
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

    /* Ajax POST / HardDeleting a Article ends here */

    /* Ajax POST / UndoDeleting a Article starts from here */

    $(document).on('click',
        '.btn-undo',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let articleTitle = tableRow.find('td:eq(2)').text();
            Swal.fire({
                title: 'Are you sure to recover?',
                text: `"${articleTitle}" article will be recovered!`,
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
                        data: { articleId: id },
                        url: '/admin/article/undodelete/',
                        success: function (data) {
                            const articleUndoDeleteResult = jQuery.parseJSON(data);
                            //console.log(articleUndoDeleteResult);
                            if (articleUndoDeleteResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Recovered!',
                                    `${articleUndoDeleteResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Operation Failed!',
                                    text: `${articleUndoDeleteResult.Message}`,
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
/* Ajax POST / UndoDeleting a Article ends here */

});