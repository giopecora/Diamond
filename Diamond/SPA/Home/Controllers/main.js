angular.module('Home', [])

    .config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/oi', {
                templateUrl: 'SPA/Home/Views/Home.html'
            })
            .otherwise({redirectTo: '/'})
    }])

    .controller('HomeController', HomeController);

function HomeController($scope) {
    $scope.models = {
        locations: [
            { id: '1', nome: 'primeiro elemento' }
        ]
    };
};
//HomeController.$inject = ['$scope'];