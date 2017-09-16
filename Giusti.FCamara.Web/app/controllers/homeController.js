app.controller('homeController', function ($scope, $window, $location, UserService) {
    UserService.verificaLogin();

    $scope.heading = "Giusti.FCamara";
    $scope.message = "Sistema desenvolvido para a FCamara em ASP.Net WebAPI, Angularjs, Bootstrap e SQL Server Express";
});