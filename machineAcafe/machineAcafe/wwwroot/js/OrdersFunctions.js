
function SearchForLastOrder(BadgeSerial) {
    let urlData = "https://localhost:44387/api/Orders/" + BadgeSerial;
    $.ajax({
        type: "get",
        url: urlData,
        dataType: "json",
        success: getContent,
    }); 

    
    function getContent(response) {
        lastOrder = response;
        AskingDialog(lastOrder);
       }

   
}

function AskingDialog(lastOrder)
{
    if (lastOrder != null) {
        var drink = lastOrder.drink;
        var badge = lastOrder.badge;
        bootbox.confirm({
            message: "Hi <b>" + badge.name + "</b> Would you like to have a <b>" + drink.name + "</b> as the last time",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result === true) {
                    console.log("Thanks  " + badge.name + " for using our services.");
                }
            }
        });
    }
}



$(document).ready(function () {

    $("#badge").change(function () {
        var serial = $("#badge").val();
        SearchForLastOrder(serial);                    
    });

});