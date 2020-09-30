<template>
  <div class="box">
    <div class="nav">
      <ui>
        <li>
          <el-dropdown>
            <span class="el-dropdown-link">
              <a href="javascript:void(0)">
                <Icon type="ios-location" class="icon"></Icon> {{ city }}
              </a>
            </span>
            <el-dropdown-menu slot="dropdown">
              <div class="city">
                <p v-for="(items, index) in cityArr" :key="index">
                    <span v-for="(item, index) in items" class="city-item" :key="index" @click="changeCity(item)" >
                        <el-dropdown-item>{{ item }}</el-dropdown-item>
                    </span >
                </p>
              </div>
            </el-dropdown-menu>
          </el-dropdown>
        </li>
      </ui>
      <ui>
        <li></li>
      </ui>
    </div>
  </div>
</template>

<script>
export default {
  name: "Header",
  data() {
    return {
      city: "珠海",
      cityArr: [
        ["北京", "上海", "天津", "重庆", "广州"],
        ["深圳", "河南", "辽宁", "吉林", "江苏"],
        ["江西", "四川", "海南", "贵州", "云南"],
        ["西藏", "陕西", "甘肃", "青海", "珠海"],
      ],
    };
  },
};
</script>

<style>
.body {
  margin: 0px;
  padding: 0px;
}
.box {
  width: 100%;
  height: 35px;
  background-color: #e3e4e5;
}
.nav {
  margin: 0% auto;
  width: 90%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
.nav ul {
  list-style: none;
}
.nav li {
  float: left;
  font-size: 14px;
  line-height: 35px;
  margin-right: 15px;
  font-weight: bold;
}
.el-dropdown-link {
  cursor: pointer;
  color: #409eff;
}
.el-icon-arrow-down {
  font-size: 12px;
}
</style>