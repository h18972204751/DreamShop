import request from '@/vuex/request'
import qs from "qs";
const urls = 'http://localhost:5000';
export function login(userInfo) {
    return request({
        url: urls+'/api/Auth/Login',
        method: 'post',
        data: qs.stringify(userInfo),
        headers:{'content-type': 'application/x-www-form-urlencoded'}    
    })
  }


  export function getInfo() {
    return request({
      url: urls+'/api/UmsMember/GetUserInfo',
      method: 'get',
    })
  }
  
  export function logout() {
    return request({
      url: '/admin/logout',
      method: 'post'
    })
  }
  
  export function fetchList(params) {
    return request({
      url: '/admin/list',
      method: 'get',
      params: params
    })
  }
  
  export function createAdmin(data) {
    return request({
      url: '/admin/register',
      method: 'post',
      data: data
    })
  }
  
  export function updateAdmin(id, data) {
    return request({
      url: '/admin/update/' + id,
      method: 'post',
      data: data
    })
  }
  
  export function updateStatus(id, params) {
    return request({
      url: '/admin/updateStatus/' + id,
      method: 'post',
      params: params
    })
  }
  
  export function deleteAdmin(id) {
    return request({
      url: '/admin/delete/' + id,
      method: 'post'
    })
  }
  
  export function getRoleByAdmin(id) {
    return request({
      url: '/admin/role/' + id,
      method: 'get'
    })
  }
  
  export function allocRole(data) {
    return request({
      url: '/admin/role/update',
      method: 'post',
      data: data
    })
  }
  

