<template>
  <div id="caixa-login">
    <h1>Login</h1>
    <form method="post" id="formlogin" @submit="getUser">
      <div id="logintxt">
        <input type="text" id="user" v-model="user" class="form-control list-group-item" placeholder="Usuario"><br>
        <input type="text" id="password" v-model="password" class="form-control list-group-item" placeholder="Senha">
      </div>
      <button type="submit">Logar</button>
    </form>
  </div>
</template>
  
  <script>
export default {
  name: 'LoginForm',
  data() {
    return {
      user: null,
      password: null
    }
  },
  methods: {
    async getUser(e) {
      e.preventDefault();
      const req = await fetch("http://localhost:3000/usuarios/1");
      const data = await req.json();
      console.log(data);
    },
  },
  mounted() {

  }
}
</script>
   
  <style scoped>
  #caixa-login {
    background: #222;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 300px;
    border-radius: 10px;
  }
  
  #caixa-login h1 {
    color: #fcba03;
    text-align: center;
    margin-top: 20px;
    padding: 0 0 20px 0;
  }
  
  #caixa-login #formlogin {
    width: auto;
    display: block;
    text-align: center;
    justify-content: center;
  }
  
  #caixa-login input {
    margin: 3px;
    height: 30px;
    border-radius: 10px;
    text-align: center;
  }
  
  #caixa-login button {
    margin: 3px;
    height: 30px;
    width: 162px;
    border-radius: 10px;
    color: white;
    background-color: #fcba03;
    border-color: transparent;
    text-align: center;
    margin-bottom: 10px;
    transition: .5s;
  }
  
  #caixa-login button:hover {
    font-size: 20px;
  }
  </style>