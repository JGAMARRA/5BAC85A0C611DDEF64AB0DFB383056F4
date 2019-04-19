$(document).ready(function () {
    CargarConsulta();
    //function eliminar(id) {
    //}
});
function CargarConsulta() {
    var oPar = { ptipo: 1 };
    var data = CallMethod('../Cotizacion/ConsultarCotizaciones',oPar, onSuccess);
    function onSuccess(response) {
        var columns = [{
            'align': 'center',
            'className': 'dt-body-center',
            'render': function (data, type, dataItem, meta) {
                return '<div><button class="btn btn-default"><a href="javascript:eliminar(\'' + dataItem.idCotizacionCab + '\');">' +
                    'Eliminar ' +
                    '</a></button></div>';
            }
        },
            { "data": "idCotizacionCab" },
            { "data": "nCotizacion" },
            { "data": "fecRegistro" },
            { "data": "fecVencimiento" },
            { "data": "cliente" },
            { "data": "equipo" },
            { "data": "responsable" },
            { "data": "total" },
            { "data": "moneda" },
            { "data": "estado" },            
            { "data": "codigosolicitud" }
        ];
        //$('#datatable_Servicio').DataTable().clear().draw();  
        //$('#datatable_Servicio').dataTable().fnAddData(response.Servicios);
        CargarTabla('#datatable_Cotizacion', response.lcotizaciones, columns, false, false,"",true);
    }
}
function eliminar(idCotizacionCab) {
    var par = { idcot: idCotizacionCab };
    CallMethod('../Cotizacion/EliminarCotizacion', par, onSuccess);
    function onSuccess(response) {
        if (response == 1) {
            var oPar = { ptipo: 1 };
            CallMethod('../Cotizacion/ConsultarCotizaciones',oPar, onSuccess);
            function onSuccess(response1) {
                $('#datatable_Cotizacion').DataTable().clear().draw();  
                $('#datatable_Cotizacion').dataTable().fnAddData(response1.lcotizaciones);
            }
            
            ShowSuccessBox("Información", "Se anuló la cotización y se liberó la solicitud de referencia. ");

        } else if (response == 2) {
            ShowSuccessBox("Información", "No es posible eliminar una cotizacion en estado anulada o en proceso");
        } else {
            ShowErrorBox("Atención", "Ocurrió un error, si el error persiste reportarlo con Sistemas");
        }
    }
    
}
function VerCotizacion(idcot) {
    var url = '../Reporte/CreatePdf?idcotizacion=' + idcot;
    window.open(url,'_blank');
}