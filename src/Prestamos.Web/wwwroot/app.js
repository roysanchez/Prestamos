class App {
    configureRouter(config, router) {
        config.title = 'Prestamos';
        config.map([
            {route: ['', 'home'], name: 'home', moduleId: 'app/home', nav: true, title: 'Home'}
        ]);

        this.router = router;
    }
}

export { App };