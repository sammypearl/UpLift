var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/category/GetAll",
            "type": "Get",
            "datatable": "json"
        },
        "columns": [
            { "data": "name", "width": "50%" },
            { "data": "displayOrder", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/admin/category/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                     <i class='far fa-edit'></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/admin/category/Delete/${data}") class='btn btn-success text-white' style='cursor:pointer; width:100px'>
                                     <i class='far fa-trash-all'></> Delete
                                </a>
                            </div>
                         
                          `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No records found."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the content!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnconfirm: true


    },   function () {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.mesage);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });

    });
}

function ShowMessage(msg) {

}
 