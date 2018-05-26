$(document).ready(function () {
    $('#txtAccountNumber').val('11223344');

    $("#btnTransactions").click(function () {

        $("#Table").html('');
        var accountNumber = {};
        var type = {};

        if (document.getElementById('allType').checked) {
            type = 'all';
        }
        else if (document.getElementById('debitType').checked) {
            type = 'debit';
        }
        else if (document.getElementById('creditType').checked) {
            type = 'credit';
        }
        else {
            type = 'all';
        }

        console.log(type);

        accountNumber = document.getElementById("txtAccountNumber").value;

        $.get('http://localhost:55447/api/v1/transactions/' + accountNumber + '/' + type, function (data) {
            $("#DIV").html('');
            var DIV = '';
            $.each(data, function (i, item) {
                var rows = "<tr>" +
                    "<td>" + item.transactionInformation + "</td>" +
                    "<td>" + item.type + "</td>" +
                    "<td>" + '£' + item.amount + "</td>" +
                    "<td>" + item.bookedDate + "</td>" +
                    "</tr>";
                $('#Table').append(rows);
            }); 
        });
    });
});

