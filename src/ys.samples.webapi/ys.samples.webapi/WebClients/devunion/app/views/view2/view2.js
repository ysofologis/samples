'use strict';

angular.module('devunion.view2', ['ngRoute'])

.config(['$routeProvider', function($routeProvider, viewPath) {
  $routeProvider.when('/view2', {
    templateUrl: viewPath+ '/view2/view2.html',
    controller: 'View2Ctrl'
  });
}])

.controller('View2Ctrl', [function() {

}]);