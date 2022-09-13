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
    },

    logOff(state)
    {
        state.token= false;
    }
    
   },
   actions: {

   }
})

export default store