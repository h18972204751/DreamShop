import { login, logout, getInfo } from '@/api/login'
import { getToken, setToken, removeToken } from '@/vuex/auth'

const user = {
  state: {
    token: getToken(),
    name: '',
    avatar: '',
    roles: []
  },

  mutations: {
    SET_TOKEN: (state, token) => {
      state.token = token
    },
    SET_NAME: (state, name) => {
      state.name = name
    },
    SET_AVATAR: (state, avatar) => {
      state.avatar = avatar
    },
    SET_ROLES: (state, roles) => {
      state.roles = roles
    },
    // 设置注册步骤
    SET_SIGN_UP_SETP: (state, step) => {
      state.signUpStep = step;
    },

    // 设置用户登录信息
    SET_USER_LOGIN_INFO : (state, data) => {
      state.userInfo = data;
    },

    // 设置加载状态
    SET_LOAD_STATUS : (state, status) => {
      state.isLoading = status;
    },

    // 设置秒杀商品
    SET_SECKILLS_INFO : (state, seckills) => {
      state.seckills.goodsList = seckills[0];
      state.seckills.deadline = seckills[1];
    },

    // 设置轮播(营销)图
    SET_CAROUSELITEMS_INFO : (state, { carouselItems, activity }) => {
      state.marketing.CarouselItems = carouselItems;
      state.marketing.activity = activity;
    },

    // 设置电脑专栏数据
    SET_COMPUTER_INFO : (state, computer) => {
      state.computer = computer;
    },

    // 设置爱吃专栏数据
    SET_EAT_INFO : (state, eat) => {
      state.eat = eat;
    },

    // 减少秒杀时间
    REDUCE_SECKILLS_TIME : state => {
      state.seckills.deadline.seconds--;
      if (state.seckills.deadline.seconds === -1) {
        state.seckills.deadline.seconds = 59;
        state.seckills.deadline.minute--;
        if (state.seckills.deadline.minute === -1) {
          state.seckills.deadline.minute = 59;
          state.seckills.deadline.hour--;
        }
      }
    },

    // 设置商品列表(搜索)
    SET_GOODS_LIST : (state, data) => {
      state.goodsList = data.goodsList;
      state.asItems = data.asItems;
    },

    // 设置商品列表排序
    SET_GOODS_ORDER_BY : (state, data) => {
      state.orderBy = data;
    },

    // 设置商品详细信息
    SET_GOODS_INFO : (state, data) => {
      state.goodsInfo = data;
    },

    // 添加购物车
    ADD_SHOPPING_CART : (state, data) => {
      const item = {
        goods_id: data.goods_id,
        count: data.count,
        img: data.package.img,
        package: data.package.intro,
        price: data.package.price,
        title: data.title
      };
      state.shoppingCart.push(item);
      state.newShoppingCart = data;
    },

    // 设置购物车信息
    SET_SHOPPING_CART : (state, data) => {
      state.shoppingCart = data;
    },

    // 设置推荐信息
    SET_RECOMMEND_INFO : (state, data) => {
      state.recommend = data;
    },

    // 设置收获地址
    SET_USER_ADDRESS : (state, data) => {
      state.address = data;
    }
  },

  actions: {
    // 登录
    Login({ commit }, userInfo) {
      const username = userInfo.username.trim()
      return new Promise((resolve, reject) => {
        login(userInfo).then(response => {
          if (response.success) {
            console.log(2);
            const tokenStr = response.responseJson
            alert(tokenStr.token);
            setToken(tokenStr.token)
            commit('SET_TOKEN', tokenStr)
            resolve()
          }
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 获取用户信息
    GetInfo({ commit, state }) {
      return new Promise((resolve, reject) => {
        getInfo().then(response => {
          const data = response.response
          // if (data.roles && data.roles.length > 0) { // 验证返回的roles是否是一个非空数组
          //   commit('SET_ROLES', data.roles)
          // } else {
          //   reject('getInfo: roles must be a non-null array !')
          // }
          
          //localStorage.setItem('userInfo', data);
          commit('SET_USER_LOGIN_INFO', data);
          commit('SET_ROLES', "管理员")
          commit('SET_NAME', data.username)
          commit('SET_AVATAR', data.icon)
          resolve(response)
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 登出
    LogOut({ commit, state }) {
      return new Promise((resolve, reject) => {
        logout(state.token).then(() => {
          commit('SET_TOKEN', '')
          commit('SET_ROLES', [])
          removeToken()
          resolve()
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 前端 登出
    FedLogOut({ commit }) {
      return new Promise(resolve => {
        commit('SET_TOKEN', '')
        removeToken()
        resolve()
      })
    }
  }
}

export default user
