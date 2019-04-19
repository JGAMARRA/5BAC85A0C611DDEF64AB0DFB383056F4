$(document).ready(function () {
    var arr_solicitud = [];
    CargarDatosGeneralesCotizacion();
    CargarServicios();
    //CargarEspecialidades();
    CargarComponentes();
    CargarCeldas();
    CargarEmpleados();
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
        { "data": "costosoles" },
        { "data": "vventa" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_Servicios', [], columns, false, false, "");
}
//function CargarEspecialidades() {

//    var columns = [{
//        'align': 'center',
//        'className': 'dt-body-center',
//        'render': function (data, type, dataItem, meta) {
//            return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.idespecialidad + '\');">' +
//                'Eliminar ' +
//                '</a></button></div>';
//        }
//    },
//    { "data": "idespecialidad" },
//    { "data": "nombre" },
//    { "data": "cantidad" }
//    ];
//    //$('#datatable_Servicios').DataTable().clear().draw();
//    //$('#datatable_Servicios').dataTable().fnAddData(data);
//    CargarTabla('#datatable_Especialidades', [], columns, false, false, "");
//}
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
        { "data": "cantidad" },
    { "data": "costosoles" },
    { "data": "vventa" }
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
        { "data": "costosoles" },
    { "data": "vventa" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_Celda', [], columns, false, false, "");
}
function CargarEmpleados() {
    var columns = [{
        'align': 'center',
        'className': 'dt-body-center',
        'render': function (data, type, dataItem, meta) {
            return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.nombre + '\');">' +
                'Eliminar ' +
                '</a></button></div>';
        }
    },
    { "data": "codigo" },
        { "data": "nombre" },
        { "data": "especialidad" },        
        { "data": "cantidad" },
        { "data": "costosoles" },
        { "data": "hnormal" },
        { "data": "hextendido" },
        { "data": "vventa" }            
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_Empleados', [], columns, false, false, "");
}
function BuscarCotizacion() {


    var html = '<div class="widget-body no-padding">' +
        '<table id = "datatable_Cotizacion" class="table table-striped table-bordered table-hover" width = "100%" > ' +
        '<thead>' +
        '<tr style="background-color:#244e40">' +
        '<td style="width:6%"></td>' +

        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar id" />' +
        '</th>' +
        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar codigo" />' +
        '</th>' +
        '<th class="hasinput" style="width:5%">' +
        '<input type="text" class="form-control" placeholder="Filtrar equipo" />' +
        '</th>' +
        '<th class="hasinput" style="width:5%">' +
        '<input type="text" class="form-control" placeholder="Filtrar cliente" />' +
        '</th>' +
        '<th class="hasinput" style="width:10%">' +
        '<input type="text" class="form-control" placeholder="Filtrar registro" />' +
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
        '<th>equipo</th>' +
        '<th>cliente</th>' +
        '<th>registro</th>' +
        '<th>total</th>' +
        '<th>moneda</th>' +
        '</tr>' +
        '</thead>' +
        '<tbody></tbody>' +
        '</table> ' +
        '<br/>' +
        '</div>';
    CargarModalTabla("Cotización", html, "Agregar()", false, true);
    var oPar = { ptipo: 2 };
    CallMethod('../Cotizacion/ConsultarCotizaciones',oPar, onSuccess);
    function onSuccess(response) {
        var columns = [{
            'align': 'center',
            'className': 'dt-body-center',
            'render': function (data, type, dataItem, meta) {
                return '<div><button class="btn btn-default"><a href="javascript:Seleccionar(\'' + dataItem.idCotizacionCab + '\');">' +
                    'Seleccionar ' +
                    '</a></button></div>';
            }
        }, 
            { "data": "idCotizacionCab" },
            { "data": "nCotizacion" },
            { "data": "equipo" },
            { "data": "cliente" },   
            { "data": "fecRegistro" },               
            { "data": "total" },
            { "data": "moneda" }

        ];
        //$('#datatable_Servicio').DataTable().clear().draw();  
        //$('#datatable_Servicio').dataTable().fnAddData(response.Servicios);
        CargarTabla('#datatable_Cotizacion', response.lcotizaciones, columns, false, false);
    }
}
function Seleccionar(idcot) {

    $('#exampleModal').modal('toggle');
    arr_solicitud = [];
    arr_solicitud.push(idcot);
    var oCotizacion = { pidcot: idcot };
    CallMethod('../Cotizacion/ConsultarCotizacionFinal', oCotizacion, onSuccess);
    function onSuccess(response) {
        $("#txtNroCotizacion").val(response.numCotizacion);
        $("#txtEquipo").val(response.nomEquipo);
        $("#lblCotVVenta").val(response.valorventa);
        $("#lblCotIGV").val(response.igv);
        $("#lblCotTotal").val(response.total);
        $("#txtFecVencimiento").val(response.fvencimiento);
        $("#txtFecInicio").val(response.finicio);
        $("#txtFecTermino").val(response.fterminado);
        $("#ddlFPago").val(response.idfpago);
        $("#ddlMoneda").val(response.idmoneda);
        
        
        
        
        if (response.entaller == "1") {
            $('#chkLugarServicio').val('true');
        }
        if (response.HorarioEmergencia == "1") {
            $('#chkHorario').val('true');
        }
        $("#txtCliente").val(response.nomCliente);
        $('#datatable_Servicios').DataTable().clear().draw();
        if (response.lservicios.length > 0) {
            $('#datatable_Servicios').dataTable().fnAddData(response.lservicios);
        }
        $('#datatable_Componentes').DataTable().clear().draw();
        if (response.lcomponentes.length > 0) {
            $('#datatable_Componentes').dataTable().fnAddData(response.lcomponentes);
        }
        $('#datatable_Empleados').DataTable().clear().draw();
        if (response.lempleados.length > 0) {
            $('#datatable_Empleados').dataTable().fnAddData(response.lempleados);
        }
        $('#datatable_Especialidades').DataTable().clear().draw();
        if (response.lespecialidades.length > 0) {
            $('#datatable_Especialidades').dataTable().fnAddData(response.lespecialidades);
        }
        $('#datatable_Celda').DataTable().clear().draw();
        if (response.lceldas.length > 0) {
            $('#datatable_Celda').dataTable().fnAddData(response.lceldas);
        }
    }
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

function grabar() {

    var array_especialidades = [];
    var array_componentes = [];
    var array_celdas = [];
    var array_servicios = [];
    var array_tipocomponentes = [];
    var array_empleados = [];
    var ddlResponsable = $('#ddlResponsable').val();
    var ddlFPago = $('#ddlFPago').val();
    var ddlMoneda = $('#ddlMoneda').val();
    var txtFecVencimiento = $('#txtFecVencimiento').val();
    var txtFecTermino = $('#txtFecTermino').val();
    var txtFecInicio = $('#txtFecInicio').val();    
    var txtFecRecepcion = $('#txtFecRecepcion').val();
    var lblCotVVenta = $('#lblCotVVenta').val();
    var lblCotIGV = $('#lblCotIGV').val();
    var lblCotTotal = $('#lblCotTotal').val();
    var chk = 0;
    if ($('#chkLugarServicio').prop('checked')) {
        chk = 1;
    }
    var chk1 = 0;
    if ($('#chkHorario').prop('checked')) {
        chk1 = 1;
    }



    //var table = $('#datatable_Especialidades').DataTable();
    var table1 = $('#datatable_Componentes').DataTable();
    var table2 = $('#datatable_Celda').DataTable();
    var table3 = $('#datatable_Servicios').DataTable();
    var table4 = $('#datatable_Empleados').DataTable();
    //table
    //    .data()
    //    .each(function (obj, index) {
    //        array_especialidades.push(obj);
    //    });
    table1
        .data()
        .each(function (obj, index) {
            array_componentes.push(obj);
        });
    table2
        .data()
        .each(function (obj, index) {
            array_celdas.push(obj);
        });
    table3
        .data()
        .each(function (obj, index) {
            array_servicios.push(obj);
        });
    table4
        .data()
        .each(function (obj, index) {
            array_empleados.push(obj);
        });
    if (arr_solicitud.length == 0) {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar una cotización");
        return;
    }
    if (ddlFPago == null) {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar una forma de pago");
        return;
    }
    if (ddlResponsable == null) {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar el responsable");
        return;
    }
    if (txtFecRecepcion == "") {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar la fecha de recepcion de la orden de compra del cliente");
        return;
    }
    if (txtFecVencimiento == "") {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar la fecha de vencimiento");
        return;
    }
    if (txtFecInicio == "") {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar la fecha estimada de inicio");
        return;
    }
    if (txtFecTermino == "") {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar la fecha estimada de termino");
        return;
    }
    if (ddlMoneda == null) {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar la moneda");
        return;
    }
    if (array_servicios.length == 0) {
        ShowWarningBox("Mensaje Sistemas", "Debe registrar por lo menos un servicio");
        return;
    }
    if ( array_componentes.length == 0) {
        ShowWarningBox("Mensaje Sistemas", "Debe registrar alguna especialidad o componente");
        return;
    }
    if (chk == 1 && array_celdas.length == 0) {
        ShowWarningBox("Mensaje Sistemas", "Debe registrar alguna celda de trabajo");
        return;
    }
    if (lblCotVVenta == "" || lblCotVVenta == 0) {
        ShowWarningBox("Mensaje Sistemas", "No es posible ingresar una orden de compra sin valor venta");
        return;
    }
    if (lblCotIGV == "" || lblCotIGV == 0) {
        ShowWarningBox("Mensaje Sistemas", "No es posible ingresar una orden de compra sin igv");
        return;
    }
    if (lblCotTotal == "" || lblCotTotal == 0) {
        ShowWarningBox("Mensaje Sistemas", "No es posible ingresar una orden de compra sin total");
        return;
    }
    // numsolicitud: arr_solicitud[0],
    var objCotizacion = {       
        idCot:arr_solicitud[0],
        entaller: chk,
        HorarioEmergencia: chk1,
        idmoneda: ddlMoneda,
        idresponsable: ddlResponsable,
        idfpago: ddlFPago,
        fvencimiento: txtFecVencimiento,
        fterminado: txtFecTermino,
        finicio: txtFecInicio,
        frecepcion: txtFecRecepcion,
        lcomponentes: array_componentes,
        lceldas: array_celdas,
        lservicios: array_servicios,
        lespecialidades: array_especialidades,
        lempleados: array_empleados,
        ltipocomponentes: array_tipocomponentes,
        valorventa: lblCotVVenta,
        igv: lblCotIGV,
        total: lblCotTotal
    };
    var oCotizacion = { objCotizacion: objCotizacion };
    CallMethod('../OCompra/GrabarOCompra', oCotizacion, onSuccess);
    function onSuccess(response) {
        console.log(response);
        if (response !="") {
            //falta coger el codigo de la orden de compra 
            
            ShowInfoBox("Información", "Orden de Compra generada " + response);
            setTimeout(function () { }, 4000);
            window.location.href = '../OCompra/Consultar';    
            
            
        } else {
            ShowInfoBox("Información", "No se pudo completar la operación");
        }

        //if (response.lsoluciones.length > 0) {
        //    $('#datatable_Soluciones').DataTable().clear().draw();
        //    $('#datatable_Soluciones').dataTable().fnAddData(response.lsoluciones);
        //} else {
        //    ShowInfoBox("Información", "No se pudo completar la operación");
        //}
    }
}