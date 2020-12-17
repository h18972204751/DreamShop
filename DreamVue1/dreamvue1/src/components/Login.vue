<template>
  <!-- 登录页面 -->
  <div>
    <Row class="container">
      <i-col span="13" offset="2" class="login-img-box">
        <img src="static/img/sale.jpg" alt="" />
      </i-col>
      <i-col span="7" class="login-box">
        <div class="login-container">
          <div class="login-header">
            <p>欢迎登录</p>
          </div>
          <div class="form-box">
            <Form ref="formInline" :model="loginForm" :rules="ruleInline">
              <FormItem prop="username">
                <i-input
                  type="text"
                  v-model="loginForm.username"
                  clearable
                  size="large"
                  placeholder="用户名"
                >
                  <Icon type="md-person" slot="prepend"></Icon>
                </i-input>
              </FormItem>
              <FormItem prop="password">
                <i-input
                  type="password"
                  v-model="loginForm.password"
                  clearable
                  size="large"
                  placeholder="密码"
                >
                  <Icon type="md-lock" slot="prepend"> </Icon>
                </i-input>
              </FormItem>
              <FormItem>
                <Button
                  type="error"
                  size="large"
                  @click="handleSubmit('formInline')"
                  long
                  >登录</Button
                >
              </FormItem>
            </Form>
          </div>
        </div>
      </i-col>
    </Row>
  </div>
</template>

<script>
import store from '../store/index'
import { mapMutations, mapActions } from 'vuex';
export default {
  name: "Login",
  data() {
    return {
      loginForm: {
        username: "",
        password: "",
      },
      ruleInline: {
        username: [
          { required: true, message: "请输入用户名", trigger: "blur" },
        ],
        password: [
          { required: true, message: "请输入密码", trigger: "blur" },
          {
            type: "string",
            min: 3,
            message: "密码不能少于3位",
            trigger: "blur",
          },
        ],
      },
    };
  },
  methods: {
    ...mapMutations(['SET_USER_LOGIN_INFO']),
    handleSubmit(name) {
      this.$refs[name].validate(valid => {
          if (valid) {
            this.loading = true;
            this.$store.dispatch("Login", this.loginForm).then((rs) => {
              console.log(12);
              this.loading = true;
              //setCookie("username",this.loginForm.username,15);
              //setCookie("password",this.loginForm.password,15);
              this.$router.push('/');
            }).catch(() => {
              this.loading = false
            })
          } else {
            console.log('参数验证不合法！');
            return false
          }
        })
    },
  },
 
};
</script>

<style scoped>
.container {
  margin-top: 30px;
  height: 485px;
  background-color: #fff;
}
.login-img-box {
  height: 485px;
  overflow: hidden;
  display: flex;
  align-items: center;
  justify-content: center;
}
.login-img-box > img {
  width: 68%;
}
.login-box {
  height: 485px;
  display: flex;
  align-items: center;
  justify-content: center;
}
.login-container {
  width: 80%;
  height: 280px;
  border: #ed3f14 solid 1px;
}
.login-header {
  height: 50px;
  font-size: 20px;
  text-align: center;
  line-height: 50px;
  letter-spacing: 5px;
  color: #fff;
  background-color: #ed3f14;
}
.form-box {
  width: 80%;
  margin: 30px auto;
}
</style>
