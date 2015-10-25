app.controller("basketCtrl", ["$scope", "basketService", function ($scope, basketService) {

    var populate = function() {
        basketService.get((function (lineItems) {
            $scope.lineItems = lineItems;
        }));
    }

    $scope.getImage = function (product) {

        if (product) {
            return "http://s7ondemand6.scene7.com//is/image/MothercareASE/" + product.mcId + "_1?wid=100";
        }
        return "";
    };

    $scope.clearBasket = function () {
        basketService.clear(populate);
    }

    $scope.removeFromBasket = function (product) {
        basketService.remove(product.id, populate);
    }

    $scope.increaseQuantity = function (lineItem) {
        if (lineItem.quantity < 20) {
            lineItem.quantity++;
        }
    };

    $scope.decreaseQuantity = function (lineItem) {
        if (lineItem.quantity > 0) {
            lineItem.quantity--;
        }
    };

    $scope.postage = 8.50;

    $scope.discount = 0.0;

    $scope.setDiscount = function (discount) {
        $scope.discount = discount;
    };

    $scope.subTotal = function () {
        var total = 0;

        if (!$scope.lineItems) {
            return total;
        }

        for (var i = 0; i < $scope.lineItems.length; i++) {
            total += $scope.lineItems[i].product.price * $scope.lineItems[i].quantity;
        }

        return total;
    };

    $scope.total = function () {
        return ($scope.subTotal() * (1.0 - $scope.discount)) + $scope.postage;
    };

    $scope.continueShopping = function() {
        window.location = "/";
    };

    populate();

}]);

app.directive("quantitySelector", function() {
    return {
        constraint: "E",
        scope : {
          item: "="  
        },
        template:
            "<div class='qty_cart'>" +
                "<div class='qty-ctl'>" +
                "<button title='Decrease Qty' ng-click='decreaseQuantity()' class='decrease' ng-enabled='lineItem.quantity > 0'>decrease</button>" +
                "</div>" +
                "<input value='{{item.quantity}}' size='4' title='Qty' class='input-text qty' maxlength='12'>" +
                "<div class='qty-ctl'>" +
                "<button title='Increase Qty' ng-click='increaseQuantity()' class='increase' ng-enabled='increaseEnabled()'>increase</button>" +
                "</div>" +
                "</div>",
        controller: function($scope) {

            $scope.max = $scope.max || 20;
            $scope.min = $scope.min || 0;

            $scope.increaseEnabled = function () {
                return $scope.item.quantity < $scope.max;
            };

            $scope.decreaseEnabled = function () {
                return $scope.item.quantity > $scope.min;
            };

            $scope.increaseQuantity = function () {
                if ($scope.increaseEnabled()) {
                    $scope.item.quantity++;
                }
            };

            $scope.decreaseQuantity = function () {
                if ($scope.decreaseEnabled()) {
                    $scope.item.quantity--;
                }
            };
        }
};


});


