$(document).ready(function () {

    $("#spnBuscar").click(function () {
        Buscar();
    });

    $("#btnGrabar").click(function () {
        Save();
    });
});

function Buscar() {
    var frm = new FormData();
    frm.append("dni", $("#txtDNI").val());
    Post('Alumno/BuscarAlumno', frm, LoadResult);

}

function LoadResult(data) {

    if (data === "") {
        var objmensaje = { titulo: 'Alerta', mensaje: "No se encontro al alumno", estado: 'error' };

        _mensaje(objmensaje);
    } else {


        var dataJson = JSON.parse(data);
        $("#txtCodigoAlumno").val(dataJson.CodigoAlumno);
        $("#txtNombre").val(dataJson.NombreCompleto);
        $("#txtTelefono").val(dataJson.Telefono);
        $("#txtDNI").attr("readonly", true);
    }
}

function Save() {
    var frm = new FormData();
    frm.append("codigo", $("#txtCodigoAlumno").val());
    frm.append("comentario", $("#txtComentario").val());
    frm.append("turno", $("#cboTurno").val());
    frm.append("telefono", $("#txtTelefono").val());
    Post('Alumno/GuardarMatricula', frm, Alerta);
}


function Alerta(data) {

    var objmensaje = { titulo: 'Alerta', mensaje: data, estado: 'error' };
    _mensaje(objmensaje);

    if (data === "Se registro Correctamente") {
        $("#txtCodigoAlumno").val("");
        $("#txtNombre").val("");
        $("#txtComentario").val("");
        $("#txtDNI").val("");
        $("#txtDNI").attr("readonly",false);
    }

}
