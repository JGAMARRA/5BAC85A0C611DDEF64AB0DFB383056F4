$(document).ready(function () {
    CargarConsulta();
});
function CargarConsulta() {
    var oPar = { ptipo: 1 };
    var data = CallMethod('../OT/ConsultarOT',oPar, onSuccess);
    function onSuccess(response) {
        var columns = [{
            'align': 'center',
            'className': 'dt-body-center',
            'render': function (data, type, dataItem, meta) {
                return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.id + '\');"> Eliminar </a></button></div>';
            }
        },
        { "data": "id" },
        { "data": "codigo" },
        { "data": "fecRecepcion" },
        { "data": "cliente" },
        { "data": "equipo" },
        { "data": "responsable" },
        { "data": "total" },
        { "data": "moneda" },
        { "data": "estadoOT" },
            { "data": "nro_oc_ref" }
        ];
        //$('#datatable_Servicio').DataTable().clear().draw();  
        //$('#datatable_Servicio').dataTable().fnAddData(response.Servicios);
        CargarTabla('#datatable_OT', response.lots, columns, false, false, "", true);
    }
}
function eliminar(id) {
    var par = { idcot: id };
    CallMethod('../OCompra/EliminarOCompra', par, onSuccess);
    function onSuccess(response) {
        if (response == 1) {
            var oPar = { ptipo: 1 };
            CallMethod('../OT/ConsultarOT', [], onSuccess);
            function onSuccess(response1) {
                $('#datatable_OT').DataTable().clear().draw();
                $('#datatable_OT').dataTable().fnAddData(response1.lots);
            }

            ShowSuccessBox("Información", "Se anuló la orden de trabajo y se liberó la cotización de referencia. ");

        } else if (response == 2) {
            ShowSuccessBox("Información", "La orden de compra indicada ya se encuentra anulada");
        } else {
            ShowErrorBox("Atención", "Ocurrió un error, si el error persiste reportarlo con Sistemas");
        }
    }

}

