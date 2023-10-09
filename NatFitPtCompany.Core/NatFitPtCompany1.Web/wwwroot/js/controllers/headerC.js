app.controller('headerC', function($scope) {
	$scope.$on('$locationChangeStart', function(event, next, current) {
        var url = new URL(next);
        if (url.hash == "#!/#%2F!" || url.hash == "#!/") {
          $scope.pageTitle = "sub-header";
        }else {
          $scope.pageTitle = "sub-header";
        }

	});
});



