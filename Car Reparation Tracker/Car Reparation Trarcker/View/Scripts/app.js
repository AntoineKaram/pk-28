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
    $http.get('/api/Session/getAuth').then(function complete(response) {
        $window.location.href = response.data;
    });
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
CRTapp.controller('AddUserCtrl', function AddUser($scope, $http,$window) {
    $http.get('/api/Session/getAuth').then(function complete(response) {
        $window.location.href = response.data;
    });
    $scope.user = {};
    $scope.AddUser = function () {
        $http.post('/api/Admin/addUser', $scope.user).then(function complete(response) {
            alert("User " + $scope.user.Prenom + " added !");
        })
    };
});
CRTapp.controller('AddCarCtrl', function AddCar($scope, $http,$window) {
    $scope.car = {};
    $http.get('/api/Session/getAuth').then(function complete(response) {
        $window.location.href = response.data;
    });
    $scope.AddCar = function () {
        $http.post('/api/Admin/addCar', $scope.car).then(function complete(response) {
            alert("user " + $scope.car.username + "'s car added !");
        })
    }
    $http.get('/api/Admin/getMarque').then(function complete(response) {
        $scope.Marque = response.data;
    });
});
CRTapp.controller('ExpertCtrl', function ExpertCtrl($scope, $http,$window) {

    $scope.show = false;
    $http.get('/api/Session/getAuth').then(function complete(response) {
        $window.location.href = response.data;
    });
    $scope.search = function () {
        $http.post('/api/Expert/getCars', JSON.stringify($scope.immatriculation)).then(function complete(response) {
            if (response.data !== null && response.data !== undefined && response.data !== "") {
                $scope.cars = response.data;
                $scope.show = true;
            } else {
                alert("The car plate number you have chosen is already related to an accident");
                $scope.immatriculation = "";
                $scope.show = false;
            }
        });
       
    };
    $scope.declareAccident = function (immatriculation) {
        $http.post('/api/Expert/createAccident', JSON.stringify(immatriculation)).then(function complete(response) {
            alert("complete");
            $scope.cars = [{}];
            $scope.immatriculation = "";
            $scope.show = false;
        });
    }
});
CRTapp.controller('RemorqueCtrl', function RemorqueCtrl($scope, $http ,$window) {
    $scope.show = false;
    $http.get('/api/Session/getAuth').then(function complete(response) {
        $window.location.href = response.data;
    });
    $scope.search = function () {
        $http.post('/api/Remorque/getCars', JSON.stringify($scope.immatriculation)).then(function complete(response) {
            if (response.data !== null && response.data !== undefined && response.data !== "") {
                $scope.cars = response.data;
                $scope.show = true;
            } else {
                alert("The car plate number you have chosen have not been declared as accidented");
                $scope.immatriculation = "";
                $scope.show = false;
            }
        });
    }

    $scope.remorqueVoiture = function (platenbr) {
        $http.post('/api/Remorque/debutRemorque', JSON.stringify(platenbr)).then(function complete(response) {
            alert("complete");
            $scope.cars = [{}];
            $scope.immatriculation = "";
            $scope.show = false;
            
        });
    }
})
CRTapp.controller('myCarsCtrl', function myCarsCtrl($scope, $http,$window) {
    $http.get('/api/Session/getAuth').then(function complete(response) {
        $window.location.href = response.data;
    });
    $scope.cars = {};
    $http.get('/api/MyCars/getCars').then(function complete(response) {
        $scope.cars = response.data;
    });

});
CRTapp.controller('CarListCtrl', function CarListCtrl($scope, $http) {
    $scope.cars = {};
    $http.get('/api/Garagiste/getCars').then(function complete(response) {
        $scope.cars = response.data;
    })
})