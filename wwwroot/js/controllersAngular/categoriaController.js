app.controller('categoriaController', function ($scope, $http) {

    $scope.categoria = {};

    $scope.abrirForm = function () {
        $('#modalCadastro').modal('show');
    };

    $scope.editarCategoria = function (id) {
        $http.get("/Categoria/BuscarCategoria/" + id).then(response => {
            $scope.categoria = response.data;
            $('#modalCadastro').modal('show');
            console.log($scope.categoria);
        }).catch(error => {
            console.error("Erro ao buscar a categoria:", error);
        });
    };

    $scope.excluirCategoria = function (id) {
        $http.get("/Categoria/BuscarCategoria/" + id).then(response => {
            $('#confirmModal').modal('show');
            $scope.categoria = response.data;
        }).catch(error => {
            console.error("Erro ao excluir a categoria:", error);
        });
    };
});