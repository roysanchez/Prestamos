class App {
    configureRouter(config, router) {
        config.title = 'Prestamos';
        config.map([
            {route: ['', 'home'], name: 'home', moduleId: 'app/home', nav: true, title: 'Home'},
            {route: 'cliente/list', name: 'cliente', moduleId: 'app/cliente/list', nav: true, title: 'Cliente' }
            //{route: ['', 'cliente'], name: 'app/cliente/list', moduleId: 'app/cliente/list', nav: true, title: 'Cliente'}
        ]);

        this.router = router;
    }
}

export { App };