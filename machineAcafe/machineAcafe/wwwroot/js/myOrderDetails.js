
function SearchForLastOrder(BadgeSerial) {
    let urlData = "https://localhost:44387/Api/OrderDetails/" + BadgeSerial;
    $.ajax({
        type: "get",
        url: urlData,
        dataType: "json",
        success: getContent,
    });


    function getContent(response) {        
         AskingDialog(response);
    }


}

function AskingDialog(lastOrder) {
    if (lastOrder != null) {
        var drink = lastOrder.drink;
        var order = lastOrder.order;
        var badge = order.badge;

        bootbox.confirm({
            message: "hi <b>" + badge.name + "</b> would you like to have a <b>"
                + drink.name + "</b> as the last time",
            buttons: {
                confirm: {
                    label: 'yes',
                    classname: 'btn-success'
                },
                cancel: {
                    label: 'no',
                    classname: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result === true) {
                    $("#drink").val(drink.id);
                    $("#sugar").val(lastOrder.sugarQuantity);
                    
                    if (lastOrder.mug === true) { $("#sltMug").val("true"); }
                    else { $("#sltMug").val("false"); }
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