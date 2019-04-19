$(document).ready(function () {
    CargarDatosGeneralesCotizacion();
    var arr_solicitud = [];
    CargarServicios();
    CargarEspecialidades();
    CargarComponentes();
    CargarCeldas();
    CargarComponenteTipo();
    CargarSoluciones();
    CargarCotCelda();
    CargarCotEmpleados();
    CargarCotEspecialidad();
    CargarCotComponentes();
    CargarCotComponenteTipo();
});
function CargarCotCelda() {
    var columns = [
        { "data": "id" },
        { "data": "nombre" },
        { "data": "costosoles" },
        { "data": "cantidad" },
        { "data": "obtenidos" },
        { "data": "duracion" },
        { "data": "horas" },
        { "data": "vventa" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_CotCeldas', [], columns, false, false, "", false);
}
function CargarCotEmpleados() {
    var columns = [
        { "data": "codigo" },
        { "data": "nombre" },
        { "data": "especialidad" },
        { "data": "costosoles" },
        { "data": "cantidad" },
        { "data": "duracion" },
        { "data": "horas" },
        { "data": "hnormal" },
        { "data": "hextendido" },
        { "data": "vventa" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_CotEmpleados', [], columns, false, false, "", false);
}
function CargarCotEspecialidad() {
    var columns = [
        { "data": "nombre" },
        { "data": "cantidad" },
        { "data": "obtenidos" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_CotEspecialidad', [], columns, false, false, "", true);
}
function CargarCotComponenteTipo() {
    var columns = [
        { "data": "nombre" },
        { "data": "cantidad" },
        { "data": "obtenidos" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_CotComponenteTipo', [], columns, false, false, "", true);
}

function CargarCotComponentes() {
    var columns = [
        { "data": "codigo" },
        { "data": "nombre" },
        { "data": "tipocomponente" },
        { "data": "costosoles" },
        { "data": "cantidad" },
        { "data": "obtenidos" },
        { "data": "duracion" },
        { "data": "horas" },
        { "data": "vventa" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_CotComponentes', [], columns, false, false, "", false);
}
function CargarSoluciones() {

    var columns = [{
        'align': 'center',
        'className': 'dt-body-center',
        'render': function (data, type, dataItem, meta) {
            return '<div><button class="btn btn-default"><a href="javascript:SeleccionePropuesta(\'' + dataItem.codigo + '\');">' +
                'Seleccione ' +
                '</a></button></div>';
        }
    },
        { "data": "idCot" },
        { "data": "codigo" },
        { "data": "total" },
        { "data": "rentabilidad" },
        { "data": "calidad" }
    ];
    //$('#datatable_Servicios').DataTable().clear().draw();
    //$('#datatable_Servicios').dataTable().fnAddData(data);
    CargarTabla('#datatable_Soluciones', [], columns, false, false, "",true);
}
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
function AgregarEspecialidad() {
    var html =
        '<hr class="simple" />' +
        '<div class="form-group row">' +
        '<label for="ddl" class="col-sm-3 col-form-label">Especialidad</label>' +
        '<select id="ddl" name="ddl" class="col-sm-7 bg-color-blueDark">' +
        '<option value="0" selected="selected" disabled="disabled">[Seleccione Especialidad]</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group row">' +
        '<label for= "txtCantidad" class= "col-sm-3 col-form-label" > Cantidad</label >' +
        '<input type="text" class="col-sm-7 bg-color-blueDark" id="txtCantidad" value="" />' +
        '</div>';
    CargarModal("Datos Especialidad", html, "AceptarEspecialidad()");
    var par = { tipo: 5 };
    var data = CallMethod('../Parametro/ObtenerDatosRecurso', par, onSuccess);
    function onSuccess(response) {
        var ddl = $("#ddl");
        $.each(response.lespecialidades, function (key, value) {
            ddl.append($('<option>', { value: value.idespecialidad, text: value.nombre }));
        });
    }
}
function AceptarEspecialidad() {

    $('#exampleModal').modal('toggle');
    var pcantidad = $('#txtCantidad').val();
    var arr = $('#ddl').val();
    var pnom = $("#ddl option:selected").text();

    var lespecialidades = [];
    var oEspecialidad = { idespecialidad: arr[0], nombre: pnom, cantidad: pcantidad };
    lespecialidades.push(oEspecialidad);

    if (pcantidad == "") {
        ShowWarningBox("Mensaje Sistemas", "Debe ingresar una cantidad");
        return;
    }
    var tdata = $('#datatable_Especialidades').DataTable();
    tdata
        .data()
        .each(function (obj, index) {
            tdata.push(obj);
        });
    var poner = 1;
    var i = 0, len = tdata.length;
    while (i < len) {
        if (tdata[i].idespecialidad == arr[0]) {
            poner = 0;
            ShowWarningBox("Mensaje Sistemas", "La especialidad no puede ser agregada nuevamente");
            return;
        }
        i = i + 1;
    }
    if (poner == 1) {
        $('#datatable_Especialidades').dataTable().fnAddData(lespecialidades);
    }
}
function AgregarComponente() {

    var html = '<div class="widget-body no-padding">' +
        '<table id = "datatable_BComponente" class="table table-striped table-bordered table-hover" width = "100%" > ' +
        '<thead>' +
        '<tr style="background-color:#244e40">' +
        '<td style="width:6%"></td>' +
        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar codigo" />' +
        '</th>' +
        '<th class="hasinput" style="width:10%">' +
        '<input type="text" class="form-control" placeholder="Filtrar componente" />' +
        '</th>' +
        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar tipo" />' +
        '</th>' +
        '<th class="hasinput" style="width:5%">' +
        '<input type="text" class="form-control" placeholder="Filtrar costo " />' +
        '</th>' +
        '<th class="hasinput" style="width:5%">' +
        '<input type="text" class="form-control" placeholder="Filtrar cantidad " />' +
        '</th>' +
        '</tr>' +
        '<tr style="background-color:#244e40">' +
        '<th>Opc</th>' +
        '<th>codigo</th>' +
        '<th>componente</th>' +
        '<th>tipo</th>' +
        '<th>costo</th>' +        
        '<th>cantidad</th>' +
        '</tr>' +
        '</thead>' +
        '<tbody></tbody>' +
        '</table> ' +
        '<br/>' +
        '</div>';
    CargarModalTabla("Componentes", html, "AgregarComponente()",true);
    var par = { tipo: 2 };
    CallMethod('../Parametro/ObtenerDatosRecurso',par, onSuccess);
    function onSuccess(response) {
        var columns = [{
            'align': 'center',
            'className': 'dt-body-center',
            'render': function (data, type, dataItem, meta) {
                return '<div><button id="btnN" class="btn btn-default"><a href="javascript:Seleccionar1(\'' + $('#btnN').parents('tr').attr('id') +'\');">' +
                    'Seleccionar ' +                    
                    '</a></button>' +
                    //'<input type="text" id="txtctn" style="background-color:#244e40" />' +
                '</div > ';
            }
               //'render': function (data, type, row) {
               //     return '<div><button class="btn btn-default"><a href="javascript:Seleccionar1(\'' + data.cantidad +'\');">' +
               //     'Seleccionar ' +                    
               //     '</a></button>' +                 
               // '</div > ';
            //},
        },
        { "data": "codigo" },
        { "data": "nombre" },
        { "data": "tipocomponente" },
        { "data": "costosoles" },
        { "data": "cantidad" }
        ];
        //$('#datatable_Servicio').DataTable().clear().draw();  
        //$('#datatable_Servicio').dataTable().fnAddData(response.Servicios);
        CargarTabla('#datatable_BComponente', response.lcomponentes, columns, true, false);


        //var table = $('#datatable_BComponente').DataTable();

        //$('#datatable_BComponente tbody').on('click', 'tr', function () {
        //    var data = table.row(this).data();
        //    alert('You clicked on ' + data[0] + '\'s row');
        //});


        $("#datatable_BComponente td:eq(6)").click(function () {
            var OriginalContent = $(this).text();
            //var dato = $(this).find('td:first').html();
            //$('#txtctn').val(dato);


            $(this).addClass("cellEditing");
            $(this).html('<input type="text" style="background-color:#244e40" value="' + OriginalContent + '"  style="width: 100%"/>');
            $(this).children().first().focus();

            $(this).children().first().keypress(function (e) {               
                if (e.which == 13) {
                    var newContent = $(this).val();
                    $(this).parent().text(newContent);
                    $(this).parent().removeClass("cellEditing");
                
                } 
            });

            $(this).children().first().blur(function () {
                $(this).parent().text(OriginalContent);
                $(this).parent().removeClass("cellEditing");
            });
        });

        //$('#datatable_BComponente tr').each(function () {
        //    var customerId = $(this).find("td:eq(6)").html();
        //});



        //var table;

        //$("#datatable_BComponente").on("click", "td .fa.fa-minus-square", function (e) {
        //    table.row($(this).closest("tr")).remove().draw();
        //})

        //$("#datatable_BComponente").on('mousedown.edit', "i.fa.fa-pencil-square", function (e) {

        //    $(this).removeClass().addClass("fa fa-envelope-o");
        //    var $row = $(this).closest("tr").off("mousedown");
        //    var $tds = $row.find("td").not(':first').not(':last');

        //    $.each($tds, function (i, el) {
        //        var txt = $(this).text();
        //        $(this).html("").append("<input type='text' value=\"" + txt + "\">");
        //    });

        //});
    }



    //var html =
    //    '<hr class="simple" />' +
    //    '<div class="form-group row">' +
    //    '<label for="ddl" class="col-sm-3 col-form-label">Componente</label>' +
    //    '<select id="ddl" name="ddl" class="col-sm-7 bg-color-blueDark">' +
    //    '<option value="0" selected="selected" disabled="disabled">[Seleccione Componente]</option>' +
    //    '</select>' +
    //    '</div>' +
    //    '<div class="form-group row">' +
    //    '<label for= "txtCantidad" class= "col-sm-3 col-form-label" > Cantidad</label >' +
    //    '<input type="text" class="col-sm-7 bg-color-blueDark" id="txtCantidad" value="" />' +
    //    '</div>';
    //CargarModal("Datos Componente", html, "AceptarComponente()");
    //var par = { tipo: 2 };
    //var data = CallMethod('../Parametro/ObtenerDatosRecurso', par, onSuccess);
    //function onSuccess(response) {
    //    var ddl = $("#ddl");
    //    $.each(response.lcomponentes, function (key, value) {
    //        ddl.append($('<option>', { value: value.idcomponente, text: value.nombre }));
    //    });
    //}
}
function Seleccionar1(codigo) {
    var i = 0;
    var d = 0;
}

function AgregarTipoComponente() {
    var html =
        '<hr class="simple" />' +
        '<div class="form-group row">' +
        '<label for="ddl" class="col-sm-3 col-form-label">Tipo Componente</label>' +
        '<select id="ddl" name="ddl" class="col-sm-7 bg-color-blueDark">' +
        '<option value="0" selected="selected" disabled="disabled">[Seleccione Tipo Componente]</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group row">' +
        '<label for= "txtCantidad" class= "col-sm-3 col-form-label" > Cantidad</label >' +
        '<input type="text" class="col-sm-7 bg-color-blueDark" id="txtCantidad" value="" />' +
        '</div>';
    CargarModal("Datos Tipo Componente", html, "AceptarTipoComponente()");
    var par = { tipo: 3 };
    var data = CallMethod('../Parametro/ObtenerDatosRecurso', par, onSuccess);
    function onSuccess(response) {
        var ddl = $("#ddl");
        $.each(response.ltipocomponentes, function (key, value) {
            ddl.append($('<option>', { value: value.id, text: value.nombre }));
        });
    }
}
function AceptarTipoComponente() {

    $('#exampleModal').modal('toggle');
    var pcantidad = $('#txtCantidad').val();
    var arr = $('#ddl').val();
    var pnomtipo = $("#ddl option:selected").text();
    
    var ltipos = [];
    var oComponenteTipo = { id: arr, nombre: pnomtipo ,cantidad:pcantidad};
    ltipos.push(oComponenteTipo);
    if (pcantidad == "") {
        ShowWarningBox("Mensaje Sistemas", "Debe ingresar una cantidad");
        return;
    }

    var tdata = $('#datatable_TipoComponente').DataTable();
    tdata
        .data()
        .each(function (obj, index) {
            tdata.push(obj);
        });
    var poner = 1;
    var i = 0, len = tdata.length;
    while (i < len) {
        if (tdata[i].id == arr) {
            poner = 0;
            ShowWarningBox("Mensaje Sistemas", "El tipo de componente no puede ser agregada nuevamente");
            return;
        }
        i = i + 1;
    }
    if (poner == 1) {
        $('#datatable_TipoComponente').dataTable().fnAddData(ltipos);
    }
}

function AgregarCelda() {
    var html =
        '<hr class="simple" />' +
        '<div class="form-group row">' +
        '<label for="ddlLugar" class="col-sm-3 col-form-label">Celda de Trabajo</label>' +
        '<select id="ddlLugar" name="ddlLugar" class="col-sm-7 bg-color-blueDark">' +
        '<option value="0" selected="selected" disabled="disabled">[Seleccione Celda]</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group row">' +
        '<label for= "txtm2" class= "col-sm-3 col-form-label" > Metros Cuadrados</label >' +
        '<input type="text" class="col-sm-7 bg-color-blueDark" id="txtm2" value="" />' +
        '</div>'+
        '<div class="form-group row">' +
        '<label for= "txtCostoSoles" class= "col-sm-3 col-form-label" > Costo Soles</label >' +
        '<input type="text" class="col-sm-7 bg-color-blueDark" id="txtCostoSoles" value="" />' +
        '</div>'+
        '<div class="form-group row">' +
        '<label for= "txtCantidad" class= "col-sm-3 col-form-label" > Cantidad</label >' +
        '<input type="text" class="col-sm-7 bg-color-blueDark" id="txtCantidad" value="" />' +
        '</div>';
    CargarModal("Datos Celda de Trabajo", html, "AceptarCelda()");
    var par = { tipo: 1 };
    var data = CallMethod('../Parametro/ObtenerDatosRecurso', par, onSuccess);
    function onSuccess(response) {
        var ddl = $("#ddlLugar");
        $.each(response.lceldas, function (key, value) {
            ddl.append($('<option>', { value: value.idvalor, text: value.nombre }));
        });
    }


    $("#ddlLugar").change(function () {
        var arr_ser = $('#ddlLugar').val().split("_");
        $("#txtCostoSoles").val(arr_ser[1]);
        $("#txtm2").val(arr_ser[2]);
    });
}
function AceptarCelda() {

    $('#exampleModal').modal('toggle');
    var pcantidad = $('#txtCantidad').val();
    var pcosto = $('#txtCostoSoles').val();
    var pm2 = $('#txtm2').val();
    var pmcuadrados = $('#txtm2').val();
    
    var pnomcelda = $("#ddlLugar option:selected").text();

    var arr_lug = $('#ddlLugar').val();
    
    var lceldas = [];
    var oCelda = { id: arr_lug[0], nombre: pnomcelda , cantidad: pcantidad, costosoles: pcosto, mcuadrados:pm2 };
    lceldas.push(oCelda);

    if (pcantidad == "") {
        ShowWarningBox("Mensaje Sistemas", "Debe ingresar una cantidad");
        return;
    }
    var arr = $('#datatable_Celda').DataTable();
    arr
        .data()
        .each(function (obj, index) {
            arr.push(obj);
        });
    var poner = 1;
    var i = 0, len = arr.length;
    while (i < len) {
        if (arr[i].id == arr_lug[0]) {
            poner = 0;
            ShowWarningBox("Mensaje Sistemas", "La celda de trabajo no puede ser agregada nuevamente");
            return;
        }
        i = i + 1;
    }
    if (poner == 1) {
        $('#datatable_Celda').dataTable().fnAddData(lceldas);
    }
    //var data = CallMethod('../Servicio/Agregar', oServicio, onSuccess);
    //function onSuccess(response) {
    //    if (response.n > 0) {
    //        CargarConsulta();
    //        ShowSuccessBox("Información", "Se agregó un nuevo resgistro");
    //    } else {
    //        ShowInfoBox("Información", "No se completó la operación");
    //    }
    //}
}
function AgregarServicio() {    
    var html = 
        '<hr class="simple" />' +
        '<div class="form-group row">' +
        '<label for="ddlTipo" class="col-sm-3 col-form-label">Tipo Servicio</label>' +
        '<select id="ddlTipo" name="ddlTipo" class="col-sm-7 bg-color-blueDark">' +
        '<option value="0" selected="selected" disabled="disabled">[Seleccione Tipo Servicio]</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group row">' +
        '<label for= "txtCostoSoles" class= "col-sm-3 col-form-label" > Costo Soles</label >' +
        '<input type="text" class="col-sm-7 bg-color-blueDark" id="txtCostoSoles" value="" />' +
        '</div>'+
        '<div class="form-group row">'+
        '<label for= "txtCantidad" class= "col-sm-3 col-form-label" > Cantidad</label >'+
        '<input type="text" class="col-sm-7 bg-color-blueDark" id="txtCantidad" value="" />' +
        '</div>';
    CargarModal("Datos Servicio", html, "AceptarServicio()");
    //var data = CallMethod('../Parametro/ObtenerServicioTipo', [], onSuccess);
    var par = { tipo: 6 };
    var data = CallMethod('../Parametro/ObtenerDatosRecurso', par, onSuccess);
 
    function onSuccess(response) {     
        
        var ddlTipo = $("#ddlTipo");
        $.each(response.lservicios, function (key, value) {
            ddlTipo.append($('<option>', { value: value.idvalor, text: value.nombre }));
        });
    }

    $("#ddlTipo").change(function () {                
        var arr_ser = $('#ddlTipo').val().split("_");
        $("#txtCostoSoles").val(arr_ser[2]);
    });

}
function AceptarServicio() {

    $('#exampleModal').modal('toggle');
    var pcantidad = $('#txtCantidad').val();
    var pcosto = $('#txtCostoSoles').val();
    var pnomservicio = $("#ddlTipo option:selected").text();
    var arr_ser = $('#ddlTipo').val();
    var lservicios = [];
    var oServicio = { id: arr_ser[0], nombre: pnomservicio, cantidad: pcantidad, costosoles: pcosto };
    lservicios.push(oServicio);
    
    if (pcantidad == "") {
        ShowWarningBox("Mensaje Sistemas", "Debe ingresar una cantidad");
        return;
    }
    var data_ser = $('#datatable_Servicios').DataTable();
    data_ser
        .data()
        .each(function (obj, index) {
            data_ser.push(obj);
        });
    var poner = 1;    
    var i = 0, len = data_ser.length;    
    while (i < len) {
        if (data_ser[i].id == arr_ser[0]) {                        
            poner = 0;
            ShowWarningBox("Mensaje Sistemas", "El servicio no puede ser agregado nuevamente");
            return;
        }
        i = i + 1;
    }
    if (poner == 1) {
        $('#datatable_Servicios').dataTable().fnAddData(lservicios);
    }
}
function BuscarSolicitud() {


    var html = '<div class="widget-body no-padding">' +
        '<table id = "datatable_Solicitud" class="table table-striped table-bordered table-hover" width = "100%" > ' +
        '<thead>' +
        '<tr style="background-color:#244e40">' +
        '<td style="width:6%"></td>' +
        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar codigo" />' +
        '</th>' +
        '<th class="hasinput" style="width:10%">' +
        '<input type="text" class="form-control" placeholder="Filtrar registro" />' +
        '</th>' +
        '<th class="hasinput" style="width:30%">' +
        '<input type="text" class="form-control" placeholder="Filtrar en taller" />' +
        '</th>' +
        '<th class="hasinput" style="width:5%">' +
        '<input type="text" class="form-control" placeholder="Filtrar equipo" />' +
        '</th>' +
        '<th class="hasinput" style="width:5%">' +
        '<input type="text" class="form-control" placeholder="Filtrar cliente" />' +
        '</th>' +
        '</tr>' +
        '<tr style="background-color:#244e40">' +
        '<th>Opc</th>' +
        '<th>codigo</th>' +
        '<th>fregistro</th>' +
        '<th>entaller</th>' +
        '<th>equipo</th>' +
        '<th>cliente</th>' +
        '</tr>' +
        '</thead>' +
        '<tbody></tbody>' +
        '</table> ' +
        '<br/>' +
        '</div>';
    CargarModalTabla("Solicitud", html, "Agregar()",false);
    CallMethod('../Solicitud/ConsultarSolicitudes', [], onSuccess);
    function onSuccess(response) {
        var columns = [{
            'align': 'center',
            'className': 'dt-body-center',
            'render': function (data, type, dataItem, meta) {
                return '<div><button class="btn btn-default"><a href="javascript:Seleccionar(\'' + dataItem.codigo + '\');">' +
                    'Seleccionar ' +
                    '</a></button></div>';
            }
        },
        { "data": "codigo" },
        { "data": "fregistro" },
        { "data": "entaller" },
        { "data": "equipo" },
        { "data": "cliente" }
        ];
        //$('#datatable_Servicio').DataTable().clear().draw();  
        //$('#datatable_Servicio').dataTable().fnAddData(response.Servicios);
        CargarTabla('#datatable_Solicitud', response.lsolicitudes, columns, false, false);
    }
}

function Seleccionar(num_solicitud) {

    $('#exampleModal').modal('toggle');
    arr_solicitud = [];
    arr_solicitud.push(num_solicitud);
    var oSolicitud = { pcodsolicitud: num_solicitud };
    CallMethod('../Solicitud/ConsultarSolicitud', oSolicitud, onSuccess);
    function onSuccess(response) {
        $("#txtNroSolicitud").val(response.codigo);
        $("#txtEquipo").val(response.equipo);
        if (response.entaller == "1") {
            $('#chkLugarServicio').val('true');
        }
        $("#txtCliente").val(response.cliente);
        $('#datatable_Servicios').DataTable().clear().draw();
        if (response.requerimientos_basicos.lservicios.length > 0) {
            $('#datatable_Servicios').dataTable().fnAddData(response.requerimientos_basicos.lservicios);
        }
        $('#datatable_Componentes').DataTable().clear().draw();
        if (response.requerimientos_basicos.lcomponentes.length > 0) {
            $('#datatable_Componentes').dataTable().fnAddData(response.requerimientos_basicos.lcomponentes);
        }
        $('#datatable_TipoComponente').DataTable().clear().draw();
        if (response.requerimientos_basicos.ltipocomponentes.length > 0) {
            $('#datatable_TipoComponente').dataTable().fnAddData(response.requerimientos_basicos.ltipocomponentes);
        }        
        $('#datatable_Especialidades').DataTable().clear().draw();
        if (response.requerimientos_basicos.lespecialidades.length > 0) {
            $('#datatable_Especialidades').dataTable().fnAddData(response.requerimientos_basicos.lespecialidades);
        }
    }
}
function grabar() {

    var array_especialidades = [];
    var array_componentes = [];
    var array_celdas = [];
    var array_servicios = [];
    var array_tipocomponentes = [];
    var ddlResponsable = $('#ddlResponsable').val();
    var ddlFPago = $('#ddlFPago').val();    
    var ddlMoneda = $('#ddlMoneda').val();
    var txtFecVencimiento = $('#txtFecVencimiento').val();
    var txtFecTermino = $('#txtFecTermino').val();
    var txtFecInicio = $('#txtFecInicio').val();

    var chk = 0;
    if ($('#chkLugarServicio').prop('checked')) {
        chk = 1;
    }
    var chk1 = 0;
    if ($('#chkHorario').prop('checked')) {
        chk1 = 1;
    }
    


    var table = $('#datatable_Especialidades').DataTable();
    var table1 = $('#datatable_Componentes').DataTable();
    var table2 = $('#datatable_Celda').DataTable();
    var table3 = $('#datatable_Servicios').DataTable();
    var table4 = $('#datatable_TipoComponente').DataTable();
    table
        .data()
        .each(function (obj, index) {
            array_especialidades.push(obj);
        });
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
            array_tipocomponentes.push(obj);
        });
    if (arr_solicitud.length == 0) {
        ShowWarningBox("Mensaje Sistemas", "Debe seleccionar una solicitud de servicio");
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
    if (array_especialidades.length == 0 || array_componentes.length == 0) {
        ShowWarningBox("Mensaje Sistemas", "Debe registrar alguna especialidad o componente");
        return;
    }
    if (chk == 1 && array_celdas.length == 0) {
        ShowWarningBox("Mensaje Sistemas", "Debe registrar alguna celda de trabajo");
        return;
    }
    var objCotizacion = {
        numsolicitud: arr_solicitud[0],
        entaller: chk,
        HorarioEmergencia:chk1,
        idmoneda: ddlMoneda,
        idresponsable: ddlResponsable,
        idfpago: ddlFPago,
        fvencimiento: txtFecVencimiento,
        fterminado: txtFecTermino,
        finicio: txtFecInicio,
        lcomponentes: array_componentes,
        lceldas: array_celdas,
        lservicios: array_servicios,
        lespecialidades: array_especialidades,
        ltipocomponentes: array_tipocomponentes
    };
    var oCotizacion = { objCotizacion: objCotizacion };
    CallMethod('../Cotizacion/GrabarCotizacion', oCotizacion, onSuccess);
    function onSuccess(response) {
        if (response.lsoluciones.length > 0) {
            $('#datatable_Soluciones').DataTable().clear().draw();
            $('#datatable_Soluciones').dataTable().fnAddData(response.lsoluciones);
        } else {
            ShowInfoBox("Información", "No se pudo completar la operación");
        }
    }   
}
$("#btnRegresarSoluciones").click(function () {
    ViewAndHide("#divCotizacion", "#principal");
});
$("#btnAceptarCotizacionPropuesta").click(function () {
   // ViewAndHide("#principal", "#divCotizacion");
  //  window.location.href = '../Cotizacion/Consultar'; 
    var id = $('#hdnidCot').val();
    var pcotizacion = { pcodcotizacion: id };
    CallMethod('../Cotizacion/AceptarPropuesta', pcotizacion, onSuccess);
    function onSuccess(response) {
        if (response != "") {
            ShowSuccessBox("Información", "Se generó la Cotización " + response);
            window.location.href = '../Cotizacion/Consultar'; 
        } else {
            ShowErrorBox("Atención", "Ocurrió un error, si el error persiste reportarlo con Sistemas");
        }
    }   
});
function SeleccionePropuesta(codigo) {
    ViewAndHide('#principal', '#divCotizacion');
    var oCotizacionPropuesta = { pcodpropuesta: codigo };
    CallMethod('../Cotizacion/ConsultarCotizacion', oCotizacionPropuesta, onSuccess);
    function onSuccess(response) {
        $("#lblNroCotizacion").val(response.numCotizacion);
        $("#lblCotEquipo").val(response.nomEquipo);
        $("#lblCotCliente").val(response.nomCliente);
        $("#lblCotFInicio").val(response.finicio);
        $("#lblCotFFin").val(response.fterminado);
        $("#lblCotVVenta").val(response.valorventa);
        $("#lblCotIGV").val(response.igv);
        $("#lblCotTotal").val(response.total);
        $("#lblCotServicio").val(response.servicio);
        $("#hdnidCot").val(response.idCot);
        $('#datatable_CotCeldas').DataTable().clear().draw();
        if (response.lceldas.length > 0) {
            $('#datatable_CotCeldas').dataTable().fnAddData(response.lceldas);
        }
        $('#datatable_CotComponentes').DataTable().clear().draw();
        if (response.lcomponentes.length > 0) {
            $('#datatable_CotComponentes').dataTable().fnAddData(response.lcomponentes);
        }
        $('#datatable_CotEmpleados').DataTable().clear().draw();
        if (response.lempleados.length > 0) {
            $('#datatable_CotEmpleados').dataTable().fnAddData(response.lempleados);
        }
        $('#datatable_CotEspecialidad').DataTable().clear().draw();
        if (response.lespecialidades.length > 0) {
            $('#datatable_CotEspecialidad').dataTable().fnAddData(response.lespecialidades);
        }
        $('#datatable_CotComponenteTipo').DataTable().clear().draw();
        if (response.ltipocomponentes.length > 0) {
            $('#datatable_CotComponenteTipo').dataTable().fnAddData(response.ltipocomponentes);
        }
    } 
};
