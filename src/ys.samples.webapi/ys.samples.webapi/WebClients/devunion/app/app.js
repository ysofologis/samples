'use strict';

// Declare app level module which depends on views, and components
angular.module('devunion', [
  'ngRoute',
  'devunion.view1',
  'devunion.view2',
  'devunion.version'
]).
    constant('viewPath','views').
config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {
  $locationProvider.hashPrefix('!');

  $routeProvider.otherwise({redirectTo: '/view1'});
}]);
