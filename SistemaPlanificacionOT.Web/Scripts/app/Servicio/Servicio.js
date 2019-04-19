$(document).ready(function () {

  
    CargarConsulta();
    function eliminar(id) {
    }



});
function CargarConsulta() {
    var data = CallMethod('../Servicio/Obtener', [], onSuccess);
    function onSuccess(response) {
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
        { "data": "costosoles" },
        { "data": "moneda" }
        ];
        //$('#datatable_Servicio').DataTable().clear().draw();  
        //$('#datatable_Servicio').dataTable().fnAddData(response.Servicios);
        CargarTabla('#datatable_Servicio', response.Servicios, columns, false, false);
    }
}
function Crear() {
    var html = '<div class="form-group row">' +
        '<label for= "txt" class="col-sm-3 col-form-label"> Descripción</label>' +
        '<span class="col-sm-1"></span>' +
        '<input type="text" id="txt" >' +
        '</div>' +
        '<hr class="simple" />' +
        '<div class="form-group row">' +
        '<label for="ddlTipo" class="col-sm-3 col-form-label">Tipo Servicio</label>' +
        '<select id="ddlTipo" name="ddlTipo" class="col-sm-5 bg-color-blueDark">' +
        '<option value="0" selected="selected" disabled="disabled">[Seleccione Tipo Servicio]</option>' +
        '</select>' +
        '</div>';
    CargarModal("Agregar Servicio", html,"Agregar()");
    var data = CallMethod('../Parametro/ObtenerServicioTipo', [], onSuccess);
    function onSuccess(response) {
        var ddlTipo = $("#ddlTipo");
        $.each(response.ltiposervicios, function (key, value) {
            ddlTipo.append($('<option>', { value: value.id, text: value.descripcion }));
        });
    }

}

function Agregar() {
    
    $('#exampleModal').modal('toggle'); 
    var descripcion = $('#txt').val();
    var ddlTipo = $('#ddlTipo').val();
    var oServicio = { tiposervicio: ddlTipo, nombre: descripcion };
    var data = CallMethod('../Servicio/Agregar', oServicio, onSuccess);
    function onSuccess(response) {
        if (response.n > 0) {
            CargarConsulta();
            ShowSuccessBox("Información", "Se agregó un nuevo resgistro");
        } else {
            ShowInfoBox("Información", "No se completó la operación");
        }
    }
}
