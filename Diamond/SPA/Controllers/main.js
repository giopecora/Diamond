var HomeController = function ($scope) {
    $scope.models = {
        locations: [
            { id: '1', nome: 'primeiro elemento' }
        ]
    };
};

HomeController.$inject = ['$scope'];