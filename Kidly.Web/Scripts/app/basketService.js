app.service("basketService", ["$http", function ($http) {
    return {
        add: function (productId, quantity, callBack) {
            return $http.get("/api/basket/add/" + productId + "/" + quantity)
                .then(function (response) {
                    if (callBack) {
                        callBack(response.data);
                    }
            });
        },
        set: function (productId, quantity, callBack) {
            return $http.get("/api/basket/set/" + productId + "/" + quantity)
                .then(function (response) {
                    if (callBack) {
                        callBack(response.data);
                    }
                });
        },
        clear: function (callBack) {
            return $http.get("/api/basket/clear")
                .then(function () {
                    if (callBack) {
                        callBack();
                    }
                });
        },
        remove: function (productId, callBack) {
            return $http.get("/api/basket/remove/" + productId)
                .then(function () {
                    if (callBack) {
                        callBack();
                    }
                });
        },
        get: function (callBack) {
            return $http.get("/api/basket/")
                .then(function (response) {
                if (callBack) {
                    callBack(response.data);
                }
            });
        }
    };
}]);