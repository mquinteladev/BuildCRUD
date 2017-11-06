﻿(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/newemployee' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/newemployee',
                config: {
                    templateUrl: 'app/employee/employee.html',
                    title: 'New Employee Initiation',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-dashboard"></i> Employee'
                    }
                },
               
            },
            {
                url: '/',
                config: {
                    templateUrl: 'app/employeeList/employeeList.html',
                    title: 'Employees',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Employees'
                    }
                }
            }
        ];
    }
})();