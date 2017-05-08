import { CreateHeroComponent } from "./components/create-hero.component";
import Vue from "vue";
import Router from "vue-router";
import { ListHeroesComponent } from "./components/list-heroes.component";

Vue.use(Router);

export default new Router({
    routes: [
        { path: "/", component: ListHeroesComponent },
        { path: "/create-hero", component: CreateHeroComponent }
    ]
});
