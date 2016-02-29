﻿class App {
    configureRouter(config, router) {
        config.title = 'Prestamos';
        config.map([
            {route: ['', 'home'], name: 'home', moduleId: 'app/home', nav: true, title: 'Home'},
            {route: 'cliente', name: 'cliente', moduleId: 'app/cliente/index', nav: true, title: 'Clientes' },
            {route: 'cliente/crear', name: 'cliente-crear', moduleId: 'app/cliente/crear', title: 'Crear nuevo cliente' }
        ]);

        this.router = router;
    }
}

export { App };