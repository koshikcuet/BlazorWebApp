var Swal;
function getLS(ky, defret) {
    try {
        var ls = sessionStorage.getItem(ky);
        if (isEmpty(ls)) {
            return defret;
        }
        else {
            return ls;
        }
    }
    catch (err) {
        return defret;
    }
}
function setLS(ky, valu) { try {
    sessionStorage.setItem(ky, valu);
}
catch (err) { } }
function getLocal(ky, defret) {
    try {
        var ls = localStorage.getItem(ky);
        if (isEmpty(ls)) {
            return defret;
        }
        else {
            return ls;
        }
    }
    catch (err) {
        return defret;
    }
}
function setLocal(ky, valu) { try {
    localStorage.setItem(ky, valu);
}
catch (err) { } }
function setCookie(cname, cvalue, exdays = 20) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
function isEmpty(val) { return (val === undefined || val == null || val.length <= 0) ? true : false; }
function Transitt(outSc, inSc) { outSc.fadeOut(500, function () { inSc.fadeIn(500, function () { }); }); }
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}
function isNumberInt(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode < 48 || charCode > 57) {
        return false;
    }
    return true;
}
function isTxt(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode == 32 || (charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123)) {
        return true;
    }
    return false;
}
function NmPad(num, size) { var s = "000000000" + num; return s.substring(s.length - size); }
var APIURL;
function rlUrl() {
    var tUrl = 'http://localhost:61741/atapi.aspx';
    return tUrl;
}
function isDev() {
    if (window.location.hostname == 'localhost') {
        return true;
    }
    else {
        return false;
    }
}
function clToggle(opGroup, clsNormal, clsActive, Cntrl, ths = 0) {
    $('.' + opGroup).removeClass(clsActive).removeClass(clsNormal);
    $('.' + opGroup).addClass(clsNormal);
    if (ths == 0) {
        $('#' + Cntrl).removeClass(clsNormal).addClass(clsActive);
    }
    else {
        $(Cntrl).removeClass(clsNormal).addClass(clsActive);
    }
}
function clTogi(opGroup, clsNormal, clsActive, indx) {
    $('.' + opGroup).removeClass(clsActive).removeClass(clsNormal);
    $('.' + opGroup).addClass(clsNormal);
    $('.' + opGroup).eq(indx).removeClass(clsNormal).addClass(clsActive);
}
function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}
function ParamByName(name, url) {
    if (!url)
        url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"), results = regex.exec(url);
    if (!results)
        return null;
    if (!results[2])
        return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}
function retTmStr() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yy = today.getFullYear() - 2000;
    var hour = today.getHours();
    var minu = today.getMinutes();
    var secs = today.getSeconds();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    if (hour < 10) {
        hour = '0' + hour;
    }
    if (minu < 10) {
        minu = '0' + minu;
    }
    if (secs < 10) {
        secs = '0' + secs;
    }
    var trnId = yy + '' + mm + '' + dd + '' + hour + '' + minu + '' + secs;
    return trnId;
}
//function onia(exstr) {
//    let oni = CryptoJS.AES.encrypt(exstr, 'time');
//    return oni;
//}
//function sazi(exstr) {
//    let saz = CryptoJS.AES.decrypt(exstr, 'time');
//    let sazs = saz.toString(CryptoJS.enc.Utf8);
//    return sazs;
//}
const CONFM = "Confirmed";
const BOOKM = "Booked";
const CANCM = "Cancelled";
const RQST_C = "Requested";
const RQST_P = "Pending";
// 12 oct 2021
function retTm() {
    var d = new Date();
    var hr = d.getUTCHours().toString();
    var dd = d.getUTCDate().toString();
    if (Number(dd) < 10) {
        dd = '0' + dd;
    }
    ;
    if (Number(hr) < 10) {
        hr = '0' + hr;
    }
    ;
    return dd + '' + hr;
}
function rand(digits) {
    return Math.floor(Math.random() * parseInt('8' + '9'.repeat(digits - 1)) + parseInt('1' + '0'.repeat(digits - 1)));
}
var st = 'LKJHF1GDSAPOI42UTYREWQZXCB980VNMfdsagh765jklpoiuytrewqzxcvbnm3QAZWSXEDCRF7VTGB456YHNUJMIKOLP180plomkinjubhy932vgtcfrxdezswaq';
function rob(tx) {
    var stm = st.split('');
    var stx = stm.slice(0, 62);
    var sty = stm.slice(62);
    var stz = tx.split('');
    var i;
    var ret = '';
    for (i = 0; i < stz.length; i++) {
        var chIn = stx.indexOf(stz[i]);
        if (chIn < 0) {
            ret += stz[i];
        }
        else {
            ret += sty[chIn];
        }
    }
    return ret;
}
function FLTkn() {
    return rob(rand(14) + retTm() + rand(6));
}
//function chtkn() {
//    let lgd: ApiLogResp = retlogin();
//    if (isEmpty(lgd)) { return ''; }
//    if (isEmpty(lgd.email)) { return ''; }
//  //  return (rob(rand(10) + lgd.email.replace('@', '-') + 'ABCD' + lgd.mobile));
//    return (rob(rand(10) + lgd.email.replace('@', '-') + 'ABCD' + lgd.mobile + 'ABCD' + lgd.usr));
//}
function createGUID() {
    function random() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }
    return random() + random() + '-' + random() + '-' + random() + '-' +
        random() + '-' + random() + random() + random();
}
//function retlogin() {
//    let encL = getLS('logindata', '');
//    let decL = sazi(encL);
//    let lgd = new ApiLogResp();
//    if (decL.length > 0) {
//        lgd = JSON.parse(decL);
//    }
//    return lgd;
//}
function ShowError(msg) {
    Swal.fire({
        icon: 'error', html: msg, confirmButtonText: 'OK', showCloseButton: true, showClass: {
            popup: 'animate__animated animate__fadeIn'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOut'
        }
    });
}
function ShowSuccess(msg) {
    Swal.fire({ icon: 'success', html: msg, confirmButtonText: 'OK', showCloseButton: true });
}
function ShowAnyMessage(msg) {
    var rmsg = `<div style="padding-top: 50px; padding-bottom: 15px;">` + msg + `</div>`;
    Swal.fire({ html: rmsg, confirmButtonText: 'OK', showCloseButton: true });
}
function popm(msg) {
    Swal.fire({ html: msg, confirmButtonText: 'OK', showCloseButton: true, animation: false });
}
function showConfirm(ttL, msgC, btX, callbak) {
    Swal.fire({
        title: ttL, html: msgC, icon: 'warning', showCancelButton: true, confirmButtonColor: '#d33', cancelButtonColor: '#3085d6',
        confirmButtonText: btX
    }).then((result) => {
        if (result.isConfirmed) {
            callbak();
        }
    });
}
function showFinalMsg(ttL, msgC, btX, nloc) {
    Swal.fire({
        title: ttL, html: msgC, icon: 'warning', confirmButtonColor: '#d33', confirmButtonText: btX, allowOutsideClick: false, allowEscapeKey: false, backdrop: true
    }).then((result) => {
        location.href = nloc;
    });
}
function chngColor(cnt, rslt) {
    //let cnt: number = Number($('#cnt').html());
    if (cnt % 2 == 0) {
        $('#cnt').css('color', 'red');
    }
    else {
        $('#cnt').css('color', 'blue');
    }
    console.log(rslt);
}
function usrole(vl) {
    $('.usrole').html(vl);
}
//# sourceMappingURL=main.js.map