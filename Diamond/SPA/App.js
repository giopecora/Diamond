var App = angular.module('Diamond', ['ngRoute']);


App.config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);
    $routeProvider
           .when('/', {
               templateUrl: '/SPA/Home/Views/Home.html'
           })
        .otherwise({ redirectTo: '/' })

}])


App.controller('MainController', MainController);

MainController.$inject = ['$scope'];
function MainController($scope){

};