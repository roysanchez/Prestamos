class App {
    configureRouter(config, router) {
        config.title = 'Prestamos';
        config.map([
            {route: ['', 'home'], name: 'home', moduleId: 'app/home', nav: true, title: 'Home'},
            {route: 'cliente', name: 'cliente', moduleId: 'app/cliente/listar', nav: true, title: 'Cliente' },
            {route: 'cliente/crear', name: 'crear', moduleId: 'app/cliente/crear', nav: true, title: 'Cliente Crear' }
            //{route: ['', 'cliente'], name: 'app/cliente/list', moduleId: 'app/cliente/list', nav: true, title: 'Cliente'}
        ]);

        this.router = router;
    }
}

export { App };