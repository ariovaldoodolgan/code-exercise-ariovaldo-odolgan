import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import Varlet from "@varlet/ui";
import "@varlet/ui/es/style.js";
import { createPinia } from "pinia";

import "./assets/sass/main.scss";

const app = createApp(App);

app.use(createPinia());

app.use(router);
app.use(Varlet);
app.use(createPinia);

app.mount("#app");
