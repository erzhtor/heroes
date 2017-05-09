import { SearchHeroesComponent } from "./components/search-hero.component";

// the Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from "vue";
import App from "./App.vue";
import router from "./main-router";

import "./scss/main.scss";

Vue.config.productionTip = false;
Vue.component("search-heroes", SearchHeroesComponent);

// tslint:disable-next-line:no-unused-expression
new Vue({
    el: "#app",
    router,
    provide: {
        router: router
    },
    template: "<App/>",
    components: { App, SearchHeroesComponent },
});
