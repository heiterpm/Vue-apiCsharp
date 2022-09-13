import { createStore } from "vuex" 

const store = createStore({
   state:{
    token: false,
    logado: false
   },
   getters: {
    getToken: state => state.token
   },
   mutations: {
    salvarTokenauth(state, payload){
        state.token = payload;
        console.log(state.token)
    },

    logOff(state)
    {
        state.token= false;
        console.log(state.token)
    }
    
   },
   actions: {

   }
})

export default store