var app = angular.module('myApp', ['ngRoute']);

app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {

    $routeProvider.when('/ProductList', {
        templateUrl: '/App/Views/ProductList.html',
        controller: 'ProductController'
    }).when('/AddProduct', {
        templateUrl: '/App/Views/AddProduct.html',
        controller: 'ProductController'
    })
    .when('/EditProduct/:prdctId', {
        templateUrl: '/App/Views/EditProduct.html',
        controller: 'ProductController'
    })
    .when('/DeleteProduct/:prdctId', {
        templateUrl: '/App/Views/DeleteProduct.html',
        controller: 'ProductController'
    }).when('/Error', {
        templateUrl: '/App/Views/Error.html',
        controller: 'ProductController'
    })
    .otherwise({
        controller: 'ProductController'
    })
}]);