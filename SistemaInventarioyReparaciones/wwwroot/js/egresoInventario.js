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
            "url": "/Inventario/Inventario/ObtenerTodos"
        },
        "columns": [
            { "data": "id", "width": "8%", "visible": false },
            { "data": "bodega.nombre" },
            { "data": "producto.descripcion" },
            { "data": "cantidad", "classname": "text-end" }, 
            {
                "data": "id",
                "render": function (data) {
                    return `
                       <div class="text-center">
                          <a href="/Inventario/Inventario/Detalle/${data}" class="btn btn-outline-primary" style="cursor:pointer">
                                <i class="bi bi-tags-fill"></i> Detalle
                          </a>
                         
                       </div>
                       
                    `;
                }, "width": "20%"
            }
        ],
        "order": [[0, "desc"]]
    });
}

