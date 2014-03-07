(function () {
    'use strict';

    var mod = angular.module('todoControllers', ['todoServices']);

    mod.controller('TodoPageCtrl', ['$scope', '$http', 'todoService', function ($scope, $http, todoService) {
        // properties
        $scope.todoLists = null;
        $scope.activeTodoList = null;

        // methods
        $scope.isActive = function (todoListId) {
            return todoListId === 'archived' ?
                todoService.isArchivedTodoList($scope.activeTodoList) :
                todoListId === $scope.activeTodoList.Id;
        };

        $scope.activate = function (todoListId) {
            var url = todoListId === 'archived' ?
                '/api/todolists/archived' :
                '/api/todolists/' + todoListId;
            $http.get(url).success(function (data, status, headers) {
                $scope.activeTodoList = data;
            });
        };

        // init
        $http.get('/api/todolists').success(function (data) {
            $scope.todoLists = data;
            $scope.activate($scope.todoLists[0].Id);
        });
    }]);

    mod.controller('TodoListCtrl', ['$scope', '$http', 'todoService', function ($scope, $http, todoService) {
        // properties
        $scope.todoText = '';

        // methods
        $scope.addTodo = function () {
            var todo = {
                IsDone: false,
                Text: $scope.todoText
            };
            if (!todoService.validateTodo(todo)) {
                return;
            }

            $scope.activeTodoList.Todos.push(todo);
            $scope.todoText = '';

            var url = '/api/todolists/' + $scope.activeTodoList.Id + '/todos';
            $http.post(url, todo).
                success(function (data, status, headers) {
                    todo.Id = data.Id;
                }).
                error(function (data, status, headers) {
                    alert('Processing Failed.');
                    location.reload();
                });
        };

        $scope.updateTodo = function (todo) {
            var url = '/api/todolists/' + $scope.activeTodoList.Id + '/todos/' + todo.Id;
            $http.put(url, todo).
                success(function (data, status, headers) {
                }).
                error(function (data, status, headers) {
                    alert('Processing Failed.');
                    location.reload();
                });
        };

        $scope.archive = function () {
            $scope.activeTodoList.Todos = todoService.getTodosShouldNotBeArchived($scope.activeTodoList.Todos);

            var url = '/api/todolists/' + $scope.activeTodoList.Id + '/archive';
            $http.put(url).
                success(function (data, status, headers) {
                }).
                error(function (data, status, headers) {
                    alert('Processing Failed.');
                    location.reload();
                });
        };

        $scope.remaining = function () {
            return todoService.getRemainingTodoCount($scope.activeTodoList.Todos);
        };
    }]);

    mod.controller('ArchivedTodoListCtrl', ['$scope', '$http', function ($scope, $http) {
        // methods
        $scope.clearTodos = function () {
            if ($scope.activeTodoList.Todos.length === 0) {
                return;
            }

            $scope.activeTodoList.Todos = [];

            var url = '/api/todolists/' + $scope.activeTodoList.Id + '/clear';
            $http.delete(url).
                success(function (data, status, headers) {
                }).
                error(function (data, status, headers) {
                    alert('Processing Failed.');
                    location.reload();
                });
        };
    }]);
})();
