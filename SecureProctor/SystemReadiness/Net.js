var date = new Date();
// var Starttime = d.getTime();
var Endtime, Duration, speed;
var AvgSpeed = 0;
var a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, Size = 0, FDuration = 0;

function DownloadTest() {
    var result; var Starttime = date.getTime();
    $.when
    (
      a = $.ajax({
          url: "http://test.examity.com/speedtest/image-3.png?t=" + (new Date().getTime()) + Math.random(),
          type: 'GET',
          success: function (data) {
              Endtime = new Date().getTime();
              Duration = Math.round(Endtime - Starttime) / 1000;
              // speed = Math.round(((a.getResponseHeader('Content-Length') * 8) / Duration) / 1000 /1000);
              Calculate(a.getResponseHeader('Content-Length'), Duration, 1);
          }
      }),
       b = $.ajax({
           url: "http://test.examity.com/speedtest/image-4.png?t=" + (new Date().getTime()) + Math.random(),
           type: 'GET',
           success: function (data) {
               Endtime = new Date().getTime();
               Duration = Math.round(Endtime - Starttime) / 1000;
               //  speed = Math.round(((b.getResponseHeader('Content-Length') * 8) / Duration) / 1000 /1000);
               Calculate(b.getResponseHeader('Content-Length'), Duration, 2);
           }
       }),
       c = $.ajax({
           url: "http://test.examity.com/speedtest/image-5.png?t=" + (new Date().getTime()) + Math.random(),
           type: 'GET',
           success: function (data) {
               Endtime = new Date().getTime();
               Duration = Math.round(Endtime - Starttime) / 1000;
               //  speed = Math.round(((b.getResponseHeader('Content-Length') * 8) / Duration) / 1000 /1000);
               Calculate(c.getResponseHeader('Content-Length'), Duration, 2);
           }
       })


    ).then(function () {
        jQuery("#Speed_Detect").empty();
        jQuery("#Speed_Detect").addClass('internet_on');
        jQuery("#SpeedTestStatus").text((((((Size * 8)) / FDuration) / 1000) / 1000).toFixed(2) + " Mbps");
    });
}
function Calculate(CSize, duration, pass) {
    Size += Number(CSize);
    FDuration += duration;
}