app.controller("CategoryController", ['$scope', '$http', function ($scope, $http) {
    $scope.ListOfCategory;
    $scope.Status;


    //Get
    $http.get("api/category/GetAll").success(function (data) {
        $scope.ListOfCategory = data;

    })
    .error(function (data) {
        $scope.Status = "data not found";
    });

}]);