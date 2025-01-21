function chngColor(cnt: number, rslt: string) {
    //let cnt: number = Number($('#cnt').html());

    if (cnt % 2 == 0) {
        $('#cnt').css('color', 'red');
    } else {
        $('#cnt').css('color', 'blue');
    }
    console.log(rslt);
}

function usrole(vl) {
    $('.usrole').html(vl);
}