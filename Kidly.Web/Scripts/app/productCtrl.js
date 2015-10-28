app.controller("productCtrl", ["$scope", "$http", "$location", "basketService", function ($scope, $http, $location, basketService) {
    var pId = $location.absUrl().split("/")[6];

    $http.get("/api/products/" + pId).then(function (response) {
        $scope.lineItem = response.data;
    });

    $scope.getImage = function() {
        if ($scope.lineItem) {
            return "http://s7ondemand6.scene7.com//is/image/MothercareASE/" + $scope.lineItem.product.mcId + "_1?wid=1800";
        }
        return "";
    };

    $scope.getBrandLogo = function () {
        if ($scope.lineItem) {
            return "http://s7ondemand6.scene7.com//is/image/MothercareASE/" + $scope.lineItem.product.brand.logoId;
        }
        return "";
    };

    $scope.increaseQuantity = function () {
        if ($scope.lineItem.quantity < 20) {
            $scope.lineItem.quantity++;
        }
    };

    $scope.decreaseQuantity = function () {
        if ($scope.lineItem.quantity > 0) {
            $scope.lineItem.quantity--;
        }
    };

    $scope.addToBasket = function () {
        basketService.set($scope.lineItem.product.id, $scope.lineItem.quantity);
        toastr.info($scope.lineItem.product.name + " added to your basket");
    };

    $scope.buyNow = function () {
        basketService.set($scope.lineItem.product.id, $scope.lineItem.quantity, function () {
            window.location = "/basket";
        });
    };
}]);