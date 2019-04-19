$(document).ready(function () {
    CargarDatosGeneralesCotizacion();
    var arr_solicitud = [];
    CargarServicios();
    CargarEspecialidades();
    CargarComponentes();
    CargarCeldas();
    CargarComponenteTipo();
});

function CargarServicios() {

    var columns = [{
        'align': 'center',
        'className': 'dt-body-center',
        'render': function (data, type, dataItem, meta) {
            return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.id + '\');">' +
                'Eliminar ' +
                '</a></button></div>';
        }
    },
    { "data": "id" },
    { "data": "nombre" },
    { "data": "cantidad" },
    { "data": "costosoles" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_Servicios', [], columns, false, false, "");
}
function CargarEspecialidades() {

    var columns = [{
        'align': 'center',
        'className': 'dt-body-center',
        'render': function (data, type, dataItem, meta) {
            return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.idespecialidad + '\');">' +
                'Eliminar ' +
                '</a></button></div>';
        }
    },
    { "data": "idespecialidad" },
    { "data": "nombre" },
    { "data": "cantidad" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_Especialidades', [], columns, false, false, "");
}
function CargarComponentes() {
    var columns = [{
        'align': 'center',
        'className': 'dt-body-center',
        'render': function (data, type, dataItem, meta) {
            return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.idcomponente + '\');">' +
                'Eliminar ' +
                '</a></button></div>';
        }
    },
    { "data": "idcomponente" },
    { "data": "codigo" },
    { "data": "nombre" },
    { "data": "tipocomponente" },
    { "data": "cantidad" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_Componentes', [], columns, false, false, "");
}
function CargarCeldas() {
    var columns = [{
        'align': 'center',
        'className': 'dt-body-center',
        'render': function (data, type, dataItem, meta) {
            return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.nombre + '\');">' +
                'Eliminar ' +
                '</a></button></div>';
        }
    },
    { "data": "id" },
    { "data": "nombre" },
    { "data": "cantidad" },
    { "data": "costosoles" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_Celda', [], columns, false, false, "");
}
function CargarComponenteTipo() {
    var columns = [{
        'align': 'center',
        'className': 'dt-body-center',
        'render': function (data, type, dataItem, meta) {
            return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.nombre + '\');">' +
                'Eliminar ' +
                '</a></button></div>';
        }
    },
    { "data": "id" },
    { "data": "nombre" },
    { "data": "cantidad" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_TipoComponente', [], columns, false, false, "");
}
function CargarDatosGeneralesCotizacion() {
    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (day < 10 ? '0' : '') + day + '/' +
        (month < 10 ? '0' : '') + month + '/' + d.getFullYear();

    $('#txtFecRegistro').val(output);
    var data = CallMethod('../Parametro/CargarDatosGeneralesCotizacion', [], onSuccess);
    function onSuccess(response) {
        var cboResponsable = $("#ddlResponsable"), cboFPago = $("#ddlFPago"),
            cboMoneda = $("#ddlMoneda");
        $.each(response.lempleados, function (key, value) {
            cboResponsable.append($('<option>', { value: value.codigo, text: value.nombre }));
        });
        $.each(response.lmonedas, function (key, value) {
            cboMoneda.append($('<option>', { value: value.codigo, text: value.descripcion }));
        });
        $.each(response.lfpagos, function (key, value) {
            cboFPago.append($('<option>', { value: value.codigo, text: value.descripcion }));
        });
        if (response.lmonedas[1].codigo == 2) {
            $("#txtTCambio").val(response.lmonedas[1].tipocambio);
        }
    }
}
function BuscarOCompra() {


    var html = '<div class="widget-body no-padding">' +
        '<table id = "datatable_OCompras" class="table table-striped table-bordered table-hover" width = "100%" > ' +
        '<thead>' +
        '<tr style="background-color:#244e40">' +
        '<td style="width:6%"></td>' +
        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar codigo" />' +
        '</th>' +
        '<th class="hasinput" style="width:10%">' +
        '<input type="text" class="form-control" placeholder="Filtrar registro" />' +
        '</th>' +    
        '<th class="hasinput" style="width:5%">' +
        '<input type="text" class="form-control" placeholder="Filtrar equipo" />' +
        '</th>' +
        '<th class="hasinput" style="width:5%">' +
        '<input type="text" class="form-control" placeholder="Filtrar cliente" />' +
        '</th>' +
        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar total" />' +
        '</th>' +
        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar moneda" />' +
        '</th>' +
        '</tr>' +
        '<tr style="background-color:#244e40">' +
        '<th>Opc</th>' +
        '<th>id</th>' +
        '<th>codigo</th>' +
        '<th>fregistro</th>' +
        
        '<th>equipo</th>' +
        '<th>cliente</th>' +
        '<th>total</th>' +
        '<th>moneda</th>' +
        '</tr>' +
        '</thead>' +
        '<tbody></tbody>' +
        '</table> ' +
        '<br/>' +
        '</div>';
    CargarModalTabla("Ordenes de Compra", html, "Agregar()", false);
    var oPar = { ptipo:1  };
    CallMethod('../OCompra/ConsultarOCompra',oPar, onSuccess);
    function onSuccess(response) {
        var columns = [{
            'align': 'center',
            'className': 'dt-body-center',
            'render': function (data, type, dataItem, meta) {
                return '<div><button class="btn btn-default"><a href="javascript:Seleccionar(\'' + dataItem.id + '\');">' +
                    'Seleccionar ' +
                    '</a></button></div>';
            }
        },
        { "data": "id" },
        { "data": "codigo" },
        { "data": "fecRecepcion" },        
        { "data": "equipo" },
        { "data": "cliente" },
        { "data": "total" },
        { "data": "moneda" }
        ];
        //$('#datatable_Servicio').DataTable().clear().draw();  
        //$('#datatable_Servicio').dataTable().fnAddData(response.Servicios);
        CargarTabla('#datatable_OCompras', response.lorden_compra, columns, false, false);
    }
}


function Seleccionar(num_ocompra) {

    $('#exampleModal').modal('toggle');
    arr_solicitud = [];
    arr_solicitud.push(num_ocompra);
    var oOCompra = { pidcot: num_ocompra };
    CallMethod('../Cotizacion/ConsultarCotizacionFinal', oOCompra, onSuccess);
    function onSuccess(response) {
        $("#txtNroSolicitud").val(response.codigo);
        $("#txtEquipo").val(response.equipo);
        if (response.entaller == "1") {
            $('#chkLugarServicio').val('true');
        }
        $("#txtCliente").val(response.cliente);
        $('#datatable_Servicios').DataTable().clear().draw();
        console.log(response);
        if (response.lservicios.length > 0) {
            $('#datatable_Servicios').dataTable().fnAddData(response.lservicios);
        }
        $('#datatable_Componentes').DataTable().clear().draw();
        if (response.lcomponentes.length > 0) {
            $('#datatable_Componentes').dataTable().fnAddData(response.lcomponentes);
        }
        $('#datatable_TipoComponente').DataTable().clear().draw();
        if (response.ltipocomponentes.length > 0) {
            $('#datatable_TipoComponente').dataTable().fnAddData(response.ltipocomponentes);
        }
        $('#datatable_Especialidades').DataTable().clear().draw();
        if (response.lespecialidades.length > 0) {
            $('#datatable_Especialidades').dataTable().fnAddData(response.lespecialidades);
        }
    }
}