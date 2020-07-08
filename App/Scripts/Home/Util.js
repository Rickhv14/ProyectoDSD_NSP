$(document).ready(function () {
    $(document).ajaxStart(function () {
        $('#myModalSpinner').modal('show');
    });

    $(document).ajaxStop(function () {
        $('#myModalSpinner').modal('hide');
    });
});

window.oURL = {
    erp: {
        localhost: 'http://localhost:4012/'
    }
};


window.appURL = {
    erp: window.oURL.erp.localhost
};


function Get(url, metodo, spinner) {
    var gif = (typeof spinner !== 'undefined' && spinner !== null) ? (spinner === true) : true;
    if (gif) {
        $('#myModalSpinner').modal('show');
        var xhr = new XMLHttpRequest(); url = urlBase() + url; xhr.open("get", url, !0);
        xhr.onreadystatechange = function (e) {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    metodo(xhr.responseText);
                    setTimeout(function () {
                        $('#myModalSpinner').modal('hide');
                    }, 0 | Math.random() * 500);
                } else { // error
                    $('#myModalSpinner').modal('hide');
                }
            }
        }; xhr.send();
    } else {
        var xhr = new XMLHttpRequest();
        url = urlBase() + url;
        xhr.open("get", url, !0);
        xhr.onreadystatechange = function (e) {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    metodo(xhr.responseText);
                }
            }
        }; xhr.send();
    }

}


function Post(url, frm, metodo, spinner) {

    var gif = (typeof spinner !== 'undefined' && spinner !== null) ? (spinner === true) : true;

    if (gif) {
        $('#myModalSpinner').modal('show');
        var xhr = new XMLHttpRequest(); url = urlBase() + url; xhr.open("post", url, !0); xhr.send(frm);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    metodo(xhr.responseText);
                    setTimeout(function () {
                        $('#myModalSpinner').modal('hide');
                    }, 0 | Math.random() * 500);
                } else {  // error
                    $('#myModalSpinner').modal('hide');
                }
            }
        }
    } else {

        var xhr = new XMLHttpRequest(); url = urlBase() + url; xhr.open("post", url, !0); xhr.send(frm);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    metodo(xhr.responseText);
                    setTimeout(function () {

                    }, 0 | Math.random() * 500);
                } else {  // error

                }
            }
        }
    }


}


function urlBase() {
    var url = $("#urlBase").val();
    //url = url == '/' ? '' : url;
    return url;
}
function _Go(e) {
    let li = e.target.parentNode;
    let ul = li.parentNode;
    let nojs = (li.getAttribute("data-nojs") !== null && li.getAttribute("data-nojs") === 'true');
    // : edu 20180522 modificado la url para que se pueda ver la misma ventana desde diferentes modulos; caso laboratorio
    //let url = `${ul.getAttribute('data-nav')}/${li.getAttribute('data-nav')}`;  /* :change */
    let url = `${li.getAttribute('data-nav')}`;

    let par = li.getAttribute('data-par') !== null && li.getAttribute('data-par').trim().length > 0 ? `${li.getAttribute('data-par')}` : '';
    let login = false;
    let contenido = '';
    let indiceclass = e.currentTarget.className.indexOf('erp1');

    if (indiceclass > 0) {
        // para regresar al erp1
        let urlapp = window.appURL.erp + `Redireccionar/LoginRedireccionar?usuario=${window.utilindex.usuario}&password=${window.utilindex.password}&url=${url}`;
        window.location.href = urlapp;
    } else {
        Get(url, (rsta) => {
            login = rsta.indexOf('Login') > 0;
            let urlB = urlBase();
            if (!login) {
                contenido = (par !== '') ? rsta.replace('DATA-PARAMETRO', par) : rsta;
                _('divContenido').innerHTML = contenido;
                // :edu 20180522 modificado la url para que se pueda ver la misma ventana desde diferentes modulos; caso laboratorio
                //if (!nojs) checkloadjscssfile(urlB + `Scripts/${ul.getAttribute('data-nav')}/${li.getAttribute('data-nav').split('/')[1]}.js`, "js");
                //if (!nojs) checkloadjscssfile(urlB + `Scripts/${ul.getAttribute('data-nav')}/${li.getAttribute('data-js')}.js`, "js");
                if (!nojs) checkloadjscssfile(urlB + `Scripts/${url}.js`, "js");
            } else {
                window.location.href = window.appURL.erp + "Login/login";
            }
        });
    }
}

//: sam
function _Go_Url(urlAccion, urlJS, par) {
    let contenido = '', login = '',
        urlB = urlBase();
    Get(urlAccion, (rsta) => {
        login = rsta.indexOf('Login') > 0;
        if (!login) {
            contenido = (par !== null && par !== '') ? rsta.replace('DATA-PARAMETRO', par) : rsta;
            _('divContenido').innerHTML = contenido;
            checkloadjscssfile(urlB + `Scripts/${urlJS}.js`, "js");
        } else {
            window.location.href = urlB + "Home/LoginERP";
        }
    });
}


function _Getjs(urlJS) {
    let urlB = urlBase();
    checkloadjscssfile(urlB + `Scripts/${urlJS}.js`, "js");
}

function _Array(elements) { return Array.prototype.slice.apply(elements) };
function _(id) { return document.getElementById(id); }
function loadjscssfile(filename, filetype) {
    //filename = filename ? filename + '?v=' + Date.now() : ''; //:activar para :produccion
    var fileref;
    if (filetype == "js") {
        fileref = document.createElement('script');
        fileref.setAttribute("type", "text/javascript");
        fileref.setAttribute("src", filename);
    }
    else if (filetype == "css") {
        fileref = document.createElement("link");
        fileref.setAttribute("rel", "stylesheet");
        fileref.setAttribute("type", "text/css");
        fileref.setAttribute("href", filename);
    }
    if (typeof fileref != "undefined") {
        document.getElementsByTagName("head")[0].appendChild(fileref);
    }
}

var filesadded = "";
function checkloadjscssfile(filename, filetype) {
    if (filesadded.indexOf("[" + filename + "]") == -1) {
        loadjscssfile(filename, filetype)
        filesadded += "[" + filename + "]";
    } else {
        removejscssfile(filename, filetype);
        loadjscssfile(filename, filetype)
        filesadded += "[" + filename + "]";
    }
}
function removejscssfile(filename, filetype) {
    var targetelement = (filetype == "js") ? "script" : (filetype == "css") ? "link" : "none";
    var targetattr = (filetype == "js") ? "src" : (filetype == "css") ? "href" : "none";
    var allsuspects = document.getElementsByTagName(targetelement);
    for (var i = allsuspects.length; i >= 0; i--) {
        if (allsuspects[i] && allsuspects[i].getAttribute(targetattr) != null && allsuspects[i].getAttribute(targetattr).indexOf(filename) != -1) {
            allsuspects[i].parentNode.removeChild(allsuspects[i]);
        }
    }
}

function _mensaje(omensaje) {
    omensaje = (omensaje !== null) ? omensaje : { titulo: 'Mensaje', mensaje: 'No se pudo registrar', estado: 'error' };
    let oiconos = { ok: 'fa-check-circle-o', error: 'fa-exclamation-triangle' },
        clase = `${(omensaje.estado === 'success') ? oiconos.ok : oiconos.error}`;
    _('modal_titulo').innerHTML = omensaje.titulo != null ? omensaje.titulo : 'Mensaje';
    _('modal_mensaje').innerHTML = omensaje.mensaje;
    _('modal_icono').classList.remove(oiconos.ok, oiconos.error);
    _('modal_icono').classList.add(clase);
    $("#modal").modal();
}