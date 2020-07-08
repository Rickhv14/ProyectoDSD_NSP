$(document).ready(function () {

    $("#btnObtener").click(function () {
        Obtener();
    });

    $("#btnSave").click(function () {
        Save();
    });
});

function Obtener() {
    var frm = new FormData();
    frm.append("dni", $("#txtDni").val());
    frm.append("codigo", $("#txtCodigo").val());
    Post('Alumno/ConsultaNota', frm, LoadResult);

    //Get('Pedido/Obtener?po=' + $("#txtPO").val(), LoadPo);
}

function LoadResult(data) {
    
    if (data === "") {

        var omensaje = {
            titulo: 'Mensaje',
            mensaje: 'No se encontro al alumno',
            estado: 'error'
        }
        _mensaje(omensaje);
       

    } else {


        var oAlumno = JSON.parse(data);


        var dataJson = JSON.parse(data);
        var ndataJson = dataJson.length;
        var html = "<table id='tableList' class='table table-bordered'>";
        html += "<thead>";
        html += "<tr>";
        html += "<th class='text-center'>Codigo Alumno</th>";
        html += "<th class='text-center'>DNI Alumno</th>";
        html += "<th class='text-center'>Nombre</th>";
        html += "<th class='text-center'>Apellido</th>";
        html += "<th class='text-center'>Curso</th>";
        html += "<th class='text-center'>Estado</th>";
        html += "<th class='text-center'>Nota</th>";
        html += "</tr>";
        html += "</thead>";
        html += "<tbody>";
        for (var i = 0; i < ndataJson; i++) {
            html += "<tr class='detalle'>";
            html += "<td class='text-center'>" + dataJson[i].CodigoAlumno + "</td>";
            html += "<td class='text-center'>" + dataJson[i].DNIAlumno + "</td>";
            html += "<td class='text-center'>" + dataJson[i].NombreAlumno + "</td>";
            html += "<td class='text-center'>" + dataJson[i].ApellidoAlumno + "</td>";
            html += "<td class='text-center'>" + dataJson[i].NombreCurso + "</td>";
            html += "<td class='text-center'>" + dataJson[i].EstadoCurso + "</td>";
            html += "<td class='text-center'>" + dataJson[i].Nota + "</td>";
            html += "</tr>";
        }
        html += "</tbody>";
        $("#divContent").empty();
        $("#divContent").append(html);


        $('#tableList').DataTable({
            paging: true,
            "pageLength": 100,
            fixedHeader: true,
            scrollCollapse: true,
            dom: 'Bfrtip',
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ]
        });

       
    }
}

function LoadPo(data) {
    if (data !== "null") {
        data = JSON.parse(data);
        ndata = data.length;
        if (ndata > 0) {

            $("#txtPO").attr("readonly", true);

            var html = "<table id='tableList' class='table table-bordered'>";
            html += "<thead>";
            html += "<tr>";
            html += "<th class='text-center'>Po</th>";
            html += "<th class='text-center'>Destino</th>";
            html += "<th class='text-center'>Fecha Despacho</th>";
            html += "<th class='text-center'>Estilo</th>";
            html += "<th class='text-center'>Color</th>";
            html += "<th class='text-center'>Talla</th>";
            html += "<th class='text-center'>Cantidad</th>";
            html += "<th class='text-center'>Precio</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            for (var i = 0; i < ndata; i++) {
                html += "<tr class='detalle'>";
                //html += "<td class='text-center'><span class='input-group-btn'><button class='btn btn-primary btn-sm' type='button' title='Guardar' onclick='Editar(" + data[i].Po + ")'><i class='fa fa-floppy-o'></i></button></span></td>";
                html += "<td class='text-center'>" + data[i].Po + "</td>";
                html += "<td class='text-center'>" + data[i].Destino + "</td>";
                html += "<td class='text-center'>" + data[i].FechaDespacho + "</td>";
                html += "<td class='text-center'>" + data[i].Estilo + "</td>";
                html += "<td class='text-center'>" + data[i].Color + "</td>";
                html += "<td class='text-center'>" + data[i].Talla + "</td>";
                html += "<td class='text-center'><input type='text' class='form-control' value='" + data[i].Cantidad + "'/></td>";
                html += "<td class='text-center'><input type='text' class='form-control' value='" + data[i].Precio + "'/></td>";
                html += "</tr>";
            }
            html += "</tbody>";
            $("#divContent").empty();
            $("#divContent").append(html);


            $('#tableList').DataTable({
                paging: true,
                "pageLength": 100,
                fixedHeader: true,
                scrollCollapse: true,
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });

        }
    } else {
        $("#divContent").empty();
    }
}

function Save() {

    var DetalleLen = $(".detalle").length;

    if (DetalleLen > 0) {

        var Pedido = new Array();

        $(".detalle").each(function () {

            var Po = $(this.cells[0]).val();
            var Destino = $(this.cells[1]).val();
            var Fecha = $(this.cells[2]).val();
            var Estilo = $(this.cells[3]).val();
            var Color = $(this.cells[4]).val();
            var Talla = $(this.cells[5]).val();
            var Cantidad = parseFloat($(this.cells[6]).children().val());
            var Precio = parseFloat($(this.cells[7]).children().val());

            if (!isNaN(Cantidad)) {

                var obj = {
                    Po: Po,
                    Estilo: Estilo,
                    Talla: Talla,
                    Cantidad: Cantidad,
                    Color: Color,
                    Destino: Destino,
                    FechaDespacho: Fecha,
                    Precio: Precio
                };

                Pedido.push(obj);
            }
        });

        var frm = new FormData();
        frm.append("pedido", JSON.stringify(Pedido));
        Post('Pedido/Save', frm, Alerta);

    }

}
function Alerta(mensajeR) {

    $("#divContent").empty();
    $("#txtPO").val("");
    $("#txtPO").attr("readonly", false);

    var objmensaje = { titulo: 'Alerta', mensaje: mensajeR, estado: 'error' };

    _mensaje(objmensaje);

}
