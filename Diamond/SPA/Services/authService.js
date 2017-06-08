
App.factory('authService', ['$http', '$q', 'localStorageService', '$rootScope', function ($http, $q, localStorageService, $rootScope) {
    
    var serviceBase = document.location.origin + '/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        userId: 0,
        isAdmin: false
    };

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'api/Usuario/Post', registration).then(function (response) {
            return response;
        });
    };

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            localStorageService.set('authorizationData',
                {
                    token: response.access_token,
                    userName: response.userName,
                    userId: response.userId,
                    isAdmin: response.isAdmin == "1" ? true : false
                });

            _authentication.isAuth = true;
            _authentication.userName = response.userName;
            _authentication.userId = response.userId;
            _authentication.isAdmin = response.isAdmin == "1" ? true : false;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });


        return deferred.promise;
    };

    var _isAuthenticated = function () {
        var currentUser =  localStorageService.get('authorizationData');

        return currentUser.isAuth;
    }

    var _logOut = function () {

        localStorageService.remove('authorizationData');
        $rootScope.currentUser = undefined;

        _authentication.isAuth = false;
        _authentication.userName = "";
        _authentication.userId = 0;
    };

    var _fillAuthData = function () {
        
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
            _authentication.userId = authData.userId;
            _authentication.isAdmin = authData.isAdmin;
        }
    };

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;
}]);