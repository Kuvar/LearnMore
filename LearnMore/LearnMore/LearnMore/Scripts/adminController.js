
var mainApp = angular.module("adminApp", ['angularUtils.directives.dirPagination']);

mainApp.service("tagService", function ($http) {

    //get All Tag
    this.getAllTags = function () {
        return $http.get("Account/GetTagList");
    };
});

mainApp.controller('tagController', function ($scope, $http) {

    $scope.tags = [];

    $scope.tag = {
        Id: "",
        Name: "",
        UrlSlug: "",
        Description: ""
    };

    $scope.loadTags = function () {
        $http({
            method: 'GET',
            url: '/Account/GetTagList/'
        }).success(function (data, status) {
            $scope.tags = data;            
        });
    };

    $scope.loadTags();

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.editTag = function(tag) {
        $scope.tag = tag; 
        $('#editTag').modal('show');
    };

    $scope.addEditTag = function() {
        $http({
            method: 'POST',
            url: '/Account/AddEditTag',
            params: $scope.tag
        }).success(function(data, status) {
            $scope.loadTags();
            if ($scope.tag.Id > 0) {
                $('#editTag').modal('hide');
            } else {
                $('#addTag').modal('hide');
            }
            $scope.clearTag();
        });
    };

    $scope.addTag = function () {
        $scope.clearTag();
        $('#addTag').modal('show');
    };

    $scope.clearTag = function() {
        $scope.tag = {
            Id: "",
            Name: "",
            UrlSlug: "",
            Description: ""
        };
    };
});

mainApp.controller('categoryController', function($scope, $http) {

    $scope.categories = [];

    $scope.loadCategory = function() {
        $http({
            method: 'GET',
            url: '/Account/GetCategoryList/'
        }).success(function(data, status) {
            $scope.categories = data.rows;
        });
    };

    $scope.loadCategory();

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.editCategory = function(model) {
        
    };

    $scope.deleteCategory = function (model) {

    };
});

mainApp.controller('postController', function($scope, $http) {
    $scope.posts = [];   

    $scope.loadPosts = function () {
        $http({
            method: 'GET',
            url: '/Account/GetPostList/'
        }).success(function (data, status) {
            debugger;
            $scope.posts = data;
        });
    };

    $scope.loadPosts();
}); 
