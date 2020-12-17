import axios from 'axios';
import { Message, MessageBox } from 'element-ui';
import qs from "qs";
import { getToken }  from './auth';



// 创建axios实例
const service = axios.create({
  //baseURL: process.env.BASE_API, // api的base_url
  timeout: 15000, // 请求超时时间
});
const getters = {
  sidebar: state => state.app.sidebar,
  device: state => state.app.device,
  token: state => state.user.token,
  avatar: state => state.user.avatar,
  name: state => state.user.name,
  roles: state => state.user.roles,
  addRouters: state => state.permission.addRouters,
  routers: state => state.permission.routers
}


// request拦截器
service.interceptors.request.use(config => {
  if (getters.token) {
    console.log(getToken());
    config.headers['Authorization'] ="Bearer "+ getToken() // 让每个请求携带自定义token 请根据实际情况自行修改
  }
  return config
}, error => {
  // Do something with request error
  console.log(error) // for debug
  Promise.reject(error)
})

export default service