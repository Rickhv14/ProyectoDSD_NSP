window.onload = function () {
    _('btnlogin').onclick = ini;
    _('txtuser').addEventListener('keypress', accionInputPassword);
    _('txtpassword').addEventListener('keypress', accionInputPassword);
    _('txtuser').focus();
}
function Get(url, metodo) { _validConexion(); var xhr = new XMLHttpRequest(); url = urlBase() + url; xhr.open("get", url, !0); xhr.onreadystatechange = function (e) { if (xhr.readyState == 4 && xhr.status == 200) { metodo(xhr.responseText) } }; xhr.send() }
function Post(url, frm, metodo) { _validConexion(); var xhr = new XMLHttpRequest(); url = urlBase() + url; xhr.open("post", url, !0); xhr.send(frm); xhr.onreadystatechange = function () { if (xhr.readyState == 4 && xhr.status == 200) { metodo(xhr.responseText) } } }
function _(id) { return document.getElementById(id); }
function urlBase() {
    var url = $("#urlBase").val();
    return url;
}
function res_ini(res) {
    if (res !== '') {
        var obj = JSON.parse(res);
        if (obj !== null) {
            window.location.href = urlBase() + 'Home/Index';
        } else {
            alert('Credenciales invalidas');
        }
    } else {
        alert('Credenciales invalidas');
    }
}

function accionInputPassword(event) {
    let keyCode = (event.keyCode ? event.keyCode : event.which), miScope = this;
    if (keyCode == 13) {
        event.preventDefault();
        if (miScope.id == 'txtuser') {
            $('#txtpassword').focus();
        } else if (miScope.id == 'txtpassword') {
            ini();
        }
        
    }
}

function ini() {
	//console.log(urlBase())
    var form = new FormData();
    form.append("usuario", _('txtuser').value);
    form.append("password", _('txtpassword').value);
    Post('Home/Acceso', form, function (res) { res_ini(res); });
}

function _validConexion() {
    if (!navigator.onLine) {
        carga_paginaerror();
        return;
    }
}

function carga_paginaerror() {

    let pagina =
        `   <body class ="gray-bg">
                 <div class ="middle-box text-center animated fadeInDown">
                   <h1 class ="font-bold">WTS</h1>
                    <h3 class ="font-bold">Connection Lost</h3>

                    <div class ="error-desc">
                      There are a mistake, please, comunicate with System administrator or TIC<br/><a onclick="fn_returnLogin()" class ="btn btn-primary m-t">Try Again</a>
                    </div>
                </div>
            </body>
        `
    let _body = document.body;
    _body.innerHTML = pagina;
    _body.classList.add('gray-bg');

}

function fn_returnLogin() {
    if (!navigator.onLine) {
        carga_paginaerror();
        return;
    }
    else {
        window.location.href = 'http://erp.wtsusa.us';
    }
}

