// defining the module to a variable
var CRTapp = angular.module('CRTapp', []);
//url
var LoginUrl = '/api/Login/Login';
var getUsersUrl = '/api/Admin/getUsers';
var RemoveUser = '/api/Admin/removeUser';
//defining the controllers
CRTapp.controller('LoginCtrl', function Login($scope, $http ,$window) {
    $scope.user = {};
    $scope.LoginRequest = function () {
        alert( JSON.stringify($scope.user));
        $http.post(LoginUrl, $scope.user).then(function complete(response) {
            $scope.user = null;
            $window.location.href = response.data;
        })   
    }
});
CRTapp.controller('UserListCtrl', function GetUser($scope, $http) {
    $scope.users = {};
    $http.get(getUsersUrl).then(function complete(response) {
        $scope.users = response.data;
    });
    $scope.DeleteUser = function (userId) {
        $http.post(RemoveUser, userId).then(function complete(response) {
            alert(response.data);
        })
    };
    $scope.sortBy = function (propertyName) {
        $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
        $scope.propertyName = propertyName;
    };
});