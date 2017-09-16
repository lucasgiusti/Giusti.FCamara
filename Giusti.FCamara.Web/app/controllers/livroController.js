app.controller('livroController', function ($scope, $http, $window, toasterAlert, $location, $uibModal, $routeParams, UserService) {
    UserService.verificaLogin();

    var url = urlApi + 'livro';

    var usuario = UserService.getUser();
    var token = null;

    if (usuario) {
        token = usuario.token;
    }

    var headerAuth = { headers: { 'Authorization': 'Basic ' + token } };

    $scope.heading = 'Livros';
    $scope.livros = [];

    //APIs
    $scope.getLivros = function () {

        $http.get(url, headerAuth).success(function (data) {
            $scope.livros = data;
            $scope.total = $scope.livros.length;
        }).error(function (jqxhr, textStatus) {
            toasterAlert.showAlert(jqxhr.message);
        })
    };

    //PAGINATION
    $scope.total = 0;
    $scope.currentPage = 1;
    $scope.itemPerPage = 5;
    $scope.start = 0;
    $scope.maxSize = 5;
    $scope.pageChanged = function () {
        $scope.start = ($scope.currentPage - 1) * $scope.itemPerPage;
    };
});
