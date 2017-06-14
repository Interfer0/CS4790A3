

function convertLatLong(value, direction) {

    var dDir;

    var dDeg;

    var dMNT;

    var dMin;

    var dSec;

    if (direction == "lat"){
        dDir = value < 0 ? "S" : "N";
    } else {
        dDir = value < 0 ? "W" : "E";
    }
    

    value = Math.abs(value);

    console.log(value + " value");

    dDeg = Math.floor(value);

    console.log(dDeg + " dDeg");

    dMNT = (value - dDeg) * 60;
    console.log(dMNT + " min not trunc");

    dMin = Math.floor(dMNT);
    console.log(dMin + "Minutes")

    dSec = Math.round((dMNT - dMin) * 600) / 100;
    console.log(dSec + " dSec");

    dvalue = dDeg + "° " + dMin + "\' " + dSec + "\"" + dDir;

    return dvalue;

}