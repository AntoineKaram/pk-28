// defining the module to a variable
var CRTapp = angular.module('CRTapp', []);
//url
var LoginUrl = '/api/Login/Login';
var getUsersUrl = '/api/Admin/getUsers';
var RemoveUser = '/api/Admin/removeUser';
var EditUser = '/api/Admin/editUser';
var AddUser = '/api/Admin/addUser';

//defining the controllers
CRTapp.controller('LoginCtrl', function Login($scope, $http, $window) {

    $scope.user = {};
    $scope.LoginRequest = function () {
        $http.post(LoginUrl, $scope.user).then(function complete(response) {
            $scope.user = null;
            $window.location.href = response.data;
        })   
    }
});
CRTapp.controller('UserListCtrl', function GetUser($scope, $http, $window) {
    $scope.users = {};
    $scope.onEdit = true;
    $scope.show = false;
    $http.get(getUsersUrl).then(function complete(response) {
        $scope.users = response.data; 
    });
    $scope.DeleteUser = function (userId) {
        $http.post(RemoveUser, userId).then(function complete(response) {
            alert("User " + userId + " deleted !");
            $http.get(getUsersUrl).then(function complete(response) {
                $scope.users = response.data;
            });
        })
    };
    $scope.EditUser = function (user) {
        $http.post(EditUser, user).then(function complete(response) {
            alert("User " + user.Nom + " updated !");
            $scope.onEdit = true;
            $scope.show = false;
        })
    };
    $scope.onUpdate = function () {
        $scope.onEdit = false;
        $scope.show = true;
    }
    $scope.sortBy = function (propertyName) {
        $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
        $scope.propertyName = propertyName;
    };
});
CRTapp.controller('AddUserCtrl', function AddUser($scope, $http) {
    $scope.user = {};
    $scope.AddUser = function () {
        $http.post('/api/Admin/addUser', $scope.user).then(function complete(response) {
            alert("User " + $scope.user.Prenom + " added !");
        })
    };
});