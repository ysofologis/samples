'use strict';

angular.module('devunion.version', [
  'devunion.version.interpolate-filter',
  'devunion.version.version-directive'
])

.value('version', '0.1');
