$(document).ready(function () {

    $('#cod_barras').prop('disabled', true);
    $('#cod_asociado').prop('disabled', true);
    $('#cod_interno').prop('disabled', true);
    $('#descripcion_corta').prop('disabled', true);
    $('#descripcion').prop('disabled', true);
    $('#cantidad_um').prop('disabled', true);
    $('#precio_compra').prop('disabled', true);
    $('#utilidad').prop('disabled', true);
    $('#precio_venta').prop('disabled', true);
    $('#tipo_articulo').prop('disabled', true);
    $('#stock').prop('disabled', true);
    $('#stock_min').prop('disabled', true);
    $('#stock_max').prop('disabled', true);
    $('#iva').prop('disabled', true);
    $('#fecha_registro').prop('disabled', true);
    $('#btnActualizar').prop('disabled', true);
    $('#txt-grp-sm').click(function () {
        var codigo_barras = $('#txt_codigo_barras').val();
        
        $.ajax({
            type: "Get",  
            url: "/Contabilidad/GetArticulos?codigo=" + codigo_barras,
            dataType: "Json",
            success: function (data) {
                toastr.success('La información se proceso de forma correcta');
                console.log(data);
            },
            error: function (xhr, textStatus, errorThrown) {
                toastr.error('La información no se pudo procesar');
                console.log(textStatus);    
            }
        })

        $('#btnActualizar').prop('disabled', false);
    });


})