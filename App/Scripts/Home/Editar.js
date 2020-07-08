var EstiloTallaColor = null;

$(document).ready(function () {

    $("#btnReturn").click(function () {
        let url = 'Home/Evento';
        _Go_Url(url, url, "");
    });

    $("#btnSave").click(function () {
        Save();
    });

    $("#dtDate").datetimepicker({
        format: 'DD/MM/YYYY HH:mm:ss'
    });

    Get('Home/CategoriaList', LoadCategoria);

    var id = $("#txtpar").val();
    Get('Home/EventoGet?id=' + id, LoadEvento);

});

function LoadEvento(data) {

    if (data !== "null") {
        var Evento = JSON.parse(data);

        $("#txtTitulo").val(Evento.Titulo);
        $("#txtDescripcion").val(Evento.Descripcion);
        $("#cboCategoria").val(Evento.IdCategoria);
        $("#txtInvitados").val(Evento.Invitados);
        $("#txtDuracion").val(Evento.Duracion);
        $("#txtId").val(Evento.IdEvento);
        $('#dtDate').data("DateTimePicker").date(Evento.Fecha);
        
    }
}

function LoadCategoria(data) {

    if (data !== "null") {

        var Categoria = JSON.parse(data);
        var nCategoria = Categoria.length;
        var htmlCombo = "<option value='0'>Seleccione</option>";
        for (var i = 0; i < nCategoria; i++) {
            htmlCombo += "<option value='" + Categoria[i].IdCategoria + "'>" + Categoria[i].Categoria + "</option>";
        }
        $("#cboCategoria").append(htmlCombo);
    }
}
function Save() {

    var IdEvento = $("#txtId").val();
    var Titulo = $("#txtTitulo").val();
    var Des = $("#txtDescripcion").val();
    var IdCategoria = $("#cboCategoria").val();
    var Invitados = $("#txtInvitados").val();
    var Duracion = $("#txtDuracion").val();
    var Fecha = $('#dtDate').data('date');// moment($('#dtDate').datepicker('getDate')).format("DD/MM/YYYY");


    var Mensaje = "";
    var objmensaje = null;

    if (Titulo === "") {
        Mensaje += "Ingrese el Titulo </br>";
    }

    if (Fecha === undefined) {
        Mensaje += "Seleccione una fecha </br>";
    }

    if (Titulo.length > 200) {
        Mensaje += "Seleccione una fecha </br>";
    }

    if (Mensaje !== "") {
        objmensaje = { titulo: 'Alerta', mensaje: Mensaje, estado: 'error' };
        _mensaje(objmensaje);
        return false;
    }

    if (Duracion === "") {
        Duracion = 60;
    }


    var oEvento = {
        Titulo: Titulo,
        IdEvento: IdEvento,
        Fecha: Fecha,
        Duracion: Duracion,
        Descripcion: Des,
        Invitados: Invitados,
        IdCategoria: IdCategoria,
        Categoria: ""
    };

    var frm = new FormData();
    frm.append("Evento", JSON.stringify(oEvento));
    Post('Home/Update', frm, Alerta);

}
function Alerta(data) {
    if (data !== "") {
        
        if (data === "true") {
            alert("Se actualizo Correctamente");
        } else {
            alert("No se pudo actualizar");
        }
    } else {
        alert("No se pudo actualizar");
    }

}