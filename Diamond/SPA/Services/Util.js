angular.module('Diamond').factory('UtilService', function ($http) {



    var chamarApi = function (endpoint, params, sucess, error) {

        //var url = link + "/" + endpoint + (params ? "?JsonChamada=" + JSON.stringify(params) : "");
        var uri = url.replace(/#/g, '%23');
        uri = uri.replace(/&/g, '%26');

        $http.get(uri)
        .then(function (response) {
            if (response.data.MensagemErro) {
                console.log('erro do backend');
                console.log(response.data);
                tratarErro(response.data.MensagemErro);
            } else {
                sucess(response);
            }
        }, function () {
            error();
        });
    };
})