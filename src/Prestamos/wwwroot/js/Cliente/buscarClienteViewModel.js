
define(['jquery', 'module', 'vuejs'], function (jq, module, Vue) {
    var model = module.config();

    var vm = {
        name: 'Buscador-Clientes',
        data: function(){
            return {
                cedula: model.cedula,
                nombres: model.nombres,
                apellidos: model.apellidos,
                clientes: [],
                url: model.url,
                indBusca: false
            }
        },
        methods: {
            SeleccionCliente: SeleccionarCliente,
            BuscarClientes: BuscarClientes
        }
    };

    function BuscarClientes(event) {
        //TODO Agregar los demas campos a la solicitud
        var vm = this;

        vm.indBusca = true;
        jq.post(vm.url, { cedula: vm.cedula })
            .done(function (data) {
                vm.clientes = data;
                vm.indBusca = false;
            });
    }

    function SeleccionarCliente(event) {
        this.$dispatch('cliente-seleccionado', {
            id: event.targetVM.Id,
            cedula: event.targetVM.Cedula,
            nombre: event.targetVM.NombreTitular
        });
    }

    return vm;
});