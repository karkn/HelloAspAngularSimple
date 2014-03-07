(function () {
    'use strict';

    var mod = angular.module('todoServices', []);

    mod.factory('todoService', [TodoService]);

    function TodoService() {
        return {
            getTodosShouldNotBeArchived: getTodosShouldNotBeArchived,
            getRemainingTodoCount: getRemainingTodoCount,
            validateTodo: validateTodo,
            isArchivedTodoList: isArchivedTodoList
        };

        function getTodosShouldNotBeArchived(todos) {
            var ret = [];
            angular.forEach(todos, function (todo) {
                if (!todo.IsDone) {
                    ret.push(todo);
                }
            });
            return ret;
        }

        function getRemainingTodoCount(todos) {
            var count = 0;
            angular.forEach(todos, function (todo) {
                count += todo.IsDone ? 0 : 1;
            });
            return count;
        }

        function validateTodo(todo) {
            return todo.Text !== null && todo.Text.length > 0;
        }

        function isArchivedTodoList(todoList) {
            return todoList.Kind === 1;
        }
    }
})();
