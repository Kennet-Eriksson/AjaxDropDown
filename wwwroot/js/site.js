// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


$(document).ready(function () {
    $("#countrychange").on("change", function () {
        var cities = $('#citychange');
        var cname = $("#countrychange option:selected").val();
        $.ajax({
            url: '/Cities/Filter',
            type: "GET",
            data: { id: cname },
            traditional: true,
            dataType: "json",
            success: function (result) {
                cities.empty().append('<option selected="selected" value="0"> Please Select</option>');
                $.each(result, function (i, item) {
                    var obj = $.parseJSON(JSON.stringify(item));
                    cities.append('<option value="' + obj["id"] + '"> ' + obj["name"] + ' </option>');
                });
            },
            error: function () {
                alert("Something went wrong call the police");
            }
        });
    });
});


/*
$(document).ready(function () {
    $("#countrychange").on("change", function () {
        alert("hej");
    })
})
*/