import Vue from "vue";
import Component from "vue-class-component";
import { Inject, Provide } from "vue-property-decorator";

@Component({
    template: require("./search-hero.component.html"),
    name: "search-heroes"
})
export class SearchHeroesComponent extends Vue {
    @Inject() apiUrl: string;

    constructor() {
        super();
    }

    nickname: string = "nickname to search";

    mounted(): void { }

    search(): void {
        console.log("search: " + this.nickname);
    }
}
