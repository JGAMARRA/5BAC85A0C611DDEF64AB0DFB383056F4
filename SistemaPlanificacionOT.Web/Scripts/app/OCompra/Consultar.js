$(document).ready(function () {
    CargarConsulta();
});
function CargarConsulta() {
    var oPar = {ptipo:1}
    var data = CallMethod('../OCompra/ConsultarOCompra', oPar, onSuccess);
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
        { "data": "codigo" },
        { "data": "fecRecepcion" },        
        { "data": "cliente" },
        { "data": "equipo" },
        { "data": "responsable" },
        { "data": "total" },
        { "data": "moneda" },
            { "data": "estadoOC" },
            { "data": "ncotref" }
        ];
        //$('#datatable_Servicio').DataTable().clear().draw();  
        //$('#datatable_Servicio').dataTable().fnAddData(response.Servicios);
        CargarTabla('#datatable_OCompra', response.lorden_compra, columns, false, false, "", true);
    }
}
function eliminar(id) {
    var par = { idcot: id };
    CallMethod('../OCompra/EliminarOCompra', par, onSuccess);
    function onSuccess(response) {
        if (response == 1) {
            var oPar = { ptipo: 1 }
            CallMethod('../OCompra/ConsultarOCompra', oPar, onSuccess);
            function onSuccess(response1) {
                $('#datatable_OCompra').DataTable().clear().draw();
                $('#datatable_OCompra').dataTable().fnAddData(response1.lorden_compra);
            }

            ShowSuccessBox("Información", "Se anuló la orden de compra y se liberó la cotización de referencia. ");

        } else if (response == 2) {
            ShowSuccessBox("Información", "No es posible eliminar una orden de compra en estado anulada o en proceso");
        } else {
            ShowErrorBox("Atención", "Ocurrió un error, si el error persiste reportarlo con Sistemas");
        }
    }

}