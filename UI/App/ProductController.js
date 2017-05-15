app.controller("ProductController",
    ['$scope', '$http', '$location', '$routeParams',
        function ($scope, $http, $location, $routeParams) {
            $scope.ListOfProduct;
            $scope.Status;
            $scope.Close = function () {
                $location.path('/ProductList');
            }


            //Get
            $http.get("/api/Product/GetAllProducts")
                .success(function (data) {
                    $scope.ListOfProduct = data;
                })
                .error(function (data) {
                    $location.path('/Error')
                    $scope.Status = "Kayitlara ulasilamiyor...";
                });



            //Add
            $scope.Add = function () {
                var productData = {
                    Name: $scope.ProductName,
                    Stock: $scope.UnitInStock,
                    Price: $scope.Price,
                };
                debugger;
                $http.post("/api/product/AddProduct", productData)
                    .success(function (data) {
                        $location.path('/ProductList');
                    })
                    .error(function (data) {
                        $location.path('/Error')
                        console.log(data);
                        $scope.error = "İşlem sırasında birşeyler yanlış gitti " + data.ExceptionMessage;
                    });
            }

            //Update preparation

            if ($routeParams.prdctId) {
                $scope.Id = $routeParams.prdctId;

                $http.get('/api/product/GetProduct/' + $scope.Id)
                    .success(function (data) {
                        $scope.ProductName = data.Name;
                        $scope.UnitInStock = data.Stock;
                        $scope.ProductID = $scope.Id;
                        $scope.Price = data.Price;
                    });

            }

            //Update
            $scope.Update = function () {
                debugger;
                var productData = {
                    ID: $scope.Id,
                    Name: $scope.ProductName,
                    Stock: $scope.UnitInStock,
                    Price: $scope.Price,
                };
                if ($scope.Id > 0) {

                    $http.put("/api/product/UpdateProduct", productData)
                        .success(function (data) {
                            $location.path('/ProductList');
                        })
                        .error(function (data) {
                            $location.path('/Error')
                            console.log(data);
                            $scope.error = "İşlem sırasında birşeyler yanlış gitti " + data.ExceptionMessage;
                        });
                }
            }


            //Delete
            $scope.Delete = function () {
                if ($scope.Id > 0) {

                    $http.delete("/api/product/DeleteProduct/" + $scope.Id)
                        .success(function (data) {
                            $location.path('/ProductList');
                        })
                        .error(function (data) {
                            $location.path('/Error')
                            console.log(data);
                            $scope.error = "İşlem sırasında birşeyler yanlış gitti " + data.ExceptionMessage;
                        });
                }

            }
        }]);