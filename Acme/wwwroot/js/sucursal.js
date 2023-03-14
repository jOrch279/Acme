var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            "url":"/Admin/Sucursal/ObtenerTodos"
        },
        "columns": [
            { "data": "nombre", "width": "20%" },
            { "data": "descripcion", "width": "40%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";

                    }
                    else {
                        return "Inactivo";
                    }
                }, "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
            <div class="text-center">
                <a href="Sucursal/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer" >
                    <i class="fa-sharp fa-regular fa-pen-to-square"></i>
                </a>
                <a class="btn btn-danger tetx-white" style="cursor:pointer">
                     <i class="fa-solid fa-trash-xmark"></i>
                </a>
            </div>
               `;
                }, "width": "20%"
            }

        ]
    });
}