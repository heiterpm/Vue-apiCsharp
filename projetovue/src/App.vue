<template>
  <Navbar :logo="logo_src" :alt="app_name" />
  <router-view />
  <Footer />
</template>

<script>
import Navbar from './components/Navbar.vue';
import Footer from './components/Footer.vue';

export default {
  components: {
    Navbar,
    Footer
  },
  data() {
    return {
      logo_src: "/img/logo.png",
      app_name: "Lista de Produtos"
    }
  }
}
</script>


<style>
@import url(https://fonts.googleapis.com/css?family=Roboto);

* {
  font-family: Roboto;
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

html {
  min-height: 100%;
  background-image: url('../public/img/mercado.jpg');
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center center;
}
</style>
