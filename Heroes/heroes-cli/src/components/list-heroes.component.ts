import Vue from "vue";
import Component from "vue-class-component";

@Component({
    template: require("./list-heroes.component.html")
})
export class ListHeroesComponent extends Vue {
    constructor() {
        super();
    }

    mounted() { }
}
