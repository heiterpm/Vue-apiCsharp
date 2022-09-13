<template>
    <div id="nav">
        <router-link to="/" id="logo-url">
            <img :src="logo" :alt="alt" id="logo">
        </router-link>
        <nav>
            <router-link to="/">Home</router-link> |
            <router-link to="/Produtos">Produtos</router-link>
            <a href="javascript:void(0);" v-if="this.token != 'false'" @click="logoff">Logoff</a>
        </nav>
    </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
    name: "Navbar",
    props: ["logo", "alt"],
    data() {
        return {
            token: this.$store.state.token,
        }
    },
    methods: {
        async verificaLogin() {
            this.token = localStorage.getItem('token');
            if (this.token === "false") {
                console.log(this.token)
                return 0;
            } else {
                console.log(this.token)
                return 1;
            }
            
        },
        logoff() {
            localStorage.setItem('token', JSON.stringify(false));
            this.$store.commit('logOff')
            this.verificaLogin();
            this.$router.push({ name: "home" })
        },
    },
    mounted() {
        this.verificaLogin()
    },
    watch:{
        '$store.state.token'(){
            console.log('Deu certo?');
            this.verificaLogin();
        }
    }
}
</script>

<style scoped>
#nav {
    background-color: #222;
    border-bottom: 4px solid #111;
    padding: 15px 50px;
    display: flex;
    justify-content: flex-end;
    align-items: center;
}

#nav #logo-url {
    margin: auto;
    margin-left: 0
}

#logo {
    width: 40px;
    height: 40px;
}

#nav a {
    color: #fcba03;
    text-decoration: none;
    margin: 12px;
    transition: .5s;
}

#nav a:hover {
    color: red;
}

</style>