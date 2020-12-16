// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import ViewUI from 'view-design';
import 'view-design/dist/styles/iview.css';
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import locale from 'element-ui/lib/locale/lang/zh-CN' // lang i18n

import store from './store'
import '@/permission'
Vue.config.productionTip = false
Vue.use(ViewUI);
Vue.use(ElementUI, { locale })
new Vue({
    el: '#app',
    router,
    store,
    components: { App },
    template: '<App/>'
})