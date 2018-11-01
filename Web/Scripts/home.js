$(document).ready(function () {
    var $orders = $('#orders');
    $.ajax({
        'url': '/api/order/1',
        'type': 'GET',
        'success': function (data) {

            var $orderList = $('<ul/>');

            if (data) {
                $.each(data,
                    function (i) {
                        var $li = $('<li/>').text(this.Description + ' (Total: $' + this.OrderTotal.toFixed(2) + ')')
                            .appendTo($orderList);

                        var $productList = $('<ul/>');

                        $.each(this.OrderProducts, function (j) {
                            var $li2 = $('<li/>').text(this.Product.Name + ' (' + this.Quantity + ' @@ $' + this.Price.toFixed(2) + '/ea)')
                                .appendTo($productList);
                        });

                        $productList.appendTo($li);
                    });

                $orders.append($orderList);
            }
        }
    });
});
