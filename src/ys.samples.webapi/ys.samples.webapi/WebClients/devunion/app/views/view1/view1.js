'use strict';

angular.module('devunion.view1', ['ngRoute'])

.config(['$routeProvider', function($routeProvider, viewPath) {
  $routeProvider.when( '/view1', {
    templateUrl: viewPath + '/view1/view1.html',
    controller: 'View1Ctrl'
  });
}])

.controller('View1Ctrl', [function() {

}]);