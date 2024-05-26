let datatable;

$(document).ready(function () {
    loadDataTable();
});

    function loadDataTable() {
        datatable = $('#tblDatos').DataTable({
            "language": {
                "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
                "zeroRecords": "Ningun Registro",
                "info": "Mostrar page _PAGE_ de _PAGES_",
                "infoEmpty": "no hay registros",
                "infoFiltered": "(filtered from _MAX_ total registros)",
                "search": "Buscar",
                "paginate": {
                    "first": "Primero",
                    "last": "Último",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
            "ajax": {
                "url": "/Admin/Producto/ObtenerTodos"
            },
            "columns": [
                { "data": "activo_Serie" },
                { "data": "descripcion" },
                { "data": "condicion" },
                { "data": "ubicacion" },
                {
                    "data": "estadoP",
                    "render": function (data) {
                        if (data == true) {
                            return "Activo";
                        } else {
                            return "Inactivo";
                        }
                    }
                },
                { "data": "categoria.nombre" },
                { "data": "subCategoria.nombre" },
                { "data": "marca.nombre" },
                { "data": "modeloP.nombre" },
                {
                    "data": "id",
                    "render": function (data) {
                        return `
                       <div class="text-center">
                          <a href="/Admin/Producto/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="bi bi-pen"></i>
                          </a>
                          <a onclick=Delete("/Admin/Producto/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="bi bi-trash"></i>
                          </a>
                       </div>
                       
                    `;
                    }
                }
            ]
        });
}



function Delete(url) {
    swal({
        title: "¿Esta seguro de Eliminar el Producto?",
        text: "Este registro no se podrá recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}