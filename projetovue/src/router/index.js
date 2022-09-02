import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Produtos from '../views/Produtos.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/Produtos',
    name: 'Produtos',
    component: Produtos
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
