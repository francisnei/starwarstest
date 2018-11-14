$(function () {
    $('body').on('click', '#btnCalculate', function () {
        
        var distance = $("#txtDistance").val();

        $.ajax({
            url: "/api/Ships/" + distance,
            method: "GET",
            contentType: "application/json",
            success: function (data) {
                if (data) {

                    var line = '<tr><td>{name}</td><td>{value}</td></tr>';

                    var outData = '';

                    for (var i = 0; i < data.length; i++) {
                        outData += line.replace("{name}", data[i].shipName).replace("{value}", data[i].recharges);
                    }

                    $(".itemslist").html(outData);

                } else {
                    $(".itemslist").html('<tr><td colspan="2">No items data</td></tr>');
                }
            }
        });

    });
});