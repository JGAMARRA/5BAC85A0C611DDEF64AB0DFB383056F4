function CallMethod(url, parameters, successCallback) {    
    $.ajax({
        type: 'POST',
        url: url,
        data: JSON.stringify(parameters),
        contentType: 'application/json;',
        //dataType: 'json',
        success: successCallback,
        error: function (xhr, textStatus, errorThrown) {
            ShowErrorBox("Atención", "Ocurrió un error, si el error persiste reportarlo con Sistemas");
        }
    });
}
function CargarTabla(ptable, data, columns,ppaging,pinfo,funcion_inicio,mostrar_columna1) {
    // Filtros Tabla
    $(ptable+" thead th input[type=text]").on('keyup change', function () {
        tablex
            .column($(this).parent().index() + ':visible')
            .search(this.value)
            .draw();
    });

    var tablex = $(ptable).DataTable({
        "initComplete": function () {
            funcion = funcion_inicio;
        },
        "paging": ppaging,//no sale paginacion parte superior derecha
        "info": pinfo,//no sale footer de paginacion
        "data": data,
        "columns": columns
    });
    if (mostrar_columna1 == false) {
        tablex.columns([0]).visible(false);
    }
}

function CargarModal(title,div_table,metodo_agregar) {
    var html_modal = '<div class="modal fade" id="exampleModal" tabindex=" - 1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">'+
        '<div class="modal-dialog" role = "document">'+
        '<div class="modal-content">'+
        '<div class="modal-header">'+
        '<h5 class="modal-title" id="exampleModalLabel">'+title+'</h5>' +  
        '</div>'+
        '<div class="modal-body">'+
        '<div id="modal-content">'+  div_table+                      
        '</div>'+
        '</div>'+
        '<div class="modal-footer">'+
        '<button id="btnAceptar" type="button" class="btn btn-primary" onclick="javascript:'+metodo_agregar+';">Aceptar</button>'+
        '<button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>'+
        '</div>'+
        '</div>'+
    '</div>'+
        '</div>';
    $("#idmodal").html(html_modal);
}

function CargarModalTabla(title, div_table, metodo_agregar, modal_large) {
    var tex = "";
    if (modal_large == true) { tex = '<div class="modal-dialog modal-lg" role = "document">'; }
    else { tex = '<div class="modal-dialog" role = "document">'; }
    var html_modal = '<div class="modal fade" id="exampleModal" tabindex=" - 1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">'+
    tex+       
        '<div class="modal-content">' +
        '<div class="modal-header">' +
        '<h5 class="modal-title" id="exampleModalLabel">' + title + '</h5>' +
        '</div>' +
        '<div class="modal-body">' +
        '<div id="modal-content">' + div_table +
        '</div>' +
        '</div>' +
        '<div class="modal-footer">' +  
        '<button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>'+
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>';
    $("#idmodal").html(html_modal);
}

//$('#example').dataTable({
//    destroy: true,
//    aaData: response.data
//});


//table = $('#example').DataTable({
//    retrieve: true,
//    paging: false
//});