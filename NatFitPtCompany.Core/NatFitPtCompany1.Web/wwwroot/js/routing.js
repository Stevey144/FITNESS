var app = angular.module("natFit", ["ngRoute"]);
app.config(function($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl : "pages/home.html"
    })
    .when("/home", {
        templateUrl : "pages/home.html"
    })
        .when("/pricing", {
            templateUrl: "pages/pricing.html"
        })
    .when("/services", {
        templateUrl : "pages/services.html"
    })
    .when("/taster", {
        templateUrl: "pages/tasterForm.html",
         controller: "offerController"
    })
    .when("/testimonials", {
        templateUrl : "pages/testimonials.html"
    })
    .when("/contacts", {
        templateUrl: "pages/contacts.html",
         controller: "contactController"
    })
    .when("/termsandconditions", {
         templateUrl: "pages/termsandconditions.htm"
    })
    .when("/gift-card", {
         templateUrl: "pages/giftCard.html"
    });
});

app.controller('contactController', function ($scope, $http, $location) {
    $scope.formData = {
        title: "",
        firstName: "",
        lastName: "",
        organisationEmail: "",
        telephoneNumber: "",
        mobileNumber: "",
        includeInMailingList: true,
        Message: "",
        MessageVisibility: false,
		RetMessage: ""
    };

    $scope.postBusinessContact = function () {

        $scope.baseUrl = $location.$$protocol + '://' + $location.$$host;
        $scope.Url = $scope.baseUrl + "/api/NatFitPt/contactus";

        $http.post($scope.Url, $scope.formData).then(
            function successCallback(response) {
                $scope.formData.title = "";
                $scope.formData.firstName = "";
                $scope.formData.lastName = "";
                $scope.formData.organisationEmail = "";
                $scope.formData.telephoneNumber = "";
                $scope.formData.mobileNumber = "";
                $scope.formData.includeInMailingList = true;
				 $scope.formData.Message = "";
                $scope.formData.RetMessage = "Thanks, Please your business contact has been successfully saved, we will get in touch with you shortly.";
                $scope.formData.MessageVisibility = true;
            },
            function errorCallback(response) {
                console.log("POST-ing of data failed");
            }
        );
    };

});

app.controller('offerController', function ($scope, $http, $location) {
    $scope.formData = {
        title: "",
        firstName: "",
        lastName: "",
        organisationEmail: "",
        telephoneNumber: "",
        mobileNumber: "",
        includeInMailingList: true,
        Message: "",
        MessageVisibility: false,
		RetMessage: ""
    };

    $scope.postBusinessOffer = function () {

        $scope.baseUrl = $location.$$protocol + '://' + $location.$$host;
        $scope.Url = $scope.baseUrl + "/api/NatFitPt/offers";

        $http.post($scope.Url, $scope.formData).then(
            function successCallback(response) {
                $scope.formData.title = "";
                $scope.formData.firstName = "";
                $scope.formData.lastName = "";
                $scope.formData.organisationEmail = "";
                $scope.formData.telephoneNumber = "";
                $scope.formData.mobileNumber = "";
                $scope.formData.includeInMailingList = true;
				 $scope.formData.Message = "";
                $scope.formData.RetMessage = "Thanks, Please your taster session request has been successfully saved, we will get in touch with you shortly.";
                $scope.formData.MessageVisibility = true;
            },
            function errorCallback(response) {
                console.log("POST-ing of data failed");
            }
        );
    };

});


