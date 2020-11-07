<template>
    <div>
        <Row class="container">
            <i-col span="12" offset="2" class="signup-img-box">
                <img src="static/img/signup-sale.png" alt="" />
            </i-col>
            <i-col span="8" class="box">
                <div class="sign-up-title">
                    <h1>欢迎注册账号</h1>
                    <br />
                    <!-- <h2>BIT MALL, 天天低价品质保证, 让消费者钱更值钱</h2> -->
                </div>
                <div class="sing-up-step-box">
                    <!-- <Steps :current="signUpStep">
                        <Step title="验证手机号" icon="iphone"></Step>
                        <Step title="填写账号信息" icon="person-add"></Step>
                        <Step title="注册成功" icon="ios-checkmark-outline"></Step>
                    </Steps>
                    <div class="sign-up-box">
                        <transition mode="out-in">
                            <router-view></router-view>
                        </transition>
                    </div> -->
                    <div class="info-form">
                        <Form ref="formValidate" :model="formValidate" :rules="ruleValidate" :label-width="80">
                            <FormItem label="登录账号" prop="LoginName">
                                <i-input v-model="formValidate.LoginName" clearable size="large" placeholder="设置后不可更改"></i-input>
                            </FormItem>
                            <FormItem label="密码" prop="LoginPassword">
                                <i-input type="password" v-model="formValidate.LoginPassword" clearable size="large" placeholder="请输入你的密码"></i-input>
                            </FormItem>
                            <FormItem label="确认密码" prop="repassword">
                                <i-input type="password" v-model="formValidate.repassword" clearable size="large" placeholder="请再次输入你的密码"></i-input>
                            </FormItem>

                            <FormItem label="昵称" prop="Account">
                                <i-input v-model="formValidate.Account" clearable size="large" placeholder="请输入昵称(可在个人信息修改)"></i-input>
                            </FormItem>

                            <FormItem label="手机号" prop="phone">
                                <i-input v-model="formValidate.phone" clearable size="large" placeholder="请输入手机号"></i-input>
                            </FormItem>
                            <FormItem label="验证码" prop="checkNum">
                                <i-input v-model="formValidate.checkNum" size="large" placeholder="请输入验证码">
                                    <Button slot="append" @click="getcheckNum">获取验证码</Button>
                                </i-input>
                            </FormItem>

                            <Button type="error" size="large" long @click="handleSubmit('formValidate')">注册</Button>
                        </Form>
                    </div>

                </div>
            </i-col>
        </Row>
        <Footer></Footer>
    </div>
</template>

<script>
import store from "@/vuex/store";
import { mapState, mapMutations } from "vuex";
import axios from "axios";

export default {
    name: "SignUp",
    data() {
        const validatePassCheck = (rule, value, callback) => {
            if (value === "") {
                callback(new Error("请再次输入密码"));
            } else if (value !== this.formValidate.LoginPassword) {
                callback(new Error("两次输入的密码不一样"));
            } else {
                callback();
            }
        };
        return {
            formValidate: {
                LoginName: "admins",
                phone: "18972204751",
                LoginPassword: "123456",
                Account: "text1",
                repassword: "123456",
            },
            ruleValidate: {
                LoginName: [
                    {
                        required: true,
                        message: "登录账号不能为空",
                        trigger: "blur",
                    },
                    {
                        type: "string",
                        min: 6,
                        message: "登录账号长度不能小于6",
                        trigger: "blur",
                    }
                ],

                LoginPassword: [
                    {
                        required: true,
                        message: "密码不能为空",
                        trigger: "blur",
                    },
                    {
                        type: "string",
                        min: 6,
                        message: "密码长度不能小于6",
                        trigger: "blur",
                    },
                ],
                Account: [
                    {
                        required: true,
                        message: "昵称不能为空",
                        trigger: "blur",
                    },
                ],

                phone: [
                    {
                        required: true,
                        message: "手机号不能为空",
                        trigger: "blur",
                    },
                    {
                        type: "string",
                        pattern: /^1[3|4|5|7|8][0-9]{9}$/,
                        message: "手机号格式出错",
                        trigger: "blur",
                    },
                ],
                checkNum: [
                    {
                        required: true,
                        message: "必须填写验证码",
                        trigger: "blur",
                    },
                    {
                        type: "string",
                        min: 4,
                        max: 4,
                        message: "验证码长度错误",
                        trigger: "blur",
                    },
                ],
                repassword: [{ validator: validatePassCheck, trigger: "blur" }],
            },
        };
    },
    computed: {
        ...mapState(["signUpStep"]),
    },
    methods: {
        ...mapMutations(["SET_SIGN_UP_SETP"]),
        getcheckNum() {
            if (this.formValidate.phone.length === 11) {
                this.$Message.success({
                    content: "验证码为: 12346",
                    duration: 6,
                    closable: true,
                });
            } else {
                this.$Message.error({
                    content: "请输入正确的手机号",
                    duration: 6,
                    closable: true,
                });
            }
        },
        handleSubmit(name) {
            const father = this;
            this.$refs[name].validate((valid) => {
                if (valid) {
                    console.log(valid);
                    console.log(this.formValidate);
                    const url = 'http://localhost:5000/';
                    //localhost:5000/api/Login/SignUpUser
                    axios.post('http://localhost:5000/api/Login/SignUpUser',this.formValidate)
                        .then((res) => {
                            console.log(res);
                            if (res.data.success) {
                                this.$Message.success(res.data.msg);
                                this.$router.push({ path: "/" });
                            } else {
                                this.$Message.error(res.data.msg);
                                return false;
                            }
                        });

                    
                    const userinfo = {
                        username: this.formValidate.LoginName,
                        password: this.formValidate.LoginPassword,
                        mail: this.formValidate.mail,
                        phone: this.formValidate.phone,
                    };
                    this.addSignUpUser(userinfo);
                    father.SET_SIGN_UP_SETP(2);
                    this.$router.push({ path: "/SignUp/signUpDone" });
                } else {
                    this.$Message.error("注册失败");
                }
            });
        },
    },
    store,
    mounted() {
        //this.SET_SIGN_UP_SETP(0);
    },
};
</script>

<style scoped>
.container {
    margin: 15px auto;
    height: 700px;
    overflow: hidden;
}
.signup-img-box {
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
}
.signup-img-box > img {
    height: 80%;
}
.sign-up-title {
    width: 430px;
    margin: 15px auto;
    height: 30px;
}
.sing-up-step-box {
    margin: 15px auto;
    padding-left: 20px;
    padding-top: 20px;
    width: 430px;
    height: 470px;
    border: 1px solid #495060;
}
.sign-up-box {
    margin: 30px 25px;
    width: 380px;
    display: flex;
    align-items: center;
}
.info-form {
    width: 95% !important;
}
</style>
