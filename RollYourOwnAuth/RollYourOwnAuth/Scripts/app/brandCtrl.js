app.controller("brandCtrl", ["$scope", "$http", "$location", "basketService", function ($scope, $http, $location, basketService) {

    var pId = $location.absUrl().split("/")[4];

    $http.get("/api/brands/" + pId).then(function (response) {
        $scope.brand = response.data;
    });

    $scope.getHero = function (product) {
        return "http://s7ondemand6.scene7.com//is/image/MothercareASE/dw_badge_template2_new?&$badge2size=1%2C0&$hidetext2=1&$badge1size=1%2C0&$product=MothercareASE%2F" + product.mcId + "_1&$dw_clothingbrowse_mc$";
    };

    $scope.getAltHero = function (product) {
        return "http://s7ondemand6.scene7.com//is/image/MothercareASE/dw_badge_template2_new?&$badge2size=1%2C0&$hidetext2=1&$badge1size=1%2C0&$product=MothercareASE%2F" + product.mcId + "_2&$dw_clothingbrowse_mc$";
    };

    $scope.addToBasket = function (product) {
        basketService.add(product.id, 1);
        toastr.info(product.name + " added to your basket");
    };

}]);
