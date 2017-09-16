var urlApi = 'http://localhost:51493/api/';

var app = angular.module('app', ['ngRoute', 'ngAnimate', 'ui.bootstrap', 'ngCookies', 'toaster'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/', { templateUrl: 'app/templates/home.html', controller: 'homeController' });
        $routeProvider.when('/signin', { templateUrl: 'app/templates/signin.html', controller: 'signinController' });
        $routeProvider.when('/livros', { templateUrl: 'app/templates/livro/livros.html', controller: 'livroController' });
        $routeProvider.when('/paginanaoencontrada', { templateUrl: 'app/templates/paginaNaoEncontrada.html', controller: 'paginaNaoEncontradaController' });
        $routeProvider.otherwise({ redirectTo: '/paginanaoencontrada' });
        $locationProvider.html5Mode(true);
    });

app.run(function ($rootScope) {
    /*
        Receive emitted message and broadcast it.
        Event names must be distinct or browser will blow up!
    */
    $rootScope.$on('atualizaHeaderEmit', function (event, args) {
        $rootScope.$broadcast('atualizaHeaderBroadcast', args);
    });
});

app.factory('UserService', function ($http, $window, $cookies, $location, toasterAlert) {
    return {
        getUser: function () {
            var user = $cookies.get('user');
            if (user) {
                return JSON.parse(user);
            }
            else {
                return null;
            }
        },
        setUser: function (newUser) {
            if (newUser) {
                var urlFuncionalidade = urlApi + 'funcionalidade';

                var headerAuth = { headers: { 'Authorization': 'Basic ' + newUser.token } };

                $http.get(urlFuncionalidade, headerAuth).success(function (data) {
                    newUser.menus = data;
                    $cookies.put('user', JSON.stringify(newUser));
                    $location.path('');
                }).error(function (jqxhr, textStatus) {
                    toasterAlert.showAlert(jqxhr.message);
                });
            }
            else {
                $cookies.put('user', null);
            }
        },
        verificaLogin: function () {
            var user = this.getUser();
            if (!user) {
               $location.path('signin');
            }
        }
    };
});