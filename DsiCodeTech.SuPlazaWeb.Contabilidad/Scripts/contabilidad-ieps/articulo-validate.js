
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
    $('#IdTiposImpuestos').prop('disabled', true);
    $('#porcentaje').prop('disabled', true);
    $('#btnActualizar').prop('disabled', true);

    $('#txt-grp-sm').click(function () {

        var codigo_barras = $('#txt_codigo_barras').val();

        if (codigo_barras === '') {
            toastr.info('Ingresa un codigo de barras valido');
        }
        else {
            $.ajax({
                type: "Get",
                url: "/api/articulos/getcodigobarras?codigo=" + codigo_barras,
                dataType: "Json",
                success: function (data) {

                    if (data == null) {
                        toastr.error('La información no se pudo procesar, verifica el codigo de barras por favor!!');
                    }
                    else
                    {
                        $('#cod_barras').val(data.cod_barras);
                        $('#cod_asociado').val(data.cod_asociado);
                        $('#cod_interno').val(data.cod_interno);
                        $('#descripcion_corta').val(data.descripcion_corta);
                        $('#descripcion').val(data.descripcion);
                        $('#cantidad_um').val(data.cantidad_um);
                        $('#precio_compra').val(data.precio_compra);
                        $('#utilidad').val(data.utilidad);
                        $('#precio_venta').val(data.precio_venta);
                        $('#tipo_articulo').val(data.tipo_articulo);
                        $('#stock').val(data.stock);
                        $('#stock_min').val(data.stock_min);
                        $('#stock_max').val(data.stock_max);
                        $('#iva').val(data.iva);
                        $('#fecha_registro').val(data.fecha_registro);
                        $('#IdTiposImpuestos').prop('disabled', false);
                        $('#porcentaje').prop('disabled', false);
                        toastr.success('La información se proceso de forma correcta');
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    toastr.error('La información no se pudo procesar');
                    console.log(textStatus);
                }
            })

            //$('#btnActualizar').prop('disabled', false);
        }

    });

    $('#btnActualizar').click(function () {

        //var ArticuloDto = {};
        var ImpuestoDto = {};

        ///ArticuloDto.cod_barras = $('#cod_barras').val();
        ImpuestoDto.cod_barras = $('#cod_barras').val();
        ImpuestoDto.descripcion = $('#IdTiposImpuestos').val();
        ImpuestoDto.porcentaje = $('#porcentaje').val();
        ///ArticuloDto.ImpuestoDto = ImpuestoDto;
        
        $.ajax({
            type: "POST",
            url: "https://localhost:44307/api/articulos/insertarimpuestos/",                                /// "/Contabilidad/mostrar/",
            dataType: "Json",
            data: { impuestoDto: ImpuestoDto },      //////  { articuloDto: ArticuloDto },
            success: function (data) {
                alert(data);
                toastr.success('La información se guardo de forma correcta');
            },
            error: function (xhr, textStatus, errorThrown) {
                toastr.error('La información no se pudo procesar');
                console.log(textStatus);
            }
        })
    });


    $('#IdTiposImpuestos').change(function () {
        var descripcion = $('#IdTiposImpuestos').val();
        if (descripcion === 'IVA 16')
        {
            $('#porcentaje').val(16);
            $('#porcentaje').prop('disabled', true);
            $('#btnActualizar').prop('disabled', false);
        }
        if (descripcion === 'IVA 0') {
            $('#porcentaje').val(0);
            $('#porcentaje').prop('disabled', true);
            $('#btnActualizar').prop('disabled', false);
        }
        if (descripcion === 'Exento de IVA')
        {
            $('#porcentaje').val('Exento de IVA');
            $('#porcentaje').prop('disabled', true);
            $('#btnActualizar').prop('disabled', false);
        }
        if (descripcion === 'IEPS')
        {
            $('#porcentaje').prop('disabled', false);
            $('#btnActualizar').prop('disabled', false);
        }
    });
});