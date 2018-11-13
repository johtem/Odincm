// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


// Write your Javascript code.
(function () {

    var reformatTimeStamps = function () {

        var timeStamps = document.querySelectorAll(".timeStampValue");
        for (var ts of timeStamps) {
            // console.log(`Reformatting date: ${ts.getAttribute("data-value")}`);
            var thisTimeStamp = ts.getAttribute("data-value");
            var date = new Date(thisTimeStamp);
            if (window.navigator.language) {
                moment.locale(window.navigator.language);
            } else {
                moment.locale('UK');
            }
           
            ts.textContent = moment(date).format('L');
        }

    };

    var reformatTimeStampsLLL = function () {

        var timeStamps = document.querySelectorAll(".timeStampValueL");
        for (var ts of timeStamps) {
            // console.log(`Reformatting date: ${ts.getAttribute("data-value")}`);
            var thisTimeStamp = ts.getAttribute("data-value");
            var date = new Date(thisTimeStamp);
            if (window.navigator.language) {
                moment.locale(window.navigator.language);
            } else {
                moment.locale('UK');
            }

            ts.textContent = moment(date).format('LLL');
        }

    };

    reformatTimeStamps();
    reformatTimeStampsLLL();

})();

//Prevent duplicate submit

$("form").submit(function () {
    if ($(this).valid()) {
        $(this).find(':submit').attr('disabled', 'disabled');
    }
});
