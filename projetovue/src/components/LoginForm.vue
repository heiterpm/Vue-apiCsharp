<template>
  <div id="caixa-login">
    <h1>Login</h1>
    <form id="formlogin">
      <div id="logintxt">
        <input type="text" id="usuario" v-model="user" class="form-control list-group-item" placeholder="Usuario"><br>
        <input type="password" id="senha" v-model="password" class="form-control list-group-item" placeholder="Senha">
      </div>
      <button v-on:click="login">Logar</button>
    </form>
  </div>
</template>
  
  <script>
import api from '@/services/api'

export default {
  name: 'LoginForm',
  data() {
    return {
        user: "",
        password: ""
    }
  },
  methods: {
    async login(e){
      e.preventDefault(e)
      if(this.validaLogin()){
        api.post('Usuarios/Login',{
            nome: "nome",
            usuario: this.user,
            senha: this.password
        })
        .then(response => {
          console.log(response)
            localStorage.setItem('token',JSON.stringify(response.data));
            response.data = "";
            this.$router.push({name:"Produtos"})
        })
      }
    },
    validaLogin(){
      if(!this.user){
        console.log("Usuario nulo")
        return;
      }
      if(!this.password){
        console.log("senha errada")
        return;
      }
      return true;
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