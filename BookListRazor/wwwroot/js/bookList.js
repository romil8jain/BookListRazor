var datatable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    datatable = $('#DT_load').DataTable({ // we have added this function as part of online references

        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype" : "JSON"
        },
        // data is the id, the sign under ~helps writing multi - line in return
        "columns": [
            { "data": "name", "width": "20%" }, //make sure this has camel casing based on actual names
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) { 
                    return `<div class="text-center"> 
                    <a href ="/BookList/Edit?id=${data}" class= 'btn btn-success text-white' style = 'cursor:pointer;width:70px;'>
                        Edit
                    </a>
                    &nbsp
                    <a class= 'btn btn-danger text-white' style = 'cursor:pointer;width:70px;'
                        onclick = 'Delete('/api/book?id='+${data})>
                        Delete
                    </a>
                    </div>`;
                }, "width" : "40%"
            }
        ],
        "language": {
            "emptyTable" : "no data found"
        },

        "width": "100%"
    })
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Action is permanent",
        icon: "warning",
        buttons:true,
        dangerMode: true
    }).then((willDelete) => { //willDelete is the response from sqal
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message); //we receive message from BookController.cs
                    }
                }
            });
        }
    });
}

//https://datatables.net/reference/option/columns.render
